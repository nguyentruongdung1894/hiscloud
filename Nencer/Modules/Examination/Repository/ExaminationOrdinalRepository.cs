using Dapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Checkin.Model.Dto;
using System.Reflection.Metadata;
using Nencer.Shared;

namespace Nencer.Modules.Patient.Repository
{
    public interface IExaminationOrdinalRepository
    {
        Task<BaseCallingOrdinal> GetExamByRoomId(string roomCode);
        Task<BaseCallingOrdinal> GetExamCallNextNumber(string roomCode);
        Task<BaseCallingOrdinal> GetExamNumberAndCalling(string roomCode, int number);
        Task<ExaminationCallingUserResponse> WindowExamCallingNumber(string[] roomCodes);
    }

    public class ExaminationOrdinalRepository : IExaminationOrdinalRepository
    {
        private readonly DapperContext _dapperContext;
        private readonly NencerDbContext _context;

        public ExaminationOrdinalRepository(DapperContext dapperContext, NencerDbContext context)
        {
            _dapperContext = dapperContext;
            _context = context;
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

        public async Task<BaseCallingOrdinal> GetExamByRoomId(string roomCode)
        {
            return await _context.ExaminationOrdinals
                .Where(x => x.RoomCode == roomCode && x.Status == Nencer.Shared.Constant.Calling.CALLED.ToString())
                .OrderByDescending(x => x.CallingNumber)
                .Select(y => new BaseCallingOrdinal()
                {
                    CallingNumber = y.CallingNumber.HasValue ? y.CallingNumber.Value : 0,
                    Number = y.Number.HasValue ? y.Number.Value : 0
                }).FirstOrDefaultAsync();
        }

        public async Task<BaseCallingOrdinal> GetExamNumberAndCalling(string roomCode, int number)
        {
            using (var con = _dapperContext.CreateConnection())
            {
                // kiem tra stt
                var procName1 = "sp_get_exam_room_number_called";
                var dynamicPa1 = new DynamicParameters();
                dynamicPa1.Add("P_NUMBER", number);
                dynamicPa1.Add("P_ROOM_CODE", roomCode);
                var x1 = await con.QueryFirstOrDefaultAsync<BaseCallingOrdinal>(procName1, dynamicPa1, commandType: System.Data.CommandType.StoredProcedure);
                if (x1 == null)
                {
                    return null;
                }
                return x1;
            }
        }

        public async Task<BaseCallingOrdinal> GetExamCallNextNumber(string roomCode)
        {
            using (var con = _dapperContext.CreateConnection())
            {
                int callingNumber = 1;
                var procNam = "sp_get_exam_calling_number";
                var dynamicPa = new DynamicParameters();
                dynamicPa.Add("P_STATUS", Shared.Constant.Calling.CALLED.ToString());
                dynamicPa.Add("P_ROOM_CODE", roomCode);

                var x = await con.QueryFirstOrDefaultAsync<BaseCallingOrdinal>(procNam, dynamicPa, commandType: System.Data.CommandType.StoredProcedure);
                if (x != null)
                {
                    callingNumber = x.Number + 1;
                }

                // kiem tra stt 
                var x1 = await GetExamNumberAndCalling(roomCode, callingNumber);
                if (x1 == null)
                {
                    return null;
                }
                var examOrdinal = await _context.ExaminationOrdinals.FirstOrDefaultAsync(x => x.Id == x1.Id);
                examOrdinal.Status = Shared.Constant.Calling.CALLED.ToString();
                examOrdinal.UpdatedAt = DateTime.Now;
                examOrdinal.CallingNumber = callingNumber;
                _context.ExaminationOrdinals.Update(examOrdinal);
                await _context.SaveChangesAsync();

                return new BaseCallingOrdinal()
                {
                    Id = examOrdinal.Id,
                    DoorCode = x1.DoorCode,
                    Number = x1.Number,
                    CallingNumber = callingNumber,
                };
            }
        }

        public async Task<ExaminationCallingUserResponse> WindowExamCallingNumber(string[] roomCodes)
        {
            var rs = new ExaminationCallingUserResponse();
            using (var con = _dapperContext.CreateConnection())
            {
                foreach (var code in roomCodes)
                {
                    var procNam = "sp_get_checkin_calling_number";
                    using (var multi = await con.QueryMultipleAsync(procNam, commandType: System.Data.CommandType.StoredProcedure))
                    {
                        var r1 = await multi.ReadFirstOrDefaultAsync<BaseWindowDisplayNumberResponse>();
                        var r2 = await multi.ReadFirstOrDefaultAsync<BaseWindowDisplayNumberResponse>();
                        var r3 = multi.Read<BaseWindowDisplayNumberResponse>().ToList();
                        var r4 = multi.Read<BaseWindowDisplayNumberResponse>().ToList();

                        if (r1 != null)
                        {
                            rs.Doctor = r1;
                        }

                        if (r2 != null)
                        {
                            rs.Called = r2;
                        }

                        if (r3 != null)
                        {
                            rs.Waiting = r3;
                        }

                        if (r4 != null)
                        {
                            rs.Waiting = r4;
                        }
                    }
                }
            }
            return rs;
        }
         
    }
}
