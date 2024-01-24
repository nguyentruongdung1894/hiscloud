using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model.Currency;
using Nencer.Shared;


namespace Nencer.Modules.Backend.Repository.CurrencyRepository;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly NencerDbContext context;

    public CurrencyRepository(NencerDbContext context)
    {
        this.context = context;
    }

    public async Task<BaseResponse<Currency>> CreatedCurrencyAsync(Currency request)
    {
        var getCurrency =
            await context.Currencies.FirstOrDefaultAsync(x => x.Code.ToLower().Trim() == request.Code.ToLower().Trim());
        if (getCurrency != null)
        {
            return new BaseResponse<Currency>
            {
                ResponseCode = "404",
                Message = "Code đã tồn tại trong hệ thống!"
            };
        }

        request.CreatedAt = DateTime.Now;
        await context.Currencies.AddAsync(request);
        await context.SaveChangesAsync();
        return new BaseResponse<Currency>
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = request
        };
    }

    public async Task<BaseResponse<Currency>> UpdatedCurrencyAsync(Currency request)
    {
        if (request.Id == 0)
        {
            return new BaseResponse<Currency>()
            {
                ResponseCode = "404",
                Message = "Id không được để trống!",
            };
        }

        var getCurrencyId = await context.Currencies.FindAsync(request.Id);
        var getCurrencyCode =
            await context.Currencies.FirstOrDefaultAsync(x => x.Code.ToLower().Trim() == request.Code.ToLower().Trim());

        if (getCurrencyId == null)
        {
            return new BaseResponse<Currency>()
            {
                ResponseCode = "404",
                Message = "Không tồn tại bản ghi trong hệ thống!"
            };
        }

        if (getCurrencyCode != null && !getCurrencyId.Code.Equals(request.Code))
        {
            return new BaseResponse<Currency>()
            {
                ResponseCode = "404",
                Message = "Đã tồn tại bản ghi trong hệ thống!",
                Data = getCurrencyCode
            };
        }


        getCurrencyId.Name = request.Name;
        getCurrencyId.Code = request.Code;
        getCurrencyId.Decimal = request.Decimal;
        getCurrencyId.Default = request.Default;
        getCurrencyId.Seperator = request.Seperator;
        getCurrencyId.Sort = request.Sort;
        getCurrencyId.Status = request.Status;
        getCurrencyId.SymbolLeft = request.SymbolLeft;
        getCurrencyId.SymbolRight = request.SymbolRight;
        getCurrencyId.Value = request.Value;
        getCurrencyId.UpdatedAt = DateTime.Now;

        context.Currencies.Update(getCurrencyId);
        await context.SaveChangesAsync();
        return new BaseResponse<Currency>()
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = request
        };
    }

    public async Task<BaseResponse<object?>> DeletedCurrencyAsync(long id)
    {
        if (id == 0)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "404",
                Message = "Id không được để trống!",
            };
        }

        var getCurrency = await context.Currencies.FirstOrDefaultAsync(x => x.Id == id);
        if (getCurrency != null)
        {
            context.Currencies.Remove(getCurrency);
            await context.SaveChangesAsync();
            return new BaseResponse<object?>()
            {
                Message = "Xóa thành công bản ghi!",
                ResponseCode = "200"
            };
        }

        return new BaseResponse<object?>()
        {
            Message = "Không tồn tại bản ghi trên hệ thống!",
            ResponseCode = "404"
        };
    }

    public async Task<List<Currency>> GetListCurrencyAsync(string? filter = "", int page = 0, int pageSize = 10)
    {
        
        return await context.Currencies
            .Where(x => string.IsNullOrEmpty(filter) || (x.Code.Contains(filter) || x.Name.Contains(filter)))
            .OrderBy(x => x.Id)
            .Skip(page)
            .Take(pageSize)
            .ToListAsync();
    }
}