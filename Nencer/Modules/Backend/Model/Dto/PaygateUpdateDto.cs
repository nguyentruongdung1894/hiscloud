using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Backend.Model.Dto
{
    public class PaygateUpdateDto
    {

        public string CurrencyCode { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

    }
}
