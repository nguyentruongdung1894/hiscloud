using AutoMapper;
using Microsoft.Extensions.Localization;
using Nencer.Helpers;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Repository;
using Nencer.Modules.ManageService.Repository;
using Nencer.Modules.Patient.Repository;
using Nencer.Resources;

namespace Nencer.Modules
{
    public interface ICommon
    {
        Task<string> GetBarcode(long examId);
    }
    public class Common : ICommon
    {
        private readonly NencerDbContext _context;
        private readonly DapperContext _dapperContext;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<NencerResource> _localizer;
        private readonly IExaminationBarcodeRepository _examinationBarcodeRepository;
        public Common(NencerDbContext context,  IMapper mapper, IStringLocalizer<NencerResource> localizer, DapperContext dapperContext, IExaminationBarcodeRepository examinationBarcodeRepository)
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
            _dapperContext = dapperContext;
            _examinationBarcodeRepository = examinationBarcodeRepository;
        }
        public async Task<string> GetBarcode(long examId)
        {

            int max;
            if (!string.IsNullOrWhiteSpace(_localizer["BarCode"].Value) && int.TryParse(_localizer["BarCode"].Value, out int parsedValue))
            {
                max = parsedValue;
            }
            else
            {
                max = 6; // Giá trị mặc định
            }
            try
            {
                int num = await _examinationBarcodeRepository.GenerateBarcode(max);
                string generateBarCode = ApiHelper.GenerateExamOrdinal(num, max);
                await _context.ExaminationBarcodes.AddAsync(new ExaminationBarcode()
                {
                    Number = num,
                    CreatedAt = DateTime.Now,
                    DateTime = generateBarCode,
                    ExaminationId = examId
                });
                await _context.SaveChangesAsync();

                return ApiHelper.GetBarCode(num, max);
            }
            catch (Exception ex)
            {
                Helpers.LogHelper.Error(ex.Message);
                int num = ApiHelper.GetRandomNumber(1, max);
                return ApiHelper.GetBarCode(num, max);
            }
        }
    }
}
