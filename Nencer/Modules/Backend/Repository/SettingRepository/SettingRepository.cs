using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model.Setting;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.SettingRepository;

public class SettingRepository : ISettingRepository
{
    private readonly NencerDbContext context;

    public SettingRepository(NencerDbContext context)
    {
        this.context = context;
    }

    public async Task<BaseResponse<Setting>> CreatedSettingAsync(Setting setting)
    {
        var gSettings = await context.Settings.FirstOrDefaultAsync(x =>
            string.IsNullOrEmpty(setting.Key) ? true : x.Key.ToLower().Trim() == setting.Key.ToLower().Trim());
        if (gSettings != null)
        {
            return new BaseResponse<Setting>
            {
                ResponseCode = "500",
                Message = "Code đã tồn tại trong hệ thống!"
            };
        }

        setting.CreatedAt = DateTime.Now;
        await context.Settings.AddAsync(setting);
        await context.SaveChangesAsync();
        return new BaseResponse<Setting>
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = setting
        };
    }

    public async Task<BaseResponse<Setting>> UpdatedSettingAsync(Setting setting)
    {
        if (setting.Id == 0)
        {
            return new BaseResponse<Setting>()
            {
                ResponseCode = "500",
                Message = "Id không được để trống!",
            };
        }

        var getSettingId = await context.Settings.FindAsync(setting.Id);
        var getSettingCode = await context.Settings
            .FirstOrDefaultAsync(x => x.Key.ToLower().Trim() == setting.Key.ToLower().Trim());

        if (getSettingId == null)
        {
            return new BaseResponse<Setting>()
            {
                ResponseCode = "500",
                Message = "Không tìm thấy bản ghi trong hệ thống!",
            };
        }

        if (getSettingCode != null && !getSettingId.Key.Equals(setting.Key))
        {
            return new BaseResponse<Setting>()
            {
                ResponseCode = "500",
                Message = "Key đã tồn tại trong hệ thống!",
            };
        }

        getSettingId.Key = setting.Key;
        getSettingId.Value = setting.Value;
        getSettingId.ValueArr = setting.ValueArr;
        getSettingId.Type = setting.Type;
        getSettingId.Status = setting.Status;
        getSettingId.Description = getSettingId.Description;
        getSettingId.UpdatedAt = DateTime.Now;
        context.Settings.Update(getSettingId);
        await context.SaveChangesAsync();

        return new BaseResponse<Setting>()
        {
            ResponseCode = "200",
            Message = "Cập nhật thành công!",
            Data = getSettingId
        };
    }

    public async Task<BaseResponse<object?>> DeletedSettingAsync(int id)
    {
        if (id == 0)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "500",
                Message = "Id không được để trống!",
            };
        }

        var getSetting = await context.Settings.FindAsync(id);
        if (getSetting == null)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "500",
                Message = "Không tìm thấy bản ghi trong hệ thống",
            };
        }

        context.Settings.Remove(getSetting);
        await context.SaveChangesAsync();
        return new BaseResponse<object?>()
        {
            ResponseCode = "200",
            Message = "Xóa thành công bản ghi!",
        };
    }

    public async Task<List<Setting>> GetListSettingAsync(string? filter = "", int page = 0, int pageSize = 10)
    {
        return await context.Settings
            .Where(x => string.IsNullOrEmpty(filter) || x.Key.Contains(filter))
            .OrderBy(x => x.Id)
            .Skip(page)
            .Take(pageSize)
            .ToListAsync();
    }
    
}