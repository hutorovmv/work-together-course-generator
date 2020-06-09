using AutoMapper;
using CourseGenerator.Api.Models.Entities;
using CourseGenerator.Api.Models.Locals;
using CourseGenerator.Api.Models.Security;
using CourseGenerator.Api.Models.Selection;
using CourseGenerator.Api.Models.User;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
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
            CreateMap<UserSettingsModel, UserSettingsDTO>();
            CreateMap<HeadingModel, HeadingDTO>();
            CreateMap<HeadingLangModel, HeadingLangDTO>();
            CreateMap<HeadingSelectModel, HeadingSelectDTO>();
            CreateMap<HeadingManagerModel, HeadingManagerDTO>();
        }
    }
    #pragma warning restore CS1591
}
