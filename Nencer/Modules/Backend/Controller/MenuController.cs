using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model.Menu;
using Nencer.Modules.Backend.Repository.MenuRepository;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Controller;

public class MenuController
{
    private readonly IMenuRepository _menuRepository;
    private readonly NencerDbContext context;

    public MenuController(IMenuRepository menuRepository, NencerDbContext context)
    {
        _menuRepository = menuRepository;
        this.context = context;
    }
    [HttpPost("Created")]
    public async Task<BaseResponse<Menu>> CreatedMenuAsync(Menu menu)
    {
        return await _menuRepository.CreatedMenuAsync(menu);
    }
    [HttpGet("GetList")]
    public async Task<BaseResponse<List<Menu>>> GetListMenuAsync(string? filter, int? page = 0, int? pageSize = 10)
    {
        var search = !string.IsNullOrEmpty(filter) ? filter.ToLower().Trim() : "";
        if (page >= 1)
        {
            page = (page - 1) * pageSize;
        }

        var item = await _menuRepository.GetListMenuAsync(search, page.GetValueOrDefault(), pageSize.GetValueOrDefault());

        return new BaseResponse<List<Menu>>()
        {
            ResponseCode = "200",
            Message = "",
            Data = item
        };

    }
    [HttpPut("Updated")]
    public async Task<BaseResponse<Menu>> UpdatedMenuAsync(Menu menu)
    {
        return await _menuRepository.UpdatedMenuAsync(menu);
    }

    [HttpDelete("Deleted")]
    public async Task<BaseResponse<object?>> DeletedMenuAsync(long id)
    {
        return await _menuRepository.DeletedMenuAsync(id);
    }

    public async Task<BaseResponse<List<Menu>>> getMenuListBytype(string type, string? language = "vi")
    {
        var search = !string.IsNullOrEmpty(type) ? type.ToLower().Trim() : "";
        var items = await context.Menu
            .Where(x => x.MenuType == search)
            .Where(x => x.Language == language)
            .Where(x => x.Status == 1)
            .Where(x => x.ParentId == 0)
            .OrderBy(x => x.SortOrder)
            .ToListAsync();
        string[] list = new string[] { };
        if (items.Count > 0)
        {
            foreach (var item in items)
            {
                var child = getMenuListArray(item.Id);

                if (child != null)
                {
                    list[item.Id] = item;
                }

            }
        }
        return new BaseResponse<List<Menu>>()
        {
            ResponseCode = "200",
            Message = "",
            Data = items
        };

    }
    public async Task<List<Menu>> getMenuListArray(long pid = 0)
    {
        var items = await context.Menu
            .Where(x => x.ParentId == pid)
            .Where(x => x.Status == 1)
            .OrderBy(x => x.SortOrder)
            .ToListAsync();
        if (items.Count > 0)
        {
            foreach (var item in items)
            {
                var child = getMenuListArray(item.Id);
            }
        }
        return items;
    }
}
