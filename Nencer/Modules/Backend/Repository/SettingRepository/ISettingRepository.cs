using Nencer.Modules.Backend.Model.Setting;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.SettingRepository;

public interface ISettingRepository
{
    Task<BaseResponse<Setting>> CreatedSettingAsync(Setting setting);

    Task<BaseResponse<Setting>> UpdatedSettingAsync(Setting setting);

    Task<BaseResponse<object?>> DeletedSettingAsync(int id);

    Task<List<Setting>> GetListSettingAsync(string? filter = "", int page = 0, int pageSize = 10);
}