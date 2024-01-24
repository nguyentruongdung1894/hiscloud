using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Chi tiết bệnh nhân
/// </summary>
[Table("patient_details")]
public partial class PatientDetail
{
    public int Id { get; set; }
    [Column("patient_id")]
    public int PatientId { get; set; }

    public string? Address { get; set; }

    /// <summary>
    /// địa chỉ nơi làm việc
    /// </summary>
    [Column("address_workplace")] 
    public string? AddressWorkplace { get; set; }

    public int? Married { get; set; }

    public int? Children { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    /// <summary>
    /// Nghề nghiệp
    /// </summary>
    [Column("job_title")] 
    public string? JobTitle { get; set; }

    public string? Company { get; set; }

    /// <summary>
    /// Học vấn
    /// </summary>
    public string? Education { get; set; }

    /// <summary>
    /// Tiền sử bệnh, Array
    /// </summary>
    public string? Prehistoric { get; set; }
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")] 
    public DateTime? UpdatedAt { get; set; }

}
