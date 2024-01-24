using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model.Language;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.LanguageRepository;

public class LanguageRepository : ILanguageRepository
{
    private readonly NencerDbContext context;

    public LanguageRepository(NencerDbContext context)
    {
        this.context = context;
    }

    public async Task<BaseResponse<Language>> CreatedLanguageAsync(Language language)
    {
        var getLanguage =
            await context.Languages.FirstOrDefaultAsync(x =>
                x.Code.Trim().ToLower().Equals(language.Code.Trim().ToLower()));
        if (getLanguage != null)
        {
            return new BaseResponse<Language>()
            {
                ResponseCode = "404",
                Message = "Code đã tồn tại trong hệ thống!"
            };
        }

        language.CreatedAt = DateTime.Now;
        await context.Languages.AddAsync(language);
        await context.SaveChangesAsync();
        return new BaseResponse<Language>()
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = language
        };
    }

    public async Task<BaseResponse<Language>> UpdatedLanguageAsync(Language language)
    {
        if (language.Id != 0)
        {
            return new BaseResponse<Language>()
            {
                ResponseCode = "404",
                Message = "Id không được để trống!"
            };
        }

        var getLanguageId = await context.Languages.FindAsync(language.Id);
        var getLanguageCode =
            await context.Languages.FirstOrDefaultAsync(x =>
                x.Code.Trim().ToLower().Equals(language.Code.Trim().ToLower()));

        if (getLanguageId == null)
        {
            return new BaseResponse<Language>()
            {
                ResponseCode = "404",
                Message = "Không tồn tại bản ghi trong hệ thống!"
            };
        }

        if (getLanguageCode != null && !getLanguageId.Code.Equals(language.Code))
        {
            return new BaseResponse<Language>()
            {
                ResponseCode = "404",
                Message = "Code đã tồn tại trong hệ thống!"
            };
        }

        getLanguageId.Code = language.Code;
        getLanguageId.Name = language.Name;
        getLanguageId.Charset = language.Charset;
        getLanguageId.Default = language.Default;
        getLanguageId.Flag = language.Flag;
        getLanguageId.Hreflang = language.Hreflang;
        getLanguageId.Sort = language.Sort;
        getLanguageId.Status = language.Status;
        getLanguageId.UpdatedAt = DateTime.Now;

        context.Languages.Update(getLanguageId);
        await context.SaveChangesAsync();

        return new BaseResponse<Language>()
        {
            ResponseCode = "200",
            Message = "Cập nhật thành công!"
        };
    }

    public async Task<BaseResponse<object?>> DeletedLanguageAsync(int id)
    {
        if (id == 0)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "404",
                Message = "Id không được để trống!"
            };
        }

        var getLanguage = await context.Languages.FindAsync(id);
        if (getLanguage == null)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "404",
                Message = "Không tìm thấy bản ghi trong hệ thống!"
            };
        }

        context.Languages.Remove(getLanguage);
        await context.SaveChangesAsync();
        return new BaseResponse<object?>()
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!"
        };
    }

    public async Task<List<Language>> GetListLanguageAsync(string? filter = "", int page = 0, int pageSize = 10)
    {
        return await context.Languages
            .Where(x => string.IsNullOrEmpty(filter) || x.Code.ToLower().Equals(filter.ToLower()))
            .OrderBy(x => x.Id)
            .Skip(page)
            .Take(pageSize)
            .ToListAsync();
    }
}