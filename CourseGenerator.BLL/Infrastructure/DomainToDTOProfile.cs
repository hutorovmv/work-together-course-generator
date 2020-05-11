using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.DTO.User;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;
using CourseGenerator.Models.Entities.Security;

namespace CourseGenerator.BLL.Infrastructure
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<User, RegisterDTO>();
            CreateMap<User, LoginDTO>();
            CreateMap<User, UserDetailsDTO>();
            CreateMap<Language, LanguageSelectDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OriginalName));
            CreateMap<CourseLang, CourseSelectDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CourseId));
            CreateMap<ThemeLang, UserThemeSelectDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ThemeId));
            CreateMap<LevelLang, LevelSelectDTO>();
            CreateMap<PhoneAuth, PhoneAuthDTO>();
            CreateMap<CodeAuth, CodeAuthDTO>();
        }
    }
}
