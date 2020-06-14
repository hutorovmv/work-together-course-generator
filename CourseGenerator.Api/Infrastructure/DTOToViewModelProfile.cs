using AutoMapper;
using CourseGenerator.Api.Models.Entities;
using CourseGenerator.Api.Models.Locals;
using CourseGenerator.Api.Models.Security;
using CourseGenerator.Api.Models.Selection;
using CourseGenerator.Api.Models.User;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
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
            CreateMap<HeadingDTO, HeadingModel>();
            CreateMap<HeadingLangDTO, HeadingLangModel>();
            CreateMap<HeadingSelectDTO, HeadingSelectModel>();
            CreateMap<HeadingManagerDTO, HeadingManagerModel>();
            CreateMap<UserDTO, UserModel>();
        }
    }
    #pragma warning restore CS1591
}
