using Dapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Modules.ManageService.Repository;
using Nencer.Shared;
using NuGet.Protocol;

namespace Nencer.Modules.Examination.Repository;

public class ExaminationOrderRepository : IExaminationOrderRepository
{
    private readonly NencerDbContext _context;
    private readonly DapperContext _dapperContext;
    private readonly IServiceRepository _serviceRepository;
    public ExaminationOrderRepository(DapperContext dapperContext, NencerDbContext context, IServiceRepository serviceRepository)
    {
        _dapperContext = dapperContext;
        _context = context;
        _serviceRepository = serviceRepository;
    }

    public async Task<BaseResponse<List<OrderExaminationDto>>> CreatedTicketOrderAsync(OrderCreateDto request, string auth)
    {

        // get patient
        return new BaseResponse<List<OrderExaminationDto>>
        {
            ResponseCode = "500",
            Message = "Dữ liệu Service không đúng!"
        };
    }
    // create order service 
    public async Task<object> CreateExaminationOrder(CreateOrderExamination rq)
    {
        try
        {
            using (var _context = new NencerDbContext())
            {
                if(rq.service == null || rq.examinationTicket == null)
                {
                    return "DATA_NOT_FOUND";
                }

                dynamic listprice = await _serviceRepository.GetPriceByObjectService(rq.service,(rq.ServiceObject ?? "MEDICAL_FEE"), rq.Qty);
             
                var order = new ExaminationOrder();
                order.TicketId = rq.examinationTicket.Id;
                order.ExaminationId = rq.examinationTicket.ExaminationId;
                order.ParentId = rq.ParentId.GetValueOrDefault();
                order.PatientId = rq.examinationTicket.PatientId;
                order.ServiceId = rq.service.Id;
                order.ServiceCode = rq.service.Code;
                order.ServiceName = rq.service.Name;
                order.ServiceGroupId = rq.service.ServiceGroupId;
                order.InvoiceId = rq.InvoiceId.GetValueOrDefault();
                order.Qty = rq.Qty;
                order.Unit = rq.service.Unit;
                order.ServiceObject = rq.ServiceObject;
                order.Price = listprice.price;
                order.InsurancePay = listprice.priceIns;
                order.TotalAmount = listprice.total;
                order.CopayPatient = order.TotalAmount - order.InsurancePay;
                order.PaymentStatus = "UNPAID";
                order.Status = "PENDING";
                order.CreatedAt = DateTime.Now;
                await _context.ExaminationOrder.AddAsync(order);
                await _context.SaveChangesAsync();
                return order;
            }
        }
        catch (Exception ex)
        {
            return null;
        }

    }

    public async Task<BaseResponse<List<OrderExaminationDto>>> GetListOrderService(string barcode = "", int ticketId = 0)
    {
        if (ticketId == 0 && barcode == "")
        {
            return new BaseResponse<List<OrderExaminationDto>>
            {
                ResponseCode = "500",
                Message = "Dữ liệu không hợp lệ",
                Data = null
            };
        }

        if (ticketId > 0)
        {
            var orders = await _context.ExaminationOrder.Where(x => x.TicketId == ticketId && x.ParentId == 0).Select(x => new OrderExaminationDto
            {
                Id = x.Id,
                TicketId = x.TicketId,
                PatientId = x.PatientId,
                ServiceId = x.ServiceId,
                ServiceName = x.ServiceName,
                ServiceCode = x.ServiceCode,
                ServiceGroupId = x.ServiceGroupId,
                Price = x.Price,
                Qty = x.Qty,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).ToListAsync();
            if (orders != null && orders.Count > 0)
            {
                return new BaseResponse<List<OrderExaminationDto>>
                {
                    ResponseCode = "200",
                    Message = "Lấy dữ liệu thành công",
                    Data = orders
                };
            }
            else
            {
                return new BaseResponse<List<OrderExaminationDto>>
                {
                    ResponseCode = "500",
                    Message = "Không tìm thấy dữ liệu",
                    Data = null
                };
            }

        }
        else
        {
            var ticket = await _context.ExaminationTicket.FirstOrDefaultAsync(x => x.Barcode == barcode);
            if (ticket != null)
            {
                var orders = await _context.ExaminationOrder.Where(x => x.TicketId == ticket.Id && x.ParentId == 0).Select(x => new OrderExaminationDto
                {
                    Id = x.Id,
                    TicketId = x.TicketId,
                    PatientId = x.PatientId,
                    ServiceId = x.ServiceId,
                    ServiceName = x.ServiceName,
                    ServiceCode = x.ServiceCode,
                    ServiceGroupId = x.ServiceGroupId,
                    Price = x.Price,
                    Qty = x.Qty,
                    TotalAmount = x.TotalAmount,
                    Status = x.Status,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                }).ToListAsync();
                if (orders != null && orders.Count > 0)
                {
                    return new BaseResponse<List<OrderExaminationDto>>
                    {
                        ResponseCode = "200",
                        Message = "Lấy dữ liệu thành công",
                        Data = orders
                    };
                }
            }
            return new BaseResponse<List<OrderExaminationDto>>
            {
                ResponseCode = "500",
                Message = "Không tìm thấy dữ liệu",

            };

        }
    }

    public async Task<BaseResponse<OrderExaminationDto>> CancelOrderService(long Id)
    {
        var order = await _context.ExaminationOrder.FirstOrDefaultAsync(x => x.Id == Id && x.Status == "PENDING" && x.PaymentStatus == "UNPAID");
        if (order != null)
        {
            order.Status = "CANCELED";
            _context.ExaminationOrder.Update(order);
            _context.SaveChanges();
            var items = await _context.ExaminationOrder.Where(x => x.ParentId == order.Id).ToListAsync();
            if (items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.Status = "CANCELED";
                    _context.ExaminationOrder.Update(item);
                    _context.SaveChanges();
                }
            }
            var list = _context.ExaminationOrder.Select(x => new OrderExaminationDto
            {
                Id = x.Id,
                TicketId = x.TicketId,
                PatientId = x.PatientId,
                ServiceId = x.ServiceId,
                ServiceName = x.ServiceName,
                ServiceCode = x.ServiceCode,
                ServiceGroupId = x.ServiceGroupId,
                Price = x.Price,
                Qty = x.Qty,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).FirstOrDefault(x => x.Id == Id);

            return new BaseResponse<OrderExaminationDto>
            {
                ResponseCode = "200",
                Message = "Hủy dịch vụ thành công",
                Data = list
            };

        }
        return new BaseResponse<OrderExaminationDto>
        {
            ResponseCode = "500",
            Message = "Không tìm thấy dịch vụ",

        };
    }

    public async Task<BaseResponse<OrderExaminationDto>> UpdateOrderService(long Id, int Qty = 1, string Description = "")
    {

        var order = await _context.ExaminationOrder.FirstOrDefaultAsync(x => x.Id == Id && x.Status == "PENDING" && x.PaymentStatus == "UNPAID");
        if (order != null)
        {
            order.Description = Description;
            if (Qty > 0)
            {
                order.Qty = Qty;
                order.TotalAmount = Qty * order.Price;
                order.TotalAmount = Qty * order.Price;
                order.CopayPatient = Qty * order.Price;
                order.PatientInDebt = order.CopayPatient - order.PatientPaid;
                var items = _context.ExaminationOrder.Where(x => x.ParentId == order.Id).ToList();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        item.Qty = Qty;
                        _context.ExaminationOrder.Update(item);
                        _context.SaveChanges();
                    }
                }
            }
            _context.ExaminationOrder.Update(order);
            _context.SaveChanges();
            var list = _context.ExaminationOrder.Select(x => new OrderExaminationDto
            {
                Id = x.Id,
                TicketId = x.TicketId,
                PatientId = x.PatientId,
                ServiceId = x.ServiceId,
                ServiceName = x.ServiceName,
                ServiceCode = x.ServiceCode,
                ServiceGroupId = x.ServiceGroupId,
                Price = x.Price,
                Qty = x.Qty,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).FirstOrDefault(x => x.Id == Id);
            return new BaseResponse<OrderExaminationDto>
            {
                ResponseCode = "200",
                Message = "Cập nhập dịch vụ thành công",
                Data = list

            };
        }

        return new BaseResponse<OrderExaminationDto>
        {
            ResponseCode = "500",
            Message = "Không tìm thấy dịch vụ",
        };

    }

    public async Task<BaseResponse<OrderExaminationDto>> DeleteOderService(long Id)
    {
        var order = await _context.ExaminationOrder.FirstOrDefaultAsync(x => x.Id == Id && x.Status == "PENDING" && x.PaymentStatus == "UNPAID");
        if (order != null)
        {
            try
            {
                var trans = _context.Database.BeginTransaction();
                // delete service items
                var items = await _context.ExaminationOrder.Where(x => x.ParentId == Id).ToListAsync();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        _context.ExaminationOrder.Remove(item);
                        _context.SaveChanges();
                    }
                }
                _context.ExaminationOrder.Remove(order);
                _context.SaveChanges();
                trans.Commit();
                return new BaseResponse<OrderExaminationDto>
                {
                    ResponseCode = "200",
                    Message = "Xóa dịch vụ thành công",

                };
            }
            catch (Exception ex)
            {

            }

        }
        return new BaseResponse<OrderExaminationDto>
        {
            ResponseCode = "500",
            Message = "Không tìm thấy dịch vụ",

        };
    }
    public async Task<int> GenerateExamOrdinal(int maxNumber, string roomCode)
    {
        int num = 1;
        using (var con = _dapperContext.CreateConnection())
        {
            var procNam = "sp_generate_exam_ordinal";
            var dynamicPa = new DynamicParameters();
            dynamicPa.Add("P_MAX_NUMBER", maxNumber);
            dynamicPa.Add("P_ROOM_CODE", roomCode);

            var x = await con.QueryFirstOrDefaultAsync<OrdinalModel>(procNam, dynamicPa, commandType: System.Data.CommandType.StoredProcedure);
            if (x != null && x.Number > 0)
            {
                num = x.Number + 1;
            }
            return num;
        }
    }

    public async Task<int> HavingOrderServicePayment(int examId, string status)
    {
        return await _context.ExaminationOrders.CountAsync(x => x.Id == examId && x.Status == status);
    }
   
}

