using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Examination.Model;
using Nencer.Shared;

namespace Nencer.Modules.Examination.Repository;

public class ExaminationTicketRepository : IExaminationTicketRepository
{
    private readonly NencerDbContext _context;

    public ExaminationTicketRepository(NencerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Modules.Examination.Model.ExaminationTicket>> GetAll()
    {
        return await _context.ExaminationTickets.ToListAsync();
    }
    public async Task<BaseResponse<ExaminationTicket>>DeleteTicketById(int id)
    {
        var ticket = await _context.ExaminationTicket.FindAsync(id);
        if (ticket == null)
        {
            return new BaseResponse<ExaminationTicket>()
            {
                ResponseCode = "500",
                Message = "TICKET_NOT_FOUND"
            };
        }
        var check = await _context.ExaminationOrders.Where(x => x.TicketId == id && x.Status != "PENDING").CountAsync();
        if(check > 0)
        {
            return new BaseResponse<ExaminationTicket>()
            {
                ResponseCode = "500",
                Message = "CAN_NOT_DELETE"
            };
        }
        await _context.ExaminationOrders.Where(x => x.TicketId == id).ExecuteDeleteAsync();
        _context.ExaminationTickets.Remove(ticket);
        _context.SaveChanges();
        return new BaseResponse<ExaminationTicket>()
        {
            ResponseCode = "200",
            Message = "SUCCESS"
        };
    }
}
