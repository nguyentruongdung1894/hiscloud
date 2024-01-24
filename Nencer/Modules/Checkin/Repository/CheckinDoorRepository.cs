
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
using System.Data;
using System.Security.Cryptography;
using static Dapper.SqlMapper;
using static Nencer.Shared.Constant;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nencer.Modules.Checkin.Repository
{
    public interface ICheckinDoorRepository
    {
        Task<List<CheckinDoor>> GetAllCheckInDoor();
    }
    public class CheckinDoorRepository : ICheckinDoorRepository
    {
        private readonly NencerDbContext _context;

        private readonly DapperContext _dapperContext;

        public CheckinDoorRepository(NencerDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task<List<CheckinDoor>> GetAllCheckInDoor()
        {
            return await _context.CheckinDoors.ToListAsync();
        }
    }
}
