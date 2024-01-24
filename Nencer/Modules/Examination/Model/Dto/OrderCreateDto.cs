using Newtonsoft.Json;

namespace Nencer.Modules.Examination.Model.Dto
{
    public class OrderCreateDto
    {
        public string Barcode { get; set; } = null!;
        public string PatientNumber { get; set; } = null!;
        public List<ServiceItem> Service { get; set; }
        public string? Description { get; set; }
    
    }
    public class ServiceItem
    {
        public string Code { get; set; }
        public int Qty { get; set; }
    }
}
