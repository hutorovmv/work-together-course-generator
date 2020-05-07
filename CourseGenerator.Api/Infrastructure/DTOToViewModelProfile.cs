using AutoMapper;
using CourseGenerator.Api.Models;
using CourseGenerator.BLL.DTO;

namespace CourseGenerator.Api.Infrastructure
{
#pragma warning disable CS1591
    public class DTOToViewModelProfile : Profile
    {
        public DTOToViewModelProfile()
        {
            CreateMap<UserRegistrationDTO, UserRegistrationModel>();
            CreateMap<UserLoginDTO, UserLoginModel>();
            CreateMap<LanguageSelectDTO, LanguageSelectModel>();
            CreateMap<LevelSelectDTO, LevelSelectModel>();
            CreateMap<CourseSelectDTO, CourseSelectModel>();
            CreateMap<ThemeSelectDTO, ThemeSelectModel>();
            CreateMap<PhoneAuthDTO, PhoneAuthModel>();
        }
    }
    #pragma warning restore CS1591
}
