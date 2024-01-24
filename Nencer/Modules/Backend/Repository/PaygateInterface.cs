using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Backend.Model;
using Nencer.Modules.Backend.Model.Dto;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository
{
    public interface PaygateInterface
    {

        Task<List<Paygate>> GetPaygateAsync(string? filter, int skipCount= 0, int maxResultCount = 10);

        Task<Paygate> GetPaygate(long id);

        Task<BaseResponse<Paygate>> UpdatePaygate(long id, PaygateUpdateDto paygate);
        Task<BaseResponse<Paygate>> CreatePaygate(PaygateCreateDto paygate);
        Task<BaseResponse<object?>> DeletePaygate(long id);
    }
}
