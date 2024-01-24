using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Patient.Model;
/// <summary>
/// Thông tin bệnh nhân
/// </summary>
[Table("patients")]
public partial class Patient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("id_card_type")]
    public string? IdCardType { get; set; }

    [Column("patient_number")]
    public string? PatientNumber { get; set; }

    [Column("credit")]
    public decimal? Credit { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("id_card")]
    public string? IdCard { get; set; }

    [Column("issue_date")]
    public DateTime? IssueDate { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("gender")]
    public string? Gender { get; set; }

    [Column("day_born")]
    public string? DayBorn { get; set; }

    [Column("month_born")]
    public string? MonthBorn { get; set; }

    [Column("year_born")]
    public string? YearBorn { get; set; }

    [Column("birthday")]
    public DateTime? Birthday { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("city_id")]
    public int? CityId { get; set; }

    [Column("district_id")]
    public int? DistrictId { get; set; }

    [Column("ward_id")]
    public int? WardId { get; set; }

    [Column("partner_id")]
    public int? PartnerId { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("country_code")]
    public string? CountryCode { get; set; }

    [Column("nationality")]
    public string? Nationality { get; set; }

    [Column("post_code")]
    public string? PostCode { get; set; }

    [Column("ethnic")]
    public string? Ethnic { get; set; }

    [Column("detail_object")]
    public string? DetailObject { get; set; }

    [Column("job_title")]
    public string? JobTitle { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
