using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Backend.Model.Slider;
using Nencer.Modules.Backend.Repository.SliderRepository;
using Nencer.Shared;
namespace Nencer.Modules.Backend.Controller;

[Route("api/[controller]")]
[ApiController]
public class SliderController
{
    private readonly ISliderRepository _sliderRepository;

    public SliderController(ISliderRepository sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }
    [HttpPost("Created")]
    public async Task<BaseResponse<Slider>> CreatedSliderAsync(Slider slider)
    {
        return await _sliderRepository.CreatedSliderAsync(slider);
    }

    [HttpPut("Updated")]
    public async Task<BaseResponse<Slider>> UpdatedSliderAsync(Slider slider)
    {
        return await _sliderRepository.UpdatedSliderAsync(slider);
    }

    [HttpDelete("Deleted")]
    public async Task<BaseResponse<object?>> DeletedSliderAsync(long id)
    {
        return await _sliderRepository.DeletedSliderAsync(id);
    }

    [HttpGet("GetList")]
    public async Task<BaseResponse<List<Slider>>> GetListSliderAsync(string? filter, int? page = 0, int? pageSize = 10)
    {
        var search = !string.IsNullOrEmpty(filter) ? filter.ToLower().Trim() : "";
        if (page >= 1)
        {
            page = (page - 1) * pageSize;
        }

        var item = await _sliderRepository.GetListSliderAsync(search, page.GetValueOrDefault(), pageSize.GetValueOrDefault());

        return new BaseResponse<List<Slider>>()
        {
            ResponseCode = "200",
            Message = "",
            Data = item
        };

    }
}
