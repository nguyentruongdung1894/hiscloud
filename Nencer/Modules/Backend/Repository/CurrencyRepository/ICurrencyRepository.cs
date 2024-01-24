using Nencer.Modules.Backend.Model.Currency;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository.CurrencyRepository;

public interface ICurrencyRepository
{
     Task<BaseResponse<Currency>> CreatedCurrencyAsync(Currency currency);

     Task<BaseResponse<Currency>> UpdatedCurrencyAsync(Currency currency);

     Task<BaseResponse<object?>> DeletedCurrencyAsync(long id);

     Task<List<Currency>> GetListCurrencyAsync(string? filter = "", int page = 0, int pageSize = 10);

}