
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Nencer.Helpers;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Examination.Repository;
using Nencer.Modules.ManageService.Repository;
using Nencer.Modules.Patient.Repository;
using Nencer.Resources;
using Nencer.Shared;
using static Nencer.Shared.Constant;

namespace Nencer.Modules.Checkin.Repository
{
    public interface ICheckinRepository
    {
        Task<List<Model.Checkin>> GetAllCheckin();
        Task<BaseResponse<Model.Checkin>> Create(CheckinRequest req);
        Task<CheckinRequest> GetInfoCheckInById(long idCheckIn);
        Task<BaseResponse<Model.Checkin>> Update(CheckinRequest req);
        Task<int?> GetOrdinalCheckin(long examId, string roomCode);
        Task<string> GetBarcode(long examId);
        Task<List<PatientsModel>> GetListPaggingAsync(SearchModel searchModel);
        Task<BaseResponse<Model.Checkin>> Delete(int id);
    }
    public class CheckinRepository : ICheckinRepository
    {
        private readonly NencerDbContext _context;
        private readonly DapperContext _dapperContext;
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IExaminationRepository _examinationRepository;
        private readonly IExaminationTicketRepository _examinationTicketRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IExaminationOrderRepository _examinationOrderRepository;
        private readonly IExaminationBarcodeRepository _examinationBarcodeRepository;
        private readonly IStringLocalizer<NencerResource> _localizer;


        public CheckinRepository(NencerDbContext context, IPatientRepository patientRepository, IMapper mapper, IExaminationRepository examinationRepository, IExaminationTicketRepository examinationTicketRepository, IServiceRepository serviceRepository, IExaminationOrderRepository examinationOrderRepository, IExaminationBarcodeRepository examinationBarcodeRepository, IStringLocalizer<NencerResource> localizer, DapperContext dapperContext)
        {
            _context = context;
            _patientRepository = patientRepository;
            _mapper = mapper;
            _examinationRepository = examinationRepository;
            _examinationTicketRepository = examinationTicketRepository;
            _serviceRepository = serviceRepository;
            _examinationOrderRepository = examinationOrderRepository;
            _examinationBarcodeRepository = examinationBarcodeRepository;
            _localizer = localizer;
            _dapperContext = dapperContext;
        }

        public async Task<BaseResponse<Model.Checkin>> Create(CheckinRequest req)
        {
            var rs = new BaseResponse<Model.Checkin>();
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Helpers.LogHelper.Info("// validate");
                    if (req.Checkin == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "Bat buoc nhap",
                            ResponseCode = "02",
                        };
                    }
                    if (req.Patient == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "Bat buoc nhap",
                            ResponseCode = "02",
                        };
                    }

                    if (req.Checkin.ServiceId == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI DICH VU",
                            ResponseCode = "02",
                            Data = null
                        };
                    }

                    var medicServices = await _serviceRepository.GetServiceById(1);
                    if (medicServices == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI DICH VU",
                            ResponseCode = "02",
                            Data = null
                        };
                    }

                    #region 1. Luu Patients
                    Helpers.LogHelper.Info("// 1. Luu thong tin khach hang");
                    var oldPatient = !string.IsNullOrWhiteSpace(req.Checkin.PatientNumber) ? await _patientRepository.GetPatialByPatientNumber(req.Checkin.PatientNumber) : null;
                    // Update
                    if (oldPatient != null)
                    {
                        req.Patient.UpdatedAt = DateTime.Now;

                        _context.Patients.Update(req.Patient);
                        await _context.SaveChangesAsync();

                        // Lưu thông tin liên quan đến bệnh nhân
                        await PatialOtherInfoProcess(req, req.Patient, false);
                    }
                    // Create
                    else
                    {
                        req.Patient.CreatedAt = DateTime.Now;
                        req.Patient.UpdatedAt = DateTime.Now;

                        await _context.Patients.AddAsync(req.Patient);
                        await _context.SaveChangesAsync();

                        req.Patient.PatientNumber = string.Concat(DateTime.Now.ToString("yyyy"), req.Patient.Id);
                        _context.Patients.Update(req.Patient);
                        await _context.SaveChangesAsync();

                        // Lưu thông tin liên quan đến bệnh nhân
                        await PatialOtherInfoProcess(req, req.Patient, true);
                    }
                    #endregion

                    #region 2. Luu checkin
                    Helpers.LogHelper.Info("// 2.1 Luu tiep don");
                    req.Checkin.PatientId = req.Patient.Id;
                    req.Checkin.PatientNumber = req.Patient.PatientNumber;
                    req.Checkin.Status = Constant.Status.PENDING.ToString();
                    req.Checkin.CreatedAt = DateTime.Now;

                    await _context.Checkins.AddAsync(req.Checkin);
                    await _context.SaveChangesAsync();
                    #endregion

                    #region Luu exam
                    Helpers.LogHelper.Info("// 2.2 Tao ban ghi lich su check in dau tien");
                    var examination = new Examination.Model.Examination();
                    examination.CheckinId = req.Checkin.Id;
                    examination.PatientId = req.Patient.Id;
                    examination.PatientRelationId = null;
                    examination.ServiceObject = req.Checkin.ServiceObject;
                    examination.Type = req.Checkin.Type;
                    examination.ExamIdBefore = null;
                    examination.IsOpenAgain = true;
                    examination.ExaminationNumber = null;
                    examination.ExaminationDate = null;
                    examination.ExaminationStartAt = null;
                    examination.Priority = req.Checkin.Priority;
                    examination.RoomId = req.Checkin.RoomId;
                    examination.RoomCode = req.Checkin.RoomCode;
                    examination.DepartmentId = req.Checkin.DepartmentId;
                    examination.DoctorId = null;
                    examination.DoctorName = null;
                    examination.Reason = null;
                    examination.Status = Constant.ExamStatus.PENDING.ToString();
                    examination.ChamberId = null;
                    examination.BedId = null;
                    examination.CheckinTime = null;
                    examination.CreatedAt = DateTime.Now;
                    examination.UpdatedAt = DateTime.Now; ;

                    await _context.Examinations.AddAsync(examination);
                    await _context.SaveChangesAsync();
                    #endregion

                    #region Luu exam
                    Helpers.LogHelper.Info("// 2.3 Tao stt");
                    var num = await GetOrdinalCheckin(examination.Id, examination.RoomCode);
                    examination.ExaminationNumber = num;
                    req.Checkin.CheckinNumber = num;

                    _context.Examinations.Update(examination);
                    _context.Checkins.Update(req.Checkin);
                    await _context.SaveChangesAsync();
                    #endregion

                    #region Tao phieu thu
                    Helpers.LogHelper.Info("// 4. Tao phieu thu");
                    double? price = 0D;
                    double? total = 0D;
                    double? payAmount = null;
                    double? insurance = null;
                    var paymentStatus = Constant.ExamOrderStatus.UNPAID;
                    var serviceObj = Constant.ServiceObjectType.REQUEST.ToString();

                    try
                    {
                        if (req.Checkin.ServiceObject.Equals("FREE"))
                        {
                            total = payAmount = price = medicServices.PriceNormal;
                            serviceObj = ServiceObjectType.FREE.ToString();
                            paymentStatus = ExamOrderStatus.PAID;
                        }
                        if (req.Checkin.ServiceObject.Equals("REQUEST"))
                        {
                            total = payAmount = price = medicServices.PriceService;
                            serviceObj = ServiceObjectType.REQUEST.ToString();
                        }
                        if (req.Checkin.ServiceObject.Equals("INSURANCE"))
                        {
                            total = payAmount = price = medicServices.PriceIns;
                            serviceObj = ServiceObjectType.INSURANCE.ToString();
                        }
                        if (req.Checkin.ServiceObject.Equals("MEDICAL_FEE"))
                        {
                            total = payAmount = price = medicServices.PriceNormal;
                            serviceObj = ServiceObjectType.MEDICAL_FEE.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Helpers.LogHelper.Error(ex.Message);
                    }

                    var examTicket = new Examination.Model.ExaminationTicket()
                    {
                        Barcode = "BarcodeFix",
                        ExaminationId = examination.Id,
                        ServiceGroupId = medicServices.ServiceGroupId,
                        PatientId = req.Patient.Id,
                        Type = serviceObj,
                        Room = req.Checkin.RoomId,
                        RoomCode = req.Checkin.RoomCode,
                        DepartmentId = req.Checkin.DepartmentId,
                        DoctorId = req.Checkin.DoctorId,
                        Status = true,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    await _context.ExaminationTickets.AddAsync(examTicket);
                    await _context.SaveChangesAsync();
                    #endregion

                    #region Luu thong tin order
                    var exOrder = new ExaminationOrder()
                    {
                        ExaminationId = examination.Id,
                        TicketId = examTicket.Id,
                        PatientId = req.Patient.Id,
                        ServiceId = req.Checkin.ServiceId.Value,
                        ServiceCode = medicServices.Code,
                        ServiceName = medicServices.Name,
                        ServiceGroupId = medicServices.ServiceGroupId,
                        Qty = 1,
                        Unit = medicServices.Unit,
                        Price = price,
                        TotalAmount = total,
                        ServiceObject = serviceObj,
                        BenefitRate = 100,
                        InsurancePay = insurance,
                        Status = paymentStatus.ToString(),
                        PaymentStatus = paymentStatus.ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    await _context.ExaminationOrders.AddAsync(exOrder);
                    await _context.SaveChangesAsync();
                    #endregion

                    Helpers.LogHelper.Info("// 5. Commit");
                    await transaction.CommitAsync();

                    Helpers.LogHelper.Info("// 6. Thanh cong");
                    rs.Message = "Thanh cong!";
                    rs.ResponseCode = "00";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new BaseResponse<Model.Checkin>
                    {
                        Message = ex.Message,
                        ResponseCode = "999",
                        Data = null
                    };
                }
            }

            return rs;
        }

        public async Task<BaseResponse<Model.Checkin>> Update(CheckinRequest req)
        {
            var rs = new BaseResponse<Model.Checkin>();
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Helpers.LogHelper.Info("// validate");
                    if (req.Checkin == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "Bat buoc nhap",
                            ResponseCode = "02",
                        };
                    }
                    if (req.Patient == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "Bat buoc nhap",
                            ResponseCode = "02",
                        };
                    }
                    var checkinOld = await _context.Checkins.FirstOrDefaultAsync(x => x.Id == req.Checkin.Id);
                    if (checkinOld == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI CHECKIN",
                            ResponseCode = "02",
                            Data = null
                        };
                    }
                    var patientsOld = await _context.Patients.FirstOrDefaultAsync(x => x.Id == req.Patient.Id);
                    if (patientsOld == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI BENH NHAN",
                            ResponseCode = "02",
                            Data = null
                        };
                    }
                    var examOld = await _context.Examinations.FirstOrDefaultAsync(x => x.CheckinId == req.Checkin.Id);
                    if (examOld == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI EXAM",
                            ResponseCode = "02",
                            Data = null
                        };
                    }

                    if (checkinOld.RoomId != null)
                    {
                        int oldRoomId = checkinOld.RoomId.Value;
                        var room = _context.Rooms.FirstOrDefaultAsync(x => x.Id == req.Checkin.RoomId);
                        if (room == null)
                        {
                            return new BaseResponse<Model.Checkin>
                            {
                                Message = "KHONG TON TAI PHONG KHAM",
                                ResponseCode = "301",
                                Data = null
                            };
                        }
                    }
                    else
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI PHONG KHAM",
                            ResponseCode = "301",
                            Data = null
                        };
                    }

                    #region Luu thong tin khach hang
                    Helpers.LogHelper.Info("// 1. Luu thong tin khach hang");
                    await Task.Delay(100);
                    req.Patient.UpdatedAt = DateTime.Now;
                    _context.Patients.Update(req.Patient);
                    await _context.SaveChangesAsync();
                    // Lưu thông tin liên quan đến bệnh nhân
                    await PatialOtherInfoProcess(req, patientsOld, false);
                    #endregion

                    #region Luu checkin
                    Helpers.LogHelper.Info("// 3. Luu tiep don");
                    req.Checkin.UpdatedAt = DateTime.Now;
                    _context.Checkins.Update(req.Checkin);
                    await _context.SaveChangesAsync();
                    #endregion

                    #region Luu exam
                    Helpers.LogHelper.Info("// 3.1 Tao stt phong moi");
                    if (checkinOld.RoomId.Value != req.Checkin.RoomId)
                    {
                        var num = await GetOrdinalCheckin(examOld.Id, req.Checkin.RoomCode);
                        examOld.ExaminationNumber = num;
                        _context.Examinations.Update(examOld);

                        req.Checkin.CheckinNumber = num;
                        _context.Checkins.Update(req.Checkin);

                        await _context.SaveChangesAsync();
                    }
                    #endregion

                    Helpers.LogHelper.Info("// 5. Commit");
                    await transaction.CommitAsync();

                    Helpers.LogHelper.Info("// 6. Update Thanh cong");
                    rs.Message = "Update thanh cong!";
                    rs.ResponseCode = "00";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new BaseResponse<Model.Checkin>
                    {
                        Message = ex.Message,
                        ResponseCode = "999",
                        Data = null
                    };
                }
            }

            return rs;
        }

        private async Task PatialOtherInfoProcess(CheckinRequest req, Patient.Model.Patient oldPatient, bool isAdd)
        {
            Helpers.LogHelper.Info("// 2. Luu thong tin chi tiet");
            var patialDetail = _mapper.Map<PatientDetail>(req.PatientDetail);
            if (patialDetail != null)
            {
                if (isAdd)
                {
                    patialDetail.PatientId = oldPatient.Id;
                    await _context.PatientDetails.AddAsync(patialDetail);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var x = await _context.PatientDetails.FirstOrDefaultAsync(x => x.PatientId == oldPatient.Id);
                    if (x != null)
                    {
                        x.Address = patialDetail.Address;
                        _context.PatientDetails.Update(x);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            Helpers.LogHelper.Info("// 2.1 Luu thong tin the");
            var patientInsuranceCard = _mapper.Map<PatientInsuranceCard>(req.PatientInsuranceCard);
            if (patientInsuranceCard != null && req.Checkin.ServiceObject == "INSURANCE")
            {
                if (isAdd)
                {
                    patientInsuranceCard.PatientId = oldPatient.Id;
                    await _context.PatientInsuranceCards.AddAsync(patientInsuranceCard);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var x = await _context.PatientInsuranceCards.FirstOrDefaultAsync(x => x.PatientId == oldPatient.Id);
                    if (x != null)
                    {
                        x.FullNumber = patientInsuranceCard.FullNumber;
                        _context.PatientInsuranceCards.Update(x);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        patientInsuranceCard.PatientId = oldPatient.Id;
                        await _context.PatientInsuranceCards.AddAsync(patientInsuranceCard);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            Helpers.LogHelper.Info("// 2.2 Luu thong tin chi tien su");
            var patialPres = _mapper.Map<List<PatientPrehistoric>>(req.PatientPrehistoric);
            if (patialPres != null)
            {
                if (!isAdd)
                {
                    var x = await _context.PatientPrehistorics.Where(x => x.PatientId == oldPatient.Id).ToListAsync();
                    if (x != null)
                    {
                        _context.PatientPrehistorics.RemoveRange(x);
                        await _context.SaveChangesAsync();
                    }
                }
                patialPres.ForEach(x => { x.PatientId = oldPatient.Id; });
                await _context.PatientPrehistorics.AddRangeAsync(patialPres);
                await _context.SaveChangesAsync();
            }

            Helpers.LogHelper.Info("// 2.3 Luu thong tin nguoi nha");
            var patialRelations = _mapper.Map<List<PatientRelation>>(req.PatientRelation);
            if (patialRelations != null)
            {
                if (!isAdd)
                {
                    var x = await _context.PatientRelations.Where(x => x.PatientId == oldPatient.Id).ToListAsync();
                    _context.PatientRelations.RemoveRange(x);
                    await _context.SaveChangesAsync();
                }
                patialRelations.ForEach(x => { x.PatientId = oldPatient.Id; });
                await _context.PatientRelations.AddRangeAsync(patialRelations);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Model.Checkin>> GetAllCheckin()
        {
            return await _context.Checkins
                .ToListAsync();
        }

        public async Task<int?> GetOrdinalCheckin(long examId, string roomCode)
        {
            try
            {
                int max = !string.IsNullOrWhiteSpace(_localizer["Ordinal"].Value) ? Convert.ToInt32(_localizer["Ordinal"].Value) : 6;
                int num = await _examinationOrderRepository.GenerateExamOrdinal(max, roomCode);
                string generateOrdinal = ApiHelper.GenerateExamOrdinal(num, max);
                await _context.ExaminationOrdinals.AddAsync(new ExaminationOrdinal()
                {
                    Number = num,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DateTime = generateOrdinal,
                    RoomCode = roomCode,
                    Status = Constant.Status.PENDING.ToString(),
                    ExaminationId = examId
                });
                await _context.SaveChangesAsync();

                return num;
            }
            catch (Exception ex)
            {
                Helpers.LogHelper.Error(ex.Message);
                return 1;
            }
        }

        public async Task<string> GetBarcode(long examId)
        {
            int max = !string.IsNullOrWhiteSpace(_localizer["BarCode"].Value) ? Convert.ToInt32(_localizer["BarCode"].Value) : 6;
            try
            {
                int num = await _examinationBarcodeRepository.GenerateBarcode(max);
                string generateBarCode = ApiHelper.GenerateExamOrdinal(num, max);
                await _context.ExaminationBarcodes.AddAsync(new ExaminationBarcode()
                {
                    Number = num,
                    CreatedAt = DateTime.Now,
                    DateTime = generateBarCode,
                    ExaminationId = examId
                });
                await _context.SaveChangesAsync();

                return ApiHelper.GetBarCode(num, max);
            }
            catch (Exception ex)
            {
                Helpers.LogHelper.Error(ex.Message);
                int num = ApiHelper.GetRandomNumber(1, max);
                return ApiHelper.GetBarCode(num, max);
            }
        }

        public async Task<List<PatientsModel>> GetListPaggingAsync(SearchModel searchModel)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from checkin in _context.Checkins
                               join patient in _context.Patients on checkin.PatientId equals patient.Id into joinedPatients
                               from patient in joinedPatients.DefaultIfEmpty()
                               join room in _context.Rooms on checkin.RoomId equals room.Id into joinedRooms
                               from room in joinedRooms.DefaultIfEmpty()
                               join department in _context.Departments on room.DepartmentId equals department.Id into joinedDepartments
                               from department in joinedDepartments.DefaultIfEmpty()
                               select new PatientsModel
                               {
                                   ID = patient.Id,
                                   CheckInID = checkin.Id,
                                   MaBenhNhan = patient.PatientNumber,
                                   SoDT = patient.Phone,
                                   TenBenhNhan = patient.Name,
                                   CCCD = patient.IdCard,
                                   DoiTuong = checkin.ServiceObject,
                                   GioiTinh = patient.Gender,
                                   DiaChi = patient.Address,
                                   ngaysinh = (patient.Birthday != null) ? patient.Birthday.Value.ToString("yyyy/MM/dd") : "",
                                   khoakham = department.Name,
                                   tenphong = room.Name,
                                   lydokham = checkin.Reason,
                                   sotiepdon = 1,
                                   thoigiantiepdon = (checkin.CheckinTime != null) ? checkin.CheckinTime.Value.ToString("yyyy/MM/dd") : "",
                                   trangthai = "CLOSE",
                                   uutien = "CO UU TIEN",
                                   CreatedAt = checkin.CreatedAt
                               })
                               .OrderByDescending(c => c.CreatedAt)
                               .Skip(searchModel.SkipCount)
                               .Take(searchModel.MaxResultCount)
                               .ToList();

                if (!string.IsNullOrEmpty(searchModel.MaBenhNhan))
                {
                    lstData = lstData.Where(x => x.MaBenhNhan != null && x.MaBenhNhan.ToLower().Contains(searchModel.MaBenhNhan.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(searchModel.SoDT))
                {
                    lstData = lstData.Where(x => x.SoDT != null && x.SoDT.ToLower().Contains(searchModel.SoDT.ToLower())).ToList();
                }

                if (!string.IsNullOrEmpty(searchModel.SoCCCD))
                {
                    lstData = lstData.Where(x => x.CCCD != null && x.CCCD.ToLower().Contains(searchModel.SoCCCD.ToLower())).ToList();
                }

                // Then, retrieve the total count separately
                int totalCount = _context.Checkins.Count();
                if (lstData.Count > 0 && lstData[0] != null)
                {
                    lstData[0].TotalCount = totalCount;
                }

                return lstData;
            }
        }

        public async Task<BaseResponse<Model.Checkin>> Delete(int id)
        {
            var rs = new BaseResponse<Model.Checkin>();
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Helpers.LogHelper.Info("// validate");
                    var checkin = await _context.Checkins.FirstOrDefaultAsync(x => x.Id == id);
                    if (checkin == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI CHECKIN",
                            ResponseCode = "02",
                            Data = null
                        };
                    }
                    if (checkin.Status != Constant.Status.PENDING.ToString())
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KH da phat sinh cong kham",
                            ResponseCode = "802",
                            Data = null
                        };
                    }
                    // check phieu
                    var exam = await _context.Examinations.Where(x => x.CheckinId == id).ToListAsync();
                    if (exam == null)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KHONG TON TAI EXAM",
                            ResponseCode = "02",
                            Data = null
                        };
                    }
                    // check order 
                    var examOrder = await _context.ExaminationOrders.CountAsync(x => x.PaymentStatus == ExamOrderStatus.PAID.ToString() && x.ExaminationId == exam[0].Id);
                    if (examOrder > 0)
                    {
                        return new BaseResponse<Model.Checkin>
                        {
                            Message = "KH da phat sinh cong kham",
                            ResponseCode = "802",
                            Data = null
                        };
                    }
                    // delete
                    _context.Checkins.Remove(checkin);
                    Helpers.LogHelper.Info("// 5. Commit");
                    await transaction.CommitAsync();

                    Helpers.LogHelper.Info("// 6. Thanh cong");
                    rs.Message = "Thanh cong!";
                    rs.ResponseCode = "00";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new BaseResponse<Model.Checkin>
                    {
                        Message = ex.Message,
                        ResponseCode = "999",
                        Data = null
                    };
                }
            }

            return rs;
        }

        public async Task<CheckinRequest> GetInfoCheckInById(long idCheckIn)
        {
            using (var _context = new NencerDbContext())
            {
                var lstData = (from checkin in _context.Checkins
                               join patient in _context.Patients on checkin.PatientId equals patient.Id into joinedPatients
                               from patient in joinedPatients.DefaultIfEmpty()
                               join patientDetail in _context.PatientDetails on patient.Id equals patientDetail.PatientId into joinedPatientDetails
                               from patientDetail in joinedPatientDetails.DefaultIfEmpty()
                               join patientInsuranceCard in _context.PatientInsuranceCards on patient.Id equals patientInsuranceCard.PatientId into joinedPatientInsuranceCards
                               from patientInsuranceCard in joinedPatientInsuranceCards.DefaultIfEmpty()
                               where checkin.Id == idCheckIn
                               select new CheckinRequest
                               {
                                   Checkin = checkin,
                                   Patient = patient,
                                   PatientDetail = patientDetail,
                                   PatientInsuranceCard = patientInsuranceCard,
                               })
                               .FirstOrDefault();

                return lstData;
            }
        }
    }
}
