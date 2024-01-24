
using AutoMapper;
using Dapper;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Logging;
using Nencer.Helpers;
using Nencer.Modules.Checkin.Model;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Modules.ManageService.Repository;
using Nencer.Modules.Patient.Model;
using Nencer.Modules.Patient.Repository;
using Nencer.Modules.Users.Model;
using Nencer.Resources;
using Nencer.Shared;
using System;
using System.Data;
using System.Security.Cryptography;
using static Dapper.SqlMapper;
using static Nencer.Shared.Constant;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nencer.Modules.Checkin.Repository
{
    public interface ICheckinOrdinalRepository
    {
        Task GenerateCheckinOrdinal(string takeNumber);
        Task<List<BaseCallingOrdinal>> GetCheckinOrdinalNumber();
        Task<BaseCallingOrdinal> ChekinCalling(string takeNumber, int doorId);
        Task<BaseCallingOrdinal> GetChekinCallNextNumber(string takeNumber, int doorId);
        Task<BaseCallingOrdinal> GetCheckinNumberAndCalling(string takeNumber, int number);
        Task<List<BaseWindowDisplayNumberResponse>> WindowCheckinCallingNumber(string[] doorCode);
    }
    public class CheckinOrdinalRepository : ICheckinOrdinalRepository
    {
        private readonly NencerDbContext _context;

        private readonly DapperContext _dapperContext;

        public CheckinOrdinalRepository(NencerDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task<List<BaseCallingOrdinal>> GetCheckinOrdinalNumber()
        {
            var rs = new List<BaseCallingOrdinal>();
            using (var con = _dapperContext.CreateConnection())
            {
                var procNam = "sp_get_checkin_calling_number";
                using (var multi = await con.QueryMultipleAsync(procNam, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var st = multi.Read<BaseCallingOrdinal>().ToList();
                    var ut = multi.Read<BaseCallingOrdinal>().ToList();
                    // ST
                    if (st.Any())
                    {
                        rs.AddRange(st);
                    }
                    else
                    {
                        rs.Add(new BaseCallingOrdinal()
                        {
                            Number = 0,
                            CallingNumber = 0,
                            DoorCode = "ST",
                        });
                    }

                    // UT
                    if (ut.Any())
                    {
                        rs.AddRange(ut);
                    }
                    else
                    {
                        rs.Add(new BaseCallingOrdinal()
                        {
                            Number = 0,
                            CallingNumber = 0,
                            DoorCode = "UT",
                        });
                    }
                }

            }
            return rs;
        }

        public async Task GenerateCheckinOrdinal(string takeNumber)
        {
            int num = 1;
            using (var con = _dapperContext.CreateConnection())
            {
                var procNam = "sp_generate_checkin_ordinal";
                var dynamicPa = new DynamicParameters();
                dynamicPa.Add("P_TAKE_NUMBER", takeNumber);

                var x = await con.QueryFirstOrDefaultAsync<OrdinalModel>(procNam, dynamicPa, commandType: System.Data.CommandType.StoredProcedure);
                if (x != null && x.Number > 0)
                {
                    num = x.Number + 1;
                }
            }

            // 
            string ordinal = ApiHelper.GenerateCheckinTakeNumber(num, takeNumber);
            await _context.CheckinOrdinals.AddAsync(new CheckinOrdinal()
            {
                Number = num,
                DateTime = ordinal,
                CreatedAt = DateTime.Now,
                DoorCode = takeNumber.Equals(Constant.OrdinalDoor.ST.ToString()) ? Constant.OrdinalDoor.ST.ToString() : Constant.OrdinalDoor.UT.ToString(),

            });
            await _context.SaveChangesAsync();
        }

        public async Task<BaseCallingOrdinal> ChekinCalling(string takeNumber, int doorId)
        {
            using (var con = _dapperContext.CreateConnection())
            {
                var procNam = "sp_get_checkin_calling";
                var dynamicPa = new DynamicParameters();
                dynamicPa.Add("P_TAKE_NUMBER", takeNumber);
                dynamicPa.Add("P_DOOR_ID", doorId);

                var x = await con.QueryFirstOrDefaultAsync<BaseCallingOrdinal>(procNam, dynamicPa, commandType: System.Data.CommandType.StoredProcedure);
                if (x != null)
                {
                    return x;
                }
                return null;
            }
        }

        public async Task<BaseCallingOrdinal> GetChekinCallNextNumber(string takeNumber, int doorId)
        {
            using (var con = _dapperContext.CreateConnection())
            {
                int callingNumber = 1;
                var procNam = "sp_get_checkin_call_next_number";
                var dynamicPa = new DynamicParameters();
                dynamicPa.Add("P_TAKE_NUMBER", takeNumber);

                var x = await con.QueryFirstOrDefaultAsync<BaseCallingOrdinal>(procNam, dynamicPa, commandType: System.Data.CommandType.StoredProcedure);
                if (x != null)
                {
                    callingNumber = x.Number + 1;
                }

                // kiem tra stt 
                var x1 = await GetCheckinNumberAndCalling(takeNumber, callingNumber);
                if (x1 == null)
                {
                    return null;
                }
                var checkinOrdinal = await _context.CheckinOrdinals.FirstOrDefaultAsync(x => x.Id == x1.Id);
                checkinOrdinal.DoorId = doorId;
                checkinOrdinal.Status = Constant.Calling.CALLED.GetHashCode();
                checkinOrdinal.UpdatedAt = DateTime.Now;
                checkinOrdinal.CallingNumber = callingNumber;
                _context.CheckinOrdinals.Update(checkinOrdinal);
                await _context.SaveChangesAsync();

                return new BaseCallingOrdinal()
                {
                    Id = checkinOrdinal.Id,
                    DoorCode = x1.DoorCode,
                    Number = x1.Number,
                    CallingNumber = callingNumber,
                };
            }
        }

        public async Task<BaseCallingOrdinal> GetCheckinNumberAndCalling(string takeNumber, int number)
        {
            using (var con = _dapperContext.CreateConnection())
            {
                // kiem tra stt
                var procName1 = "sp_get_checkin_call_next_number_check";
                var dynamicPa1 = new DynamicParameters();
                dynamicPa1.Add("P_TAKE_NUMBER", takeNumber);
                dynamicPa1.Add("P_CALLING_NUMBER", number);
                var x1 = await con.QueryFirstOrDefaultAsync<BaseCallingOrdinal>(procName1, dynamicPa1, commandType: System.Data.CommandType.StoredProcedure);
                if (x1 == null)
                {
                    return null;
                }
                return x1;
            }
        }

        public async Task<List<BaseWindowDisplayNumberResponse>> WindowCheckinCallingNumber(string[] doorCode)
        {
            var lsOn = new List<BaseWindowDisplayNumberResponse>();
            using (var con = _dapperContext.CreateConnection())
            {
                foreach (var code in doorCode)
                {
                    var procName1 = "sp_get_checkin_window_calling_number";
                    var dynamicPa1 = new DynamicParameters();
                    dynamicPa1.Add("P_DOOR_CODE", code);

                    var x1 = await con.QueryAsync<BaseWindowDisplayNumberResponse>(procName1, dynamicPa1, commandType: System.Data.CommandType.StoredProcedure);
                    if (x1 != null && x1.Any())
                    {
                        lsOn.AddRange(x1);
                    }
                }
            }
            return lsOn;
        }
    }
}
