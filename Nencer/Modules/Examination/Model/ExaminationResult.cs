using System.ComponentModel.DataAnnotations.Schema;

namespace Nencer.Modules.Examination.Model
{
    [Table("examination_results")]
    public class ExaminationResult
    {
        public int Id { get; set; }
        [Column("doctor_id")] public int DoctorId { get; set; }
        [Column("examination_id")] public long ExaminationId { get; set; }
        [Column("emergency")] public int? Emergency { get; set; }
        public string? Reason { get; set; }
        public int? Allergy { get; set; }
        [Column("allergy_note")] public string? AllergyNote { get; set; }
        [Column("symptom")] public string? Symptom { get; set; }
        [Column("pathological_process")] public string? PathologicalProcess { get; set; }
        [Column("self_medical_history")] public string? SelfMedicalHistory { get; set; }
        [Column("family_medical_history")] public string? SamilyMedicalHistory { get; set; }
        [Column("exam_note")] public string? ExamNote { get; set; }
        [Column("exam_part")] public string? ExamPart { get; set; }
        [Column("reason_edit")] public string? ReasonEdit { get; set; }
        [Column("resolve_method")] public string? ResolveMethod { get; set; }
        [Column("pulse")] public string? Pulse { get; set; }
        [Column("respiration")] public string? Respiration { get; set; }
        [Column("temperature")] public string? Temperature { get; set; }
        [Column("pressure_min")] public string? PressureMin { get; set; }
        [Column("pressure_max")] public string? PressureMax { get; set; }
        [Column("height")] public string? Height { get; set; }
        [Column("weight")] public string? Weight { get; set; }
        [Column("spO2")] public string? SpO2 { get; set; }
        [Column("bmi")] public string? Bmi { get; set; }
        [Column("initially_result")] public string? InitiallyResult { get; set; }
        [Column("created_at")] public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("updated_at")] public DateTime? UpdatedAt { get; set; } = DateTime.Now;


    }
}
