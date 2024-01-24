using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model.Dto
{
    public class PaygateCreateDto
    {

        public string CurrencyCode { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? PaygateGroup { get; set; }

    }
}
