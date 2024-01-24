using Nencer.Modules.Backend.Model.Language;
using Nencer.Modules.Backend.Model.LanguagesTrans;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.LanguagesTransRepository;

public interface ILanguagesTransRepository
{
    Task<BaseResponse<LanguagesTrans>> CreatedLanguagesTransAsync(LanguagesTrans languagesTrans);

    Task<BaseResponse<LanguagesTrans>> UpdatedLanguagesTransAsync(LanguagesTrans languagesTrans);

    Task<BaseResponse<object?>> DeletedLanguagesTransAsync(int id);

    Task<List<LanguagesTrans>> GetListLanguagesTransAsync(string? filter = "", int page = 0, int pageSize = 10);
}