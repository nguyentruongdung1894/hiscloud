
using Microsoft.AspNetCore.Mvc;
using Nencer.Modules.Backend.Model;
using Nencer.Modules.Backend.Model.Dto;
using Nencer.Modules.Backend.Repository;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Controller

{
    [Route("api/Paygate")]
    [ApiController]
    public class PaygateController : ControllerBase
    {
        private readonly NencerDbContext context;
        private readonly PaygateInterface paygateInterface;
        public PaygateController(PaygateInterface paygateInterface)
        {
            this.paygateInterface = paygateInterface;
        }

        // GET: api/Paygate
        [HttpGet]
        public async Task<List<Paygate>> GetPaygateAsync(string? filter, int? skipCount = 0, int? maxResultCount = 10)
        {
            return await paygateInterface.GetPaygateAsync(filter, skipCount.GetValueOrDefault(), maxResultCount.GetValueOrDefault());
        }

        // GET: api/Paygate/5
        [HttpGet("{id}")]
        public async Task<Paygate> GetPaygate(long id)
        {
            return await paygateInterface.GetPaygate(id);
        }

        // PUT: api/Paygate/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<Paygate>> UpdatePaygate(long id, PaygateUpdateDto paygate)
        {
            return await paygateInterface.UpdatePaygate(id, paygate);

        }

        //// post: api/Paygate
        [HttpPost]
        public async Task<BaseResponse<Paygate>> CreatePaygate(PaygateCreateDto paygate)
        {
            return await paygateInterface.CreatePaygate(paygate);
        }

        // DELETE: api/Paygate/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<object?>> DeletePaygate(long id)
        {
            return await paygateInterface.DeletePaygate(id);
        }

    }
}
