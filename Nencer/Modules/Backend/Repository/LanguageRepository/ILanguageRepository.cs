using Nencer.Modules.Backend.Model.Language;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.LanguageRepository;

public interface ILanguageRepository
{
    Task<BaseResponse<Language>> CreatedLanguageAsync(Language language);

    Task<BaseResponse<Language>> UpdatedLanguageAsync(Language language);

    Task<BaseResponse<object?>> DeletedLanguageAsync(int id);

    Task<List<Language>> GetListLanguageAsync(string? filter = "", int page = 0, int pageSize = 10);
}