using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Nencer.Modules.Room.Model;
using Nencer.Modules.Room.Model.Dto;
using Nencer.Modules.Room.Repository;
using Nencer.Modules.Users.Repository;
using Nencer.Resources;
using Nencer.Shared;

namespace Nencer.Modules.Room.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;
        private readonly IStringLocalizer<NencerResource> localizer;
        private readonly IDepartmentRepository departmentRepository;

        public RoomController(IRoomRepository roomRepository, IStringLocalizer<NencerResource> localizer,IDepartmentRepository departmentRepository)
        {
            this.roomRepository = roomRepository;
            this.localizer = localizer;
            this.departmentRepository = departmentRepository;
        }

        [HttpGet("GetRoomNumberByRoomId/{roomId}")]
        public async Task<BaseResponse<List<Model.Room>>> GetUsersAsync(string? roomId)
        {
            // validate
            if (roomId == null || roomId.Equals("null"))
            {
                return new BaseResponse<List<Model.Room>>
                {
                    Message = localizer["202"].Value,
                    ResponseCode = "202",
                };
            }

            var item = await roomRepository.GetRoomNumberByRoomId(roomId);
            return new BaseResponse<List<Model.Room>>
            {
                Message = "",
                ResponseCode = "00",
                Data = item
            };
        }

        [HttpGet("GetRoomByDepartment/{departmentId}")]
        public async Task<List<Model.Room>> GetRoomByDepartment(int departmentId)
        {
            return await roomRepository.GetRoomByDepartment(departmentId);
        }
        
        [HttpPost("Create")]
        public async Task<BaseResponse<Model.Room>> CreateRoomAsync(RoomFormDto request)
        {
            return await roomRepository.CreateRoomAsync(request);
        }
        [HttpPut("Update/{id}")]
        public async Task<BaseResponse<Model.Room>> UpdateRoomAsync(RoomFormDto request, int Id)
        {
            return await roomRepository.UpdateRoomAsync(request, Id);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<BaseResponse<Model.Room>> DeleteRoomAsync(int Id)
        {
            return await roomRepository.DeleteRoomAsync(Id);
        }
        // start Department
        [HttpGet("Department/GetAll")]
        public async Task<List<Department>> GetAllDepartment()
        {
            return await departmentRepository.GetAllDepartment();
        }
        [HttpPost("Department/Create")]
        public async Task<BaseResponse<Department>> CreateDepartmentAsync(DepartmentFormDto department)
        {
            return await departmentRepository.CreateDepartmentAsync(department);
        }
        [HttpPut("Department/Update/{id}")]
        public async Task<BaseResponse<Department>> UpdateDepartmentAsync(DepartmentFormDto department, int Id)
        {
            return await departmentRepository.UpdateDepartmentAsync(department, Id);
        }
        [HttpDelete("Department/Delete/{id}")]
        public async Task<BaseResponse<Department>> DeleteDepartmentAsync(int Id)
        {
            return await departmentRepository.DeleteDepartmentAsync(Id);
        }
        [HttpGet("Department/Find/{id}")]
        public async Task<BaseResponse<Department>> FindDepartmentAsync(int Id)
        {
            return await departmentRepository.FindDepartmentAsync(Id);
        }
        // end Department
    }
}
