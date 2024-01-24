using Nencer.Modules.Patient.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nencer.Modules.Checkin.Model.Dto
{
    public class CheckinResponse
    {
        public string Stt { get; set; }
        public string TotalRecord { get; set; }
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Priority { get; set; }
        public string PatientNumber { get; set; }
        public string IdCard { get; set; }
        public string IdCardType { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string DayBord { get; set; }
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Reason { get; set; }
        public string Checkin_number { get; set; }
        public string CheckinTime { get; set; }
        public string Status { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string WardId { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Ethnic { get; set; }
        public string EthnicName { get; set; }
        public string DetailObject { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }

        public PatientInsuranceCard PatientInsuranceCard { get; set; }
        public PatientDetail PatientDetail { get; set; }
        public List<PatientPrehistoric> PatientPrehistorics { get; set; }
        public List<PatientRelation> PatientRelations { get; set; }
    }
}
