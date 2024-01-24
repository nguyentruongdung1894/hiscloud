using Nencer.Modules.Backend.Model.Slider;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.SliderRepository;

public interface ISliderRepository
{
  
    Task<BaseResponse<Slider>> CreatedSliderAsync(Slider slider);

    Task<BaseResponse<Slider>> UpdatedSliderAsync(Slider slider);

    Task<BaseResponse<object?>> DeletedSliderAsync(long id);

    Task<List<Slider>> GetListSliderAsync(string? filter = "", int page = 0, int pageSize = 10);
}

