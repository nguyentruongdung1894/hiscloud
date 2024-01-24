using Dapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Modules.Examination.Model;

namespace Nencer.Modules.Patient.Repository
{
    public interface IExaminationBarcodeRepository
    {
        Task<int> GenerateBarcode(int maxNumber);
    }

    public class ExaminationBarcodeRepository : IExaminationBarcodeRepository
    {
        private readonly DapperContext _dapperContext;

        public ExaminationBarcodeRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> GenerateBarcode(int maxNumber)
        {
            int num = 1;
            using (var con = _dapperContext.CreateConnection())
            {
                var procNam = "sp_generate_barcode";
                var dynamicPa = new DynamicParameters();
                dynamicPa.Add("P_MAX_NUM", maxNumber, System.Data.DbType.Int64, System.Data.ParameterDirection.Input);

                var x = await con.QueryFirstOrDefaultAsync<OrdinalModel>(procNam, dynamicPa, commandType: System.Data.CommandType.StoredProcedure);
                if (x != null && x.Number > 0)
                {
                    num = x.Number + 1;
                }
                return num;
            }
        }
    }
}
