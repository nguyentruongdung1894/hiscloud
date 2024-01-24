using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.ManageService.Model.Dto
{
    public class ServiceModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
         
    }
}
