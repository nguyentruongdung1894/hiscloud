using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Model.Dto;
using Nencer.Shared;
using ExaminationModel = Nencer.Modules.Examination.Model.Examination;
namespace Nencer.Modules.Examination.Repository
{
    public interface IExaminationRepository
    {
        Task<List<Examination.Model.Examination>> GetAll();
        Task<List<ListExaminationModel>> GetListExamination(SearchExamination req);
        Task<BaseResponse<ExaminationView>> FindExaminationById(long Id);
        Task<BaseResponse<Modules.Examination.Model.Examination>> ExaminationProcess(long Id);
        Task<BaseResponse<Modules.Examination.Model.Examination>> ExaminationCancel(long Id);
        Task<BaseResponse<ExaminationResult>> SaveExaminationResult(ExaminationResultDto req, int doctorId);
        Task<BaseResponse<ExaminationTicket>> SaveExamninationService(AddServiceDto req, int? doctorId = 1);
        Task<List<ListServiceGroupOrder>> GetServiceGroupOrderByExam(int examId);
    }

    public class ExaminationRepository : IExaminationRepository
    {
        private readonly NencerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDiagnosticRepository _diagnosticRepository;
        private readonly IExaminationOrderRepository _examinationOrderRepository;
        private readonly ICommon _common;

        public ExaminationRepository(NencerDbContext context, IMapper mapper, IDiagnosticRepository diagnosticRepository, IExaminationOrderRepository examinationOrderRepository, ICommon common)
        {
            _context = context;
            _mapper = mapper;
            _diagnosticRepository = diagnosticRepository;
            _examinationOrderRepository = examinationOrderRepository;
            _common = common;

        }

        public async Task<List<Modules.Examination.Model.Examination>> GetAll()
        {
            return await _context.Examinations.ToListAsync();
        }
        public async Task<List<ListExaminationModel>> GetListExamination(SearchExamination req)
        {
            using (var _context = new NencerDbContext())
            {
                var date = req.FromDate.HasValue;

                var lstData = (from examination in _context.Examinations
                               join patient in _context.Patients on examination.PatientId equals patient.Id into joinedPatients
                               from patient in joinedPatients.DefaultIfEmpty()
                               where examination.Status != "NONE"
                               select new ListExaminationModel
                               {
                                   Id = examination.Id,
                                   NameAge = patient.Name + " - " + patient.YearBorn,
                                   Address = patient.Address,
                                   Status = examination.Status,
                                   Time = "1 giờ trước",
                                   PatientNumber = patient.PatientNumber + " - " +
                                                   (examination.Type == "EXAMINATION" ? "Khám bệnh" : "Cấp cứu") + " - " +
                                                   (examination.ServiceObject == "INSURANCE" ? "Bảo hiểm" : "Tính phí"),
                                   CreatedAt = examination.CreatedAt,
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(req.SkipCount)
                               .Take(req.MaxResultCount)
                               .ToList();


                // Then, retrieve the total count separately
                int totalCount = _context.Examinations.Where(x => x.Status != "NONE").Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }
        public async Task<BaseResponse<ExaminationView>> FindExaminationById(long Id)
        {
            var examination = await _context.Examinations.FirstOrDefaultAsync(x => x.Id == Id);
            if (examination == null)
            {
                return new BaseResponse<ExaminationView>
                {
                    ResponseCode = "500",
                    Message = "EXAMINATION_NOT_FOUND"

                };
            }
            var result = await _context.ExaminationResults.FirstOrDefaultAsync(x => x.ExaminationId == examination.Id);
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == examination.PatientId);
            var history = await _context.Examinations.Where(x => x.PatientId == examination.PatientId && x.Id != examination.Id).OrderByDescending(c => c.CreatedAt).Take(10).ToListAsync();
            return new BaseResponse<ExaminationView>
            {
                ResponseCode = "200",
                Data = new ExaminationView
                {
                    examination = examination,
                    history = history,
                    result = result,
                    patient = patient
                }
            };
        }
        public async Task<BaseResponse<Modules.Examination.Model.Examination>> ExaminationProcess(long Id)
        {
            var examination = await _context.Examinations.FirstOrDefaultAsync(x => x.Status != "NONE" && x.Id == Id);
            if (examination == null)
            {
                return new BaseResponse<Examination.Model.Examination>
                {
                    ResponseCode = "200",
                    Message = "EXAMINATION_NOT_FOUND_OR_UNPAID"
                };
            }
            examination.Status = "PROCESSING";
            _context.Examinations.Update(examination);
            _context.SaveChanges();
            if (examination.CheckinId != null)
            {
                var checkin = await _context.Checkins.FindAsync(examination.CheckinId);
                if (checkin != null)
                {
                    checkin.Status = "PROCESSING";
                    _context.Checkins.Update(checkin);
                    _context.SaveChanges();
                }
            }

            return new BaseResponse<Examination.Model.Examination>
            {
                ResponseCode = "200",
                Data = examination
            };
        }
        public async Task<BaseResponse<Modules.Examination.Model.Examination>> ExaminationCancel(long Id)
        {
            var examination = await _context.Examinations.FirstOrDefaultAsync(x => x.Status != "NONE" && x.Id == Id);
            if (examination == null)
            {
                return new BaseResponse<Examination.Model.Examination>
                {
                    ResponseCode = "500",
                    Message = "EXAMINATION_NOT_FOUND_OR_UNPAID"
                };
            }
            var ticket = await _context.ExaminationTickets.Where(x => x.ExaminationId == Id).ToListAsync();
            if (ticket.Count > 1)
            {
                return new BaseResponse<Examination.Model.Examination>
                {
                    ResponseCode = "500",
                    Message = "CANNOT_CANCEL_EXAMINATION"
                };
            }
            examination.Status = "PENDING";
            _context.Examinations.Update(examination);
            _context.SaveChanges();
            if (examination.CheckinId != null)
            {
                var checkin = await _context.Checkins.FindAsync(examination.CheckinId);
                if (checkin != null)
                {
                    checkin.Status = "PENDING";
                    _context.Checkins.Update(checkin);
                    _context.SaveChanges();
                }
            }
            return new BaseResponse<Examination.Model.Examination>
            {
                ResponseCode = "200",
                Data = examination
            };
        }
        public async Task<BaseResponse<ExaminationResult>> SaveExaminationResult(ExaminationResultDto req, int doctorId)
        {
            if (req.examinationResult == null || req.examinationResult.ExaminationId == null)
            {
                return new BaseResponse<ExaminationResult>
                {
                    ResponseCode = "500",
                    Message = "REQUIRED_EXAMINATIONID"
                };
            }
            var examination = await _context.Examinations.FindAsync(req.examinationResult.ExaminationId);
            if (examination == null)
            {
                return new BaseResponse<ExaminationResult>
                {
                    ResponseCode = "500",
                    Message = "EXAMINATION_NOT_FOUND"
                };
            }

            var result = await _context.ExaminationResults.FirstOrDefaultAsync(x => x.ExaminationId == examination.Id);
            ExaminationResult resultData = null;
            if (result == null)
            {
                resultData = _mapper.Map<ExaminationResult>(req.examinationResult);
                await _context.ExaminationResults.AddAsync(resultData);
                await _context.SaveChangesAsync();
            }
            else
            {
                resultData = _mapper.Map(req.examinationResult, result);
                _context.ExaminationResults.Update(resultData);
                _context.SaveChanges();
            }
            if (resultData != null && req.diagnostic != null)
            {
                if (req.diagnostic.Diagnostic != null)
                {
                    var diagnostic = _diagnosticRepository.SaveExaminationDiagnostic(resultData.Id, req.diagnostic.Diagnostic, "EXAMINATION", 1).Result;
                }
                if (req.diagnostic.DiagnosticSub != null && req.diagnostic.DiagnosticSub.Count() > 0)
                {
                    foreach (var item in req.diagnostic.DiagnosticSub)
                    {
                        var DiagnosticSub = _diagnosticRepository.SaveExaminationDiagnostic(resultData.Id, item, "EXAMINATION", 0).Result;
                    }
                }
            }
            return new BaseResponse<ExaminationResult>
            {
                ResponseCode = "200",
                Data = resultData
            };
        }

        public async Task<BaseResponse<ExaminationTicket>> SaveExamninationService(AddServiceDto req, int? doctorId = 1)
        {
            if (req.services != null && req.services.Count() > 0)
            {
                var examnination = await _context.Examinations.FirstOrDefaultAsync(x => x.Id == req.ExaminationId && x.Status != "COMPLETED");
                if (examnination == null)
                {
                    return new BaseResponse<ExaminationTicket>
                    {
                        ResponseCode = "500",
                        Message = "EXAMNINATION_NOT_FOUND"
                    };
                }

                foreach (var item in req.services)
                {
                    var service = _context.Services.FirstOrDefault(x => x.Code == item.Code);
                    if (service != null)
                    {
                        var examTicket = GetOrCreateExTicket(examnination, "EXAMINATION", (int)doctorId, (int)item.RoomSample, (int)item.RoomHandle, (int)service.ServiceGroupId).Result;
                        if (examTicket != null && examTicket.Id > 0)
                        {
                            var qty = item.Qty;
                            var priceService = service.PriceNormal;
                            var dataItem = new CreateOrderExamination
                            {
                                examinationTicket = examTicket,
                                service = service,
                                Qty = qty,
                                ServiceObject = item.ObjectService,
                                RoomSampleId = item.RoomSample,
                                RoomId = examnination.RoomId,
                                RoomHandleId = item.RoomHandle,
                                ParentId = 0
                            };
                            var order = _examinationOrderRepository.CreateExaminationOrder(dataItem).Result;
                        }
                    }

                }
                return new BaseResponse<ExaminationTicket>
                {
                    ResponseCode = "200",
                    Message = "SUCCESS",
                };
            }
            return new BaseResponse<ExaminationTicket>
            {
                ResponseCode = "500",
                Message = "DATA_NOT_FOUND"
            };
        }
        public async Task<ExaminationTicket> GetOrCreateExTicket(ExaminationModel examination, string type, int doctorId, int? roomSample = 0, int? roomHandle = 0, int? serviceGroupId = 0)
        {

            var ticket = await _context.ExaminationTickets.Where(x => x.ExaminationId == examination.Id && x.Type == type &&
            x.RoomSample == roomSample.GetValueOrDefault() && x.RoomHandle == roomHandle.GetValueOrDefault() && x.ServiceGroupId == serviceGroupId.GetValueOrDefault() && x.PaymentStatus == "UNPAID").FirstOrDefaultAsync();
            if (ticket == null)
            {

                ticket = new Examination.Model.ExaminationTicket()
                {
                    Barcode = _common.GetBarcode(examination.Id).Result,
                    ExaminationId = examination.Id,
                    PatientId = examination.PatientId,
                    Type = type,
                    Room = examination.RoomId,
                    RoomCode = examination.RoomCode,
                    DepartmentId = examination.DepartmentId,
                    DoctorId = doctorId,
                    Status = true,
                    PaymentStatus = "UNPAID",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    RoomHandle = roomHandle,
                    RoomSample = roomSample,
                    ServiceGroupId = serviceGroupId
                };
                await _context.ExaminationTickets.AddAsync(ticket);
                await _context.SaveChangesAsync();
            }
            return ticket;
        }
        public async Task<List<ListServiceGroupOrder>> GetServiceGroupOrderByExam(int examId)
        {
            var groupId = await _context.ExaminationTickets.Where(x => x.ExaminationId == examId).Select(x => x.ServiceGroupId).Distinct().ToListAsync();
            if (groupId != null && groupId.Count() > 0)
            {
                var lists = await _context.ServiceGroups.Where(x => groupId.Contains(x.Id)).ToListAsync();
                var result = lists.Select(x => new ListServiceGroupOrder
                {
                    Name = x.Name,
                    Code = x.Code,
                    CodeName = x.CodeName,
                    Tickets = ExaminationTicketByGroupExam(examId, x.Id).Result
                }).ToList();
                return result;
            }
            return new List<ListServiceGroupOrder>();
        }
        public async Task<List<ExaminationOrderByTicket>> ExaminationTicketByGroupExam(int examId, int GroupId)
        {

            var ticket = await _context.ExaminationTickets.Where(x => x.ExaminationId == examId && x.ServiceGroupId == GroupId).ToListAsync();
            if (ticket != null)
            {
                var result = ticket.Select(x => new ExaminationOrderByTicket
                {
                    Id = (int)x.Id,
                    Type = x.Type,
                    Barcode = x.Barcode,
                    CreatedAt = x.CreatedAt,
                    OrderAt = x.OrderAt,
                    Doctor = x.Type,
                    PaymentStatus = x.PaymentStatus,
                    Roomcode = x.RoomCode,
                    Orders = _context.ExaminationOrders.Where(b => b.TicketId == x.Id && b.ExaminationId == x.ExaminationId).ToList(),
                }).ToList();
                return result;
            }
            return new List<ExaminationOrderByTicket>();
        }
    }
}
