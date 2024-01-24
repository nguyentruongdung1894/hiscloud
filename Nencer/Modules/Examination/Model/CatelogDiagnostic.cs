using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Examination.Model
{
    [Table("catalog_diagnostic")]
    public class CatelogDiagnostic
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? NameEn { get; set; }
        public int Staus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt {  get; set; } = DateTime.Now;
    }
}
