namespace Nencer.Modules.Examination.Model.Dto
{
    public partial class ExaminationResultDto
    {
        public ExaminationResult examinationResult { get; set; }
        public DiagnosticItem? diagnostic { get; set; }

    }
    public class DiagnosticItem
    {
        public string? Diagnostic { get;set; }
        public string[]? DiagnosticSub { get; set; }
    }
}
