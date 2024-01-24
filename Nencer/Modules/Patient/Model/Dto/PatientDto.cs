namespace Nencer.Modules.Patient.Model.Dto
{
    public class PatientDto
    {
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? IdCardType { get; set; }
        public string? PatientNumber { get; set; }
        public string? IdCard { get; set; }
        public string? Gender { get; set; }
        public string? DayBorn { get; set; }
        public string? MonthBorn { get; set; }
        public string? YearBorn { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public int? PartnerId { get; set; }
        public string? Address { get; set; }
        public string? CountryCode { get; set; }
        public string? Nationality { get; set; }
        public string? Ethnic { get; set; }
        public string? DetailObject { get; set; }
        public string? JobTitle { get; set; }
    }
}