using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model.Menu;
using Nencer.Modules.Backend.Model.Slider;
using Nencer.Shared;
using System.Drawing;

namespace Nencer.Modules.Backend.Repository.MenuRepository;
public class MenuRepository : IMenuRepository
    {
        private readonly NencerDbContext context;

        public MenuRepository(NencerDbContext context)
        {
            this.context = context;
        }

    public async Task<BaseResponse<Menu>> CreatedMenuAsync(Menu menu)
    {
        menu.CreatedAt = DateTime.Now;
       
        await context.Menu.AddAsync(menu);
        await context.SaveChangesAsync();
        return new BaseResponse<Menu>
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = menu
        };
    }
    public async Task<List<Menu>> GetListMenuAsync(string? filter = "", int page = 0, int pageSize = 10)
    {
        return await context.Menu
          .Where(x => string.IsNullOrEmpty(filter) || (x.Name.Contains(filter) || x.MenuType.Contains(filter)))
          .Where(x => x.Status == 1)
          .OrderBy(x => x.Id)
          .Skip(page)
          .Take(pageSize)
          .ToListAsync();
    }
    public async Task<BaseResponse<object?>> DeletedMenuAsync(long id)
    {
        if(id > 0)
        {
            var Menu = await context.Menu.FindAsync(id);
            if(Menu != null)
            {
                context.Menu.Remove(Menu);
                await context.SaveChangesAsync();
                return new BaseResponse<object?>()
                {
                    Message = "Xóa dữ liệu thành công",
                    ResponseCode = "200",

                };
            }
            else
            {
                return new BaseResponse<object?>()
                {
                    Message = "Dữ liệu không tồn tại",
                    ResponseCode = "404",

                };
            }
        }
        else
        {
            return new BaseResponse<object?>()
            {
                Message = "Id không đúng định dạng",
                ResponseCode = "404",

            };
        }
     
    }

    public async Task<BaseResponse<Menu>> UpdatedMenuAsync(Menu menu)
    {
        if(menu.Id > 0)
        {
            var getMenu = await context.Menu.FindAsync(menu.Id);
            if(getMenu != null)
            {
                getMenu.Name = menu.Name;
                getMenu.Url = menu.Url;
                getMenu.MenuType = menu.MenuType;
                getMenu.ParentId = menu.ParentId;
                getMenu.Level = menu.Level;
                getMenu.ChildrenCount = menu.ChildrenCount;
                getMenu.SortOrder = menu.SortOrder;
                getMenu.Status = menu.Status;
                getMenu.Language = menu.Language;
                getMenu.UpdatedAt = DateTime.Now;
                context.Menu.Update(getMenu);
                await context.SaveChangesAsync();
                return new BaseResponse<Menu>
                {
                    ResponseCode = "404",
                    Message = "Dữ liệu không tồn tại",
                    Data = getMenu
                };
            }
            else
            {
                return new BaseResponse<Menu>
                {
                    ResponseCode = "404",
                    Message = "Dữ liệu không tồn tại",
                };
            }
        }
        else
        {
            return new BaseResponse<Menu>
            {
                ResponseCode = "404",
                Message = "Id không tồn tại hoặc không đúng định dạng",
            };
        }
    }
}

