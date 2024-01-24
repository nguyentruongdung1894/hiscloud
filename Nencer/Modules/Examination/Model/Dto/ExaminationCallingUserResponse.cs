using Nencer.Shared;

namespace Nencer.Modules.Examination.Model.Dto
{
    public class ExaminationCallingUserResponse
    {
        public BaseWindowDisplayNumberResponse Doctor { get; set; }
        public BaseWindowDisplayNumberResponse Called { get; set; }
        public List<BaseWindowDisplayNumberResponse> Waiting { get; set; }
        public List<BaseWindowDisplayNumberResponse> LisRis { get; set; }

    }
}
