using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Examination.Model
{
    [Table("examination_diagnostic")]
    public partial class ExaminationDiagnostic
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        [Column("object_id")]
        public int ObjectId { get; set; }
        [Column("diagnostic_id")]
        public int DiagnosticId { get; set; }
        [Column("is_primary")]
        public int? IsPrimary { get; set; } = 0;
    }
}
