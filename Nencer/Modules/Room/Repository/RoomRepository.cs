
using Dapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Room.Model;
using Nencer.Modules.Room.Model.Dto;
using Nencer.Modules.Users.Model;
using Nencer.Shared;
using System.Data;

namespace Nencer.Modules.Room.Repository
{
    public interface IRoomRepository
    {
        Task<Model.Room> GetById(int id);
        Task<Model.Room> GetByCode(string code);
        Task<List<Model.Room>> GetRoomNumberByRoomId(string roomId, int status = 1);
        Task<List<Model.Room>> GetRoomByDepartment(int departmentId);
        Task<BaseResponse<Model.Room>> CreateRoomAsync(RoomFormDto request);
        Task<BaseResponse<Model.Room>> UpdateRoomAsync(RoomFormDto request, int Id);
        Task<BaseResponse<Model.Room>> DeleteRoomAsync(int Id);
    }
    public class RoomRepository : IRoomRepository
    {
        private readonly NencerDbContext _context;
        private readonly DapperContext _dapperContext;

        public RoomRepository(NencerDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task<Model.Room> GetByCode(string code)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Model.Room> GetById(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Model.Room>> GetRoomNumberByRoomId(string roomId, int status = 1)
        {
            using (var conn = _dapperContext.CreateConnection())
            {
                var procName = "sp_get_room_by_room_id";
                var param = new DynamicParameters();
                param.Add("P_ROOM_ID", roomId, DbType.String, ParameterDirection.Input);

                var rs = await conn.QueryAsync<Model.Room>(procName, param, commandType: CommandType.StoredProcedure);
                return rs.ToList();
            }
        }

        public async Task<List<Model.Room>> GetRoomByDepartment(int departmentId)
        {
            return await _context.Rooms.Where(x => (departmentId == -1 || x.DepartmentId == departmentId) && x.Status == 1).ToListAsync();
        }

        public async Task<BaseResponse<Model.Room>> CreateRoomAsync(RoomFormDto request)
        {
            var old = await _context.Rooms.FirstOrDefaultAsync(x => x.Code == request.Code.ToUpper());
            if(old != null)
            {
                return new BaseResponse<Model.Room>
                {
                    ResponseCode = "500",
                    Message = "Mã phòng đã tồn tại trong hệ thống!"
                };
            }
            var RoomType = request.RoomType;
            if(RoomType != null && RoomType > 0)
            {
                var room_type = await _context.RoomTypes.FindAsync(RoomType);
                if(room_type == null)
                {
                    return new BaseResponse<Model.Room>
                    {
                        ResponseCode = "500",
                        Message = "Mã loại phòng không tồn tại trong hệ thống!"
                    };
                }
            }
            var DepartmentId = request.DepartmentId;
            if(DepartmentId != null && DepartmentId > 0)
            {
                var department = await _context.Departments.FindAsync(DepartmentId);
                if(department == null)
                {
                    return new BaseResponse<Model.Room>
                    {
                        ResponseCode = "500",
                        Message = "Mã khoa không tồn tại trong hệ thống!"
                    };
                }
            }
            var nc = new Model.Room();
            nc.Name = request.Name;
            nc.NameArray = request.NameArray;
            nc.Code = request.Code.ToUpper();
            nc.RoomType = RoomType;
            nc.DepartmentId = DepartmentId;
            nc.Status = request.Status;
            nc.Sort = request.Sort;
            nc.Sort = request.Sort;
            nc.HospitalId = request.HospitalId;
            nc.LocationId = request.LocationId;
            nc.AcceptInsurance = request.AcceptInsurance;
            nc.Polyclinic = request.Polyclinic;
            nc.BigClinic = request.BigClinic;
            nc.CreatedAt = DateTime.Now;
            nc.UpdatedAt = DateTime.Now;
            await _context.Rooms.AddAsync(nc);
            await _context.SaveChangesAsync();
            return new BaseResponse<Model.Room>
            {
                ResponseCode = "200",
                Message = "Thêm dữ liệu thành công",
                Data = nc
            };
        }
        public async Task<BaseResponse<Model.Room>> UpdateRoomAsync(RoomFormDto request, int Id)
        {
            var nc = await _context.Rooms.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<Model.Room>
                {
                    ResponseCode = "500",
                    Message = "Mã phòng không tồn tại trong hệ thống!"
                };
            }
            var RoomType = request.RoomType;
            if (RoomType != null && RoomType > 0)
            {
                var room_type = await _context.RoomTypes.FindAsync(RoomType);
                if (room_type == null)
                {
                    return new BaseResponse<Model.Room>
                    {
                        ResponseCode = "500",
                        Message = "Mã loại phòng không tồn tại trong hệ thống!"
                    };
                }
            }
            var DepartmentId = request.DepartmentId;
            if (DepartmentId != null && DepartmentId > 0)
            {
                var department = await _context.Departments.FindAsync(DepartmentId);
                if (department == null)
                {
                    return new BaseResponse<Model.Room>
                    {
                        ResponseCode = "500",
                        Message = "Mã khoa không tồn tại trong hệ thống!"
                    };
                }
            }
      
            nc.Name = request.Name;
            nc.NameArray = request.NameArray;
            nc.RoomType = RoomType;
            nc.DepartmentId = DepartmentId;
            nc.Status = request.Status;
            nc.Sort = request.Sort;
            nc.Sort = request.Sort;
            nc.HospitalId = request.HospitalId;
            nc.LocationId = request.LocationId;
            nc.AcceptInsurance = request.AcceptInsurance;
            nc.Polyclinic = request.Polyclinic;
            nc.BigClinic = request.BigClinic;
            nc.UpdatedAt = DateTime.Now;
             _context.Rooms.Update(nc);
             _context.SaveChanges();
            return new BaseResponse<Model.Room>
            {
                ResponseCode = "200",
                Message = "Cập nhập dữ liệu thành công",
                Data = nc
            };
        }
        public async Task<BaseResponse<Model.Room>> DeleteRoomAsync(int Id)
        {
            var room = await _context.Rooms.FindAsync(Id);
            if (room == null)
            {
                return new BaseResponse<Model.Room>
                {
                    ResponseCode = "500",
                    Message = "Mã phòng không tồn tại trong hệ thống!"
                };
            }
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return new BaseResponse<Model.Room>
            {
                ResponseCode = "200",
                Message = "Xóa dữ liệu thành công",
            };
        }
    }
}
