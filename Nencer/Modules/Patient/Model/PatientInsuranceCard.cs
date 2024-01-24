using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// BHYT ứng với bệnh nhân
/// </summary>
[Table("patient_insurance_cards")]
public partial class PatientInsuranceCard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("patient_id")]
    public int? PatientId { get; set; }

    [Column("full_number")]
    public string? FullNumber { get; set; }

    [Column("subject_code")]
    public string SubjectCode { get; set; }

    [Column("benifit_code")]
    public string BenifitCode { get; set; }

    [Column("city_code")]
    public string CityCode { get; set; }

    [Column("region")]
    public string? Region { get; set; }

    [Column("insurance_address")]
    public string? InsuranceAddress { get; set; }

    [Column("from_date")]
    public DateTime? FromDate { get; set; }

    [Column("expiration_date")]
    public DateTime? ExpirationDate { get; set; }

    [Column("status")]
    public string? Status { get; set; } = "valid";

    [Column("note")]
    public string? Note { get; set; }

    [Column("benefit_rate")]
    public int? BenefitRate { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column("line")]
    public string? Line { get; set; }

    [Column("rank")]
    public string? Rank { get; set; }

    [Column("inactive_day")]
    public DateTime? InactiveDay { get; set; }

    [Column("full_date_five_year")]
    public DateTime? FullDateFiveYear { get; set; }
}
