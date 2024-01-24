using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Backend.Model.Language;
using Nencer.Modules.Backend.Repository.LanguageRepository;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Controller;
[Route("api/[controller]")]
[ApiController]

public class LanguageController
{   
    private readonly ILanguageRepository LanguageRepository;

    public LanguageController(ILanguageRepository languageRepository)
    {
        LanguageRepository = languageRepository;
    }
    [HttpGet("GetList")]
    public async Task<BaseResponse<List<Language>>> GetListLanguageAsync(string? filter, int? page = 0, int? pageSize = 10)
    {

        var search = !string.IsNullOrEmpty(filter) ? filter : "";
        if (page >= 1)
        {
            page = (page - 1) * pageSize;
        }

        var item = await LanguageRepository.GetListLanguageAsync(search, page.GetValueOrDefault(), pageSize.GetValueOrDefault());
        return new BaseResponse<List<Language>>()
        {
            ResponseCode = "200",
            Message = "",
            Data = item
        };
    }
    [HttpPost("Created")]
    public async Task<BaseResponse<Language>> CreatedLanguageAsync(Language language)
    {
        return await LanguageRepository.CreatedLanguageAsync(language);
    }
    
    [HttpPut("Updated")]
    public async Task<BaseResponse<Language>> UpdatedLanguageAsync(Language language)
    {
        return await LanguageRepository.UpdatedLanguageAsync(language);
    }

    [HttpDelete("Deleted")]
    public async Task<BaseResponse<object?>> DeletedLanguageAsync(int id)
    {
        return await LanguageRepository.DeletedLanguageAsync(id);
    }

   
}