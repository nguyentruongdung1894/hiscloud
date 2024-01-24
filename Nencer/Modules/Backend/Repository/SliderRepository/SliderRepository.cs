using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model.Slider;
using Nencer.Shared;
using System.Drawing;

namespace Nencer.Modules.Backend.Repository.SliderRepository;

public class SliderRepository : ISliderRepository
{
    private readonly NencerDbContext context;

    public SliderRepository(NencerDbContext context)
    {
        this.context = context;
    }
   
    public async Task<BaseResponse<Slider>> CreatedSliderAsync(Slider request)
    {
        request.CreatedAt = DateTime.Now;
        if (request.SliderImage != null)
        {
            byte[] bytes = Convert.FromBase64String(request.SliderImage);
            var filename = DateTime.Now.Ticks.ToString() + ".png";
            string DefaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\Upload\\Image", filename);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image pic = Image.FromStream(ms);
                pic.Save(DefaultImagePath);
                request.SliderImage = "Upload/Image/" + filename;
            }
        }
        await context.Slider.AddAsync(request);
        await context.SaveChangesAsync();
        return new BaseResponse<Slider>
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = request
        };
    }

    public async Task<BaseResponse<object?>> DeletedSliderAsync(long id)
    {
        if (id == 0)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "500",
                Message = "Id không được để trống!",
            };
        }
        var slider = await context.Slider.FindAsync(id);
        if (slider != null)
        {
            context.Slider.Remove(slider);
            await context.SaveChangesAsync();
            return new BaseResponse<object?>()
            {
                Message = "Xóa bản ghi thành công",
                ResponseCode = "200",
            };
        }

        return new BaseResponse<object?>()
        {
            Message = "Không tồn tại bản ghi trên hệ thống!",
            ResponseCode = "500",
        };
    }

    public async Task<List<Slider>> GetListSliderAsync(string? filter = "", int page = 0, int pageSize = 10)
    {
        return await context.Slider
          .Where(x => string.IsNullOrEmpty(filter) || (x.SliderName.Contains(filter) || x.SliderUrl.Contains(filter)))
          .Where(x => x.Status == 1)
          .OrderBy(x => x.Id)
          .Skip(page)
          .Take(pageSize)
          .ToListAsync();
    }

    public async Task<BaseResponse<Slider>> UpdatedSliderAsync(Slider request)
    {
        if (request.Id == 0)
        {
            return new BaseResponse<Slider>()
            {
                ResponseCode = "500",
                Message = "Id không được để trống!",
            };
        }

        var getSlider = await context.Slider.FindAsync(request.Id);
      

        if (getSlider == null)
        {
            return new BaseResponse<Slider>()
            {
                ResponseCode = "500",
                Message = "Không tồn tại bản ghi trong hệ thống!"
            };
        }

        getSlider.SliderText = request.SliderText;
        getSlider.SliderBtnText = request.SliderBtnText;
        getSlider.SliderBtnUrl = request.SliderBtnUrl;
        getSlider.SliderName = request.SliderName;
        getSlider.SortOrder = request.SortOrder;
        getSlider.Status = request.Status;
        getSlider.App = request.App;
        getSlider.Lang = request.Lang;
        getSlider.UpdatedAt = DateTime.Now;
        if (request.SliderImage != null)
        {
            byte[] bytes = Convert.FromBase64String(request.SliderImage);
            var filename = DateTime.Now.Ticks.ToString() + ".png";
            string DefaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\Upload\\Image", filename);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image pic = Image.FromStream(ms);
                pic.Save(DefaultImagePath);
                getSlider.SliderImage = "Upload/Image/" + filename;
            }
        }
        context.Slider.Update(getSlider);
        await context.SaveChangesAsync();
        return new BaseResponse<Slider>()
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = request
        };
    }

}
