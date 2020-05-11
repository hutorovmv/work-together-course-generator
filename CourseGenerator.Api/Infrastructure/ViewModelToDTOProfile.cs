using AutoMapper;
using CourseGenerator.Api.Models;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.DTO.User;

namespace CourseGenerator.Api.Infrastructure
{
#pragma warning disable CS1591
    public class ViewModelToDTOProfile : Profile
    {
        public ViewModelToDTOProfile()
        {
            CreateMap<UserRegistrationModel, RegisterDTO>();
            CreateMap<UserLoginModel, LoginDTO>();
            CreateMap<LanguageSelectModel, LanguageSelectDTO>();
            CreateMap<LevelSelectModel, LevelSelectDTO>();
            CreateMap<CourseSelectModel, CourseSelectDTO>();
            CreateMap<UserThemeSelectModel, UserThemeSelectDTO>();
            CreateMap<PhoneAuthModel, PhoneAuthDTO>();
            CreateMap<CodeAuthModel, CodeAuthDTO>();
        }
    }
    #pragma warning restore CS1591
}
