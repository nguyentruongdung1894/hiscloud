using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Shared;

namespace Nencer.Modules.Examination.Repository
{
    public interface IExaminationTicketRepository
    {
        Task<List<ExaminationTicket>> GetAll();
        Task<BaseResponse<ExaminationTicket>> DeleteTicketById(int id);
    }
}
