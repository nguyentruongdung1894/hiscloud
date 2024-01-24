using AutoMapper;
using Nencer.Modules.Room.Model;
using Nencer.Shared;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Room.Model.Dto;

namespace Nencer.Modules.Room.Repository;
public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartment();
    Task<BaseResponse<Department>> CreateDepartmentAsync(DepartmentFormDto departmentFormDto);
    Task<BaseResponse<Department>> UpdateDepartmentAsync(DepartmentFormDto departmentFormDto, int Id);
    Task<BaseResponse<Department>> DeleteDepartmentAsync(int Id);
    Task<BaseResponse<Department>> FindDepartmentAsync(int Id);
}
public class DepartmentRepository : IDepartmentRepository
{
    private readonly NencerDbContext _context;
    private readonly IMapper _mapper;

    public DepartmentRepository(NencerDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<Department>> GetAllDepartment()
    {
        var items = await _context.Departments
            .OrderBy(x => x.Id).ToListAsync();
        return items;
    }
    public async Task<BaseResponse<Department>> CreateDepartmentAsync(DepartmentFormDto request)
    {
        var old = await _context.Departments.FirstOrDefaultAsync(x => x.Code == request.Code.ToUpper());
        if(old != null)
        {
            return new BaseResponse<Department>
            {
                ResponseCode = "500",
                Message = "Mã khoa đã tồn tại trong hệ thống !"
            };
        }

        var nc = new Department();
        nc.Name = request.Name;
        nc.NameEng = request.NameEng;
        nc.NameByt = request.NameByt;
        nc.Code = request.Code.ToUpper();
        nc.Description = request.Description;
        nc.Image = request.Image;
        nc.Manager = request.Manager;
        nc.Phone = request.Phone;
        nc.Email = request.Email;
        nc.Sort = request.Sort;
        nc.Status = request.Status;
        await _context.Departments.AddAsync(nc);
        await _context.SaveChangesAsync();

        return new BaseResponse<Department>
        {
            ResponseCode = "200",
            Message = "Thêm mới dữ liệu thành công!",
            Data = nc
        };
    }
    
    public async Task<BaseResponse<Department>> UpdateDepartmentAsync(DepartmentFormDto request, int Id)
    {
        var nc = await _context.Departments.FindAsync(Id);
        if (nc == null)
        {
            return new BaseResponse<Department>
            {
                ResponseCode = "500",
                Message = "Mã khoa không tồn tại trong hệ thống !"
            };
        }

        nc.Name = request.Name;
        nc.NameEng = request.NameEng;
        nc.NameByt = request.NameByt;
        nc.Description = request.Description;
        nc.Image = request.Image;
        nc.Manager = request.Manager;
        nc.Phone = request.Phone;
        nc.Email = request.Email;
        nc.Sort = request.Sort;
        nc.Status = request.Status;
         _context.Departments.Update(nc);
         _context.SaveChangesAsync();

        return new BaseResponse<Department>
        {
            ResponseCode = "200",
            Message = "Cập nhập dữ liệu thành công!",
            Data = nc
        };
    }
    public async Task<BaseResponse<Department>> DeleteDepartmentAsync(int Id)
    {
        var department = await _context.Departments.FindAsync(Id);
        if(department != null)
        {
            return new BaseResponse<Department>
            {
                ResponseCode = "500",
                Message = "Mã khoa không tồn tại trong hệ thống !"
            };
        }
     //   var room_id = await _context.Rooms.Where(x => x.DepartmentId == Id).ExecuteDeleteAsync();
        return new BaseResponse<Department>
        {
            ResponseCode = "200",
            Message = "Xóa dữ liệu thành công!",
        };
    }

    public async Task<BaseResponse<Department>> FindDepartmentAsync(int Id)
    {
        var department = await _context.Departments.FindAsync(Id);
        if (department != null)
        {
            return new BaseResponse<Department>
            {
                ResponseCode = "500",
                Message = "Mã khoa không tồn tại trong hệ thống !"
            };
        }
        return new BaseResponse<Department>
        {
            ResponseCode = "200",
            Message = "",
            Data = department
        };
    }
}
