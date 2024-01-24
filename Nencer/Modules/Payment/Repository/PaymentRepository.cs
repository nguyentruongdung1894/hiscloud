using Dapper;
using Nencer.Helpers;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Patient.Model;
using static Nencer.Shared.Constant;
using System.Data;
using Nencer.Modules.Payment.Model.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Nencer.Modules.Examination.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace Nencer.Modules.Payment.Repository
{
    public interface IPaymentRepository
    {
        //Task<List<CheckinResponse>> GetCheckinPayment(int page, int pageSize, string? name, string? patinalNumber, int? id, int? idType, string? fromDate, string? toDate);
        Task<PaymentOrderResponse> GetExamOrder(int examId);
        Task<PaymentAmount> GetPaymentAmount(int examId);
    }
    public class PaymentRepository : IPaymentRepository
    {
        private readonly NencerDbContext _context;
        private readonly DapperContext _dapperContext;

        public PaymentRepository(NencerDbContext context, DapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task<PaymentOrderResponse> GetExamOrder(int examId)
        {
            var rs = new PaymentOrderResponse();
            rs.ExaminationOrders = await _context.ExaminationOrders.Where(x => x.ExaminationId == examId).ToListAsync();

            return rs;
        }

        public async Task<PaymentAmount> GetPaymentAmount(int examId)
        {
            using (var conn = _dapperContext.CreateConnection())
            {
                var procName = "sp_get_payment_payment_amount";
                var param = new DynamicParameters();
                param.Add("P_EXAM_ID", examId);
                return await conn.QueryFirstOrDefaultAsync<PaymentAmount>(procName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        //public async Task<List<CheckinResponse>> GetCheckinPayment(int page, int pageSize, string? name, string? patinalNumber, int? id, int? idType, string? fromDate, string? toDate)
        //{
        //    DateTime? f = ApiHelper.SafeToDate2(fromDate);
        //    DateTime? t = ApiHelper.SafeToDate2(toDate);
        //    using (var conn = _dapperContext.CreateConnection())
        //    {
        //        var procName = "sp_search_checkin";
        //        var param = new DynamicParameters();
        //        param.Add("P_PAGE", page);
        //        param.Add("P_SIZE", pageSize);
        //        param.Add("P_ID", id);
        //        param.Add("P_NAME", name);
        //        param.Add("P_STATUS", status);
        //        param.Add("P_PATIENT_ID", patientId);
        //        param.Add("P_PATIENT_NUMBER", patientNumber);
        //        param.Add("P_ID_TYPE", idType);
        //        param.Add("P_FROM_DATE", f);
        //        param.Add("P_TO_DATE", t);

        //        var result = await conn
        //                 .QueryAsync<CheckinResponse>(procName, param, commandType: CommandType.StoredProcedure);
        //        if (result != null)
        //        {
        //            return result.ToList();
        //        }
        //        return null;
        //    }
        //}
    }
}
