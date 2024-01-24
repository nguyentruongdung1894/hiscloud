using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Backend.Model;
using Nencer.Modules.Backend.Model.Dto;
using Nencer.Modules.Users.Model;
using Nencer.Shared;

namespace Nencer.Modules.Backend.Repository
{
    public class PaygateRepository : PaygateInterface
    {
        private readonly NencerDbContext context;

        public PaygateRepository(NencerDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Paygate>> GetPaygateAsync(string? filter, int skipCount = 0, int maxResultCount = 10)
        {
            return await context.Paygates
                .Where(x => string.IsNullOrEmpty(filter) ? true : x.Name.Contains(filter))
                .Skip((int)skipCount)
                .Take((int)maxResultCount)
                .ToListAsync();
        }

        public async Task<Paygate> GetPaygate(long id)
        {
            return await context.Paygates.FindAsync(id);
        }

        public async Task<BaseResponse<Paygate>> UpdatePaygate(long id, PaygateUpdateDto paygate)
        {

            var editPaygate = await context.Paygates.FindAsync(id);
            editPaygate.Name = paygate.Name;
            editPaygate.CurrencyCode = paygate.CurrencyCode;
            editPaygate.Code = paygate.Code;

            await context.SaveChangesAsync();

            return new BaseResponse<Paygate>
            {
                Data = editPaygate,
                Message = "Success",
                ResponseCode = "200",
            };

        }


        public async Task<BaseResponse<Paygate>> CreatePaygate(PaygateCreateDto paygate)
        {

            var check = await context.Paygates.FirstOrDefaultAsync(x => x.Code.Trim() == paygate.Code.Trim());
            if (check != null)
            {
                return new BaseResponse<Paygate>
                {
                    Message = "Paygate code đã tồn tại!",
                    ResponseCode = "404",
                    Data = check
                };
            }

            var newPaygate = new Paygate();
            newPaygate.Name = paygate.Name;
            newPaygate.Code = paygate.Code;
            newPaygate.CurrencyCode = paygate.CurrencyCode;
            newPaygate.PaygateGroup = paygate.PaygateGroup;
            await context.Paygates.AddAsync(newPaygate);
            await context.SaveChangesAsync();
            return new BaseResponse<Paygate>
            {
                Message = "Thành công!",
                ResponseCode = "200",
                Data = newPaygate
            };

        }


        public async Task<BaseResponse<object?>> DeletePaygate(long id)
        {
            var delPaygate = await context.Paygates.FindAsync(id);
            if (delPaygate != null)
            {
                context.Paygates.Remove(delPaygate);
                await context.SaveChangesAsync();
                return new BaseResponse<object?>
                {
                    Message = "Thành công!",
                    ResponseCode = "200",
                    Data = delPaygate
                };
            }
            return new BaseResponse<object?>
            {
                ResponseCode = "404",
                Message = "Không tìm thấy user!"
            };


        }
    


}
}
