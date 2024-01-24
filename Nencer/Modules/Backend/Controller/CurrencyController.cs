using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Backend.Model.Currency;
using Nencer.Modules.Backend.Repository.CurrencyRepository;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Controller;
[Route("api/[controller]")]
[ApiController]
public class CurrencyController
{
    private readonly ICurrencyRepository _currencyRepository;

    public CurrencyController(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    [HttpPost("Created")]
    public async Task<BaseResponse<Currency>> CreatedCurrencyAsync(Currency currency)
    {
        return await _currencyRepository.CreatedCurrencyAsync(currency);
    }

    [HttpPut("Updated")]
    public async Task<BaseResponse<Currency>> UpdatedCurrencyAsync(Currency currency)
    {
        return await _currencyRepository.UpdatedCurrencyAsync(currency);
    }

    [HttpDelete("Deleted")]
    public async Task<BaseResponse<object?>> DeletedCurrencyAsync(long id)
    {
        return await _currencyRepository.DeletedCurrencyAsync(id);
    }

    [HttpGet("GetList")]
    public async Task<BaseResponse<List<Currency>>> GetListCurrencyAsync(string? filter, int? page = 0, int? pageSize = 10)
    {
        var search = !string.IsNullOrEmpty(filter) ? filter.ToLower().Trim() : "";
        if (page >= 1)
        {
            page = (page - 1) * pageSize;
        }

        var item = await _currencyRepository.GetListCurrencyAsync(search, page.GetValueOrDefault(), pageSize.GetValueOrDefault());

        return new BaseResponse<List<Currency>>()
        {
            ResponseCode = "200",
            Message = "",
            Data = item
        };

    }
}