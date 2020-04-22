using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.BLL.Infrastructure
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<User, UserRegistrationDTO>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<User, UserDetailsDTO>();
            CreateMap<Language, LanguageSelectDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OriginalName));
            CreateMap<CourseLang, CourseSelectDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CourseId));
            CreateMap<ThemeLang, ThemeSelectDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ThemeId));
            CreateMap<LevelLang, LevelSelectDTO>();
        }
    }
}
