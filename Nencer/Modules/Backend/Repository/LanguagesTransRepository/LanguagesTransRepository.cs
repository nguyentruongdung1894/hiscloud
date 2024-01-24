using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model.Language;
using Nencer.Modules.Backend.Model.LanguagesTrans;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.LanguagesTransRepository;

public class LanguagesTransRepository : ILanguagesTransRepository
{
    private readonly NencerDbContext context;

    public LanguagesTransRepository(NencerDbContext context)
    {
        this.context = context;
    }

    public async Task<BaseResponse<LanguagesTrans>> CreatedLanguagesTransAsync(LanguagesTrans language)
    {
        var getLanguage =
            await context.LanguagesTrans.FirstOrDefaultAsync(x =>
                x.Key.Trim().ToLower().Equals(language.Key.Trim().ToLower()));
        if (getLanguage != null)
        {
            return new BaseResponse<LanguagesTrans>()
            {
                ResponseCode = "404",
                Message = "Key đã tồn tại trong hệ thống!"
            };
        }

        language.CreatedAt = DateTime.Now;
        await context.LanguagesTrans.AddAsync(language);
        await context.SaveChangesAsync();
        return new BaseResponse<LanguagesTrans>()
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!",
            Data = language
        };
    }

    public async Task<BaseResponse<LanguagesTrans>> UpdatedLanguagesTransAsync(LanguagesTrans language)
    {
        if (language.Id != 0)
        {
            return new BaseResponse<LanguagesTrans>()
            {
                ResponseCode = "404",
                Message = "Id không được để trống!"
            };
        }

        var getLanguageId = await context.LanguagesTrans.FindAsync(language.Id);
        var getLanguageCode =
            await context.LanguagesTrans.FirstOrDefaultAsync(x =>
                x.Key.Trim().ToLower().Equals(language.Key.Trim().ToLower()));

        if (getLanguageId == null)
        {
            return new BaseResponse<LanguagesTrans>()
            {
                ResponseCode = "404",
                Message = "Không tồn tại bản ghi trong hệ thống!"
            };
        }

        if (getLanguageCode != null && !getLanguageId.Key.Equals(language.Key))
        {
            return new BaseResponse<LanguagesTrans>()
            {
                ResponseCode = "404",
                Message = "Key đã tồn tại trong hệ thống!"
            };
        }

        getLanguageId.Key = language.Key;
        getLanguageId.LangKey = language.LangKey;
        getLanguageId.LangCode = language.LangCode;
        getLanguageId.Type = language.Type;
        getLanguageId.Content = language.Content;
        getLanguageId.Filename = language.Filename;
        getLanguageId.UpdatedAt = DateTime.Now;

        context.LanguagesTrans.Update(getLanguageId);
        await context.SaveChangesAsync();

        return new BaseResponse<LanguagesTrans>()
        {
            ResponseCode = "200",
            Message = "Cập nhật thành công!"
        };
    }

    public async Task<BaseResponse<object?>> DeletedLanguagesTransAsync(int id)
    {
        if (id == 0)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "404",
                Message = "Id không được để trống!"
            };
        }

        var getLanguage = await context.LanguagesTrans.FindAsync(id);
        if (getLanguage == null)
        {
            return new BaseResponse<object?>()
            {
                ResponseCode = "404",
                Message = "Không tìm thấy bản ghi trong hệ thống!"
            };
        }

        context.LanguagesTrans.Remove(getLanguage);
        await context.SaveChangesAsync();
        return new BaseResponse<object?>()
        {
            ResponseCode = "200",
            Message = "Thêm mới thành công!"
        };
    }

    public async Task<List<LanguagesTrans>> GetListLanguagesTransAsync(string? filter = "", int page = 0,
        int pageSize = 10)
    {
        return await context.LanguagesTrans
            .Where(x => string.IsNullOrEmpty(filter) || x.Key.ToLower().Equals(filter.ToLower()))
            .OrderBy(x => x.Id)
            .Skip(page)
            .Take(pageSize)
            .ToListAsync();
    }
}