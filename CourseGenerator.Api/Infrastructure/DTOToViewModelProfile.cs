using AutoMapper;
using CourseGenerator.Api.Models;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.DTO.User;

namespace CourseGenerator.Api.Infrastructure
{
#pragma warning disable CS1591
    public class DTOToViewModelProfile : Profile
    {
        public DTOToViewModelProfile()
        {
            CreateMap<RegisterDTO, UserRegistrationModel>();
            CreateMap<LoginDTO, UserLoginModel>();
            CreateMap<LanguageSelectDTO, LanguageSelectModel>();
            CreateMap<LevelSelectDTO, LevelSelectModel>();
            CreateMap<CourseSelectDTO, CourseSelectModel>();
            CreateMap<UserThemeSelectDTO, UserThemeSelectModel>();
            CreateMap<PhoneAuthDTO, PhoneAuthModel>();
            CreateMap<CodeAuthDTO, CodeAuthModel>();
        }
    }
    #pragma warning restore CS1591
}
