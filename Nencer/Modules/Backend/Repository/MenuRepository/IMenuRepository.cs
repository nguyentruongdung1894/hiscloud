using Nencer.Modules.Backend.Model.Menu;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.MenuRepository;

    public interface IMenuRepository
    {
    Task<BaseResponse<Menu>> CreatedMenuAsync(Menu menu);

    Task<BaseResponse<Menu>> UpdatedMenuAsync(Menu menu);

    Task<BaseResponse<object?>> DeletedMenuAsync(long id);

    Task<List<Menu>> GetListMenuAsync(string? filter = "", int page = 0, int pageSize = 10);
}

