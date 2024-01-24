using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Examination.Model;

/// <summary>
/// Số thứ tự chờ tiếp đón
/// </summary>
[Table("examination_barcode")]
public partial class ExaminationBarcode
{
    public int Id { get; set; }

    /// <summary>
    /// So tt
    /// </summary>
    public int? Number { get; set; }

    [Column("examination_id")] public long? ExaminationId { get; set; }

    [Column("date_time")] public string DateTime { get; set; }
    
    [Column("created_at")] public DateTime? CreatedAt { get; set; }

}
