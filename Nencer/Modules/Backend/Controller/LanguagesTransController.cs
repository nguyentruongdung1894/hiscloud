using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Backend.Model.Language;
using Nencer.Modules.Backend.Model.LanguagesTrans;
using Nencer.Modules.Backend.Repository.LanguageRepository;
using Nencer.Modules.Backend.Repository.LanguagesTransRepository;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Controller;
[Route("/api/[controller]")]
[ApiController]
public class LanguagesTransController
{
    private readonly ILanguagesTransRepository LanguagesTransRepository;

    public LanguagesTransController(ILanguagesTransRepository languagesTransRepository)
    {
        this.LanguagesTransRepository = languagesTransRepository;
    }
    
    [HttpPost("Created")]
    public async Task<BaseResponse<LanguagesTrans>> CreatedLanguagesTransAsync(LanguagesTrans languagesTrans)
    {
        return await LanguagesTransRepository.CreatedLanguagesTransAsync(languagesTrans);
    }
    
    [HttpPut("Updated")]
    public async Task<BaseResponse<LanguagesTrans>> UpdatedLanguagesTransAsync(LanguagesTrans languagesTrans)
    {
        return await LanguagesTransRepository.UpdatedLanguagesTransAsync(languagesTrans);
    }

    [HttpDelete("Deleted")]
    public async Task<BaseResponse<object?>> DeletedLanguagesTransAsync(int id)
    {
        return await LanguagesTransRepository.DeletedLanguagesTransAsync(id);
    }

    [HttpGet("GetList")]
    public async Task<BaseResponse<List<LanguagesTrans>>> GetListLanguagesTransAsync(string? filter, int? page = 0, int? pageSize = 10)
    {
        var search = !string.IsNullOrEmpty(filter) ? filter : "";
        if (page >= 1)
        {
            page = (page - 1) * pageSize;
        }

        var item = await LanguagesTransRepository.GetListLanguagesTransAsync(search, page.GetValueOrDefault(), pageSize.GetValueOrDefault());
        return new BaseResponse<List<LanguagesTrans>>()
        {
            ResponseCode = "200",
            Message = "",
            Data = item
        };
    }
}