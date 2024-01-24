using Nencer.Modules.Room.Model;
using Microsoft.EntityFrameworkCore;
using Nencer.Shared;
namespace Nencer.Modules.Service.Repository
{
    public interface IRoomTypeRepository
    {
        Task<List<RoomType>> GetAll();
        Task<BaseResponse<RoomType>> CreateRoomType(RoomType roomType);
        Task<BaseResponse<RoomType>> UpdateRoomType(RoomType roomType, int Id);
        Task<BaseResponse<RoomType>> DeleteRoomType(int Id);
        Task<BaseResponse<RoomType>> FindRoomType(int Id);
    }
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly NencerDbContext _context;
        public RoomTypeRepository(NencerDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomType>> GetAll()
        {
            return await _context.RoomTypes.ToListAsync();
        }
        public async Task<BaseResponse<RoomType>> CreateRoomType(RoomType roomType)
        {
            var old = await _context.RoomTypes.FirstOrDefaultAsync(x => x.Code == roomType.Code);
            if(old != null)
            {
                return new BaseResponse<RoomType>
                {
                    ResponseCode = "500",
                    Message = "Mã loại phòng đã tồn tại trong hệ thống!"
                };
            }
            var nc = new RoomType();
            nc.Name = roomType.Name;
            nc.NameArray = roomType.NameArray;
            nc.Code = roomType.Code;
            nc.Status = roomType.Status;
            nc.Sort = roomType.Sort;
            nc.CreatedAt = DateTime.Now;
            nc.UpdatedAt = DateTime.Now;
            await _context.RoomTypes.AddAsync(nc);
            await _context.SaveChangesAsync();
            return new BaseResponse<RoomType>
            {
                ResponseCode = "200",
                Message = "Thêm mới thành công",
                Data = nc
            };
        }
        public async Task<BaseResponse<RoomType>> UpdateRoomType(RoomType roomType, int Id)
        {
            var nc = await _context.RoomTypes.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<RoomType>
                {
                    ResponseCode = "500",
                    Message = "Mã loại phòng không tồn tại trong hệ thống!"
                };
            }
            nc.Name = roomType.Name;
            nc.NameArray = roomType.NameArray;
            nc.Status = roomType.Status;
            nc.Sort = roomType.Sort;
            nc.UpdatedAt = DateTime.Now;
            _context.RoomTypes.Update(nc);
            _context.SaveChanges();
            return new BaseResponse<RoomType>
            {
                ResponseCode = "200",
                Message = "Cập nhập thành công",
                Data = nc
            };
        }
        
        public async Task<BaseResponse<RoomType>> DeleteRoomType(int Id)
        {
            var nc = await _context.RoomTypes.FindAsync(Id);
            if(nc == null)
            {
                return new BaseResponse<RoomType>
                {
                    ResponseCode = "500",
                    Message = "Mã loại phòng không tồn tại trong hệ thống!"
                };
            }
            _context.RoomTypes.Remove(nc);
            _context.SaveChanges();
            return new BaseResponse<RoomType>
            {
                ResponseCode = "200",
                Message = "Xóa thành công",
            };
        }
        public async Task<BaseResponse<RoomType>> FindRoomType(int Id)
        {
            var nc = await _context.RoomTypes.FindAsync(Id);
            if (nc == null)
            {
                return new BaseResponse<RoomType>
                {
                    ResponseCode = "500",
                    Message = "Mã loại phòng không tồn tại trong hệ thống!"
                };
            }
            return new BaseResponse<RoomType>
            {
                ResponseCode = "200",
                Message = "",
                Data = nc
            };
        }
    }
}
