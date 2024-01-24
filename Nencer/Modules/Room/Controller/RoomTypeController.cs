using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Nencer.Modules.Room.Model;
using Nencer.Modules.Room.Model.Dto;
using Nencer.Modules.Room.Repository;
using Nencer.Modules.Service.Repository;
using Nencer.Modules.Users.Repository;
using Nencer.Resources;
using Nencer.Shared;

namespace Nencer.Modules.Room.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IStringLocalizer<NencerResource> localizer;

        public RoomTypeController(IRoomRepository roomRepository, IStringLocalizer<NencerResource> localizer, IRoomTypeRepository roomTypeRepository)
        {
            this.roomRepository = roomRepository;
            this.localizer = localizer;
            this.roomTypeRepository = roomTypeRepository;
        }

        [HttpGet("GetRoomType")]
        public async Task<BaseResponse<List<Model.RoomType>>> GetUsersAsync()
        {

            var item = await roomTypeRepository.GetAll();
            return new BaseResponse<List<Model.RoomType>>
            {
                Message = "",
                ResponseCode = "00",
                Data = item
            };
        }
        [HttpPost("RoomType/Create")]
        public async Task<BaseResponse<RoomType>> CreateRoomType(RoomType request)
        {
            return await roomTypeRepository.CreateRoomType(request);
        }
        [HttpPut("RoomType/Update/{id}")]
        public async Task<BaseResponse<RoomType>> UpdateRoomType(RoomType request, int Id)
        {
            return await roomTypeRepository.UpdateRoomType(request, Id);
        }
        [HttpDelete("RoomType/Delete/{id}")]
        public async Task<BaseResponse<RoomType>> DeleteRoomType(int Id)
        {
            return await roomTypeRepository.DeleteRoomType(Id);
        }
    }
}
