using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Examination.Model;

/// <summary>
/// Số thứ tự chờ tiếp đón
/// </summary>
[Table("examination_ordinal")]
public partial class ExaminationOrdinal
{
    public int Id { get; set; }

    /// <summary>
    /// So tt
    /// </summary>
    public int? Number { get; set; }

    [Column("room_code")] public string? RoomCode { get; set; }

    [Column("examination_id")] public long? ExaminationId { get; set; }

    [Column("date_time")] public string DateTime { get; set; }
    
    public string? Status { get; set; }

    [Column("calling_number")] public int? CallingNumber { get; set; }

    [Column("created_at")] public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
}
