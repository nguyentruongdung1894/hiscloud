using AutoMapper;
using Nencer.Modules.Checkin.Model;
using Nencer.Modules.Checkin.Model.Dto;
using Nencer.Modules.Examination.Model;
using Nencer.Modules.Local.Model;
using Nencer.Modules.Local.Model.Dto;
using Nencer.Modules.ManageService;
using Nencer.Modules.ManageService.Model.Dto;
using Nencer.Modules.Patient.Model;
//using Nencer.Modules.Authentication.Model;
//using Nencer.Modules.Authentication.Model.Dto;
//using Nencer.Modules.Users.Model;
//using Nencer.Modules.Users.Model.Dto;

namespace Nencer.Extensions
{
    public class NencerAutoMapperProfile : Profile
    {
        public NencerAutoMapperProfile()
        {
            CreateMap<LocalCity, LocalCityModel>().ReverseMap();
            CreateMap<Service, ServiceModel>().ReverseMap();
            CreateMap<CheckinRequest, Checkin>().ReverseMap();
            CreateMap<CheckinRequest, Examination>();
            CreateMap<CheckinRequest, Patient>().ReverseMap();
            CreateMap<Patient, CheckinRequest>().ReverseMap();
        }
    }
}
