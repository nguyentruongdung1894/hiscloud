using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Backend.Model.Setting;
using Nencer.Modules.Backend.Repository.SettingRepository;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Controller;
[Route("api/[controller]")]
[ApiController]
public class SettingController : ControllerBase
{
    private readonly ISettingRepository SettingRepository;

    public SettingController(ISettingRepository settingRepository)
    {
        this.SettingRepository = settingRepository;
    }

    [HttpPost("Created")]
    public async Task<BaseResponse<Setting>> CreadtedSettingAsync(Setting settings)
    {
        return await SettingRepository.CreatedSettingAsync(settings);
    }
    
    [HttpPut("Updated")]
    public async Task<BaseResponse<Setting>> UpdatedSettingAsync(Setting settings)
    {
        return await SettingRepository.UpdatedSettingAsync(settings);
    }

    [HttpDelete("Deleted")]
    public async Task<BaseResponse<object?>> DeletedSettingAsync(int id)
    {
        return await SettingRepository.DeletedSettingAsync(id);
    }

    [HttpGet("GetList")]
    public async Task<BaseResponse<List<Setting>>> GetListSettingAsync(string? filter ,int? page = 0,int? pageSize = 10)
    {
        var search = filter !=null ? filter.Trim() : "";
        if (page >= 1)
        {
            page = (page - 1) * pageSize ;
        }
        var item = await SettingRepository.GetListSettingAsync(search,page.GetValueOrDefault(),pageSize.GetValueOrDefault());
        return new BaseResponse<List<Setting>>()
        {
            ResponseCode = "200",
            Message = "",
            Data = item
        };
    }
}