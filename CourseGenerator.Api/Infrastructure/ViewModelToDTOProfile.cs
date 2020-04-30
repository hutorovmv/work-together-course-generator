using AutoMapper;
using CourseGenerator.Api.Models;
using CourseGenerator.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Infrastructure
{
    #pragma warning disable CS1591
    public class ViewModelToDTOProfile : Profile
    {
        public ViewModelToDTOProfile()
        {
            CreateMap<UserRegistrationModel, UserRegistrationDTO>();
            CreateMap<UserLoginModel, UserLoginDTO>();
            CreateMap<LanguageSelectModel, LanguageSelectDTO>();
            CreateMap<LevelSelectModel, LevelSelectDTO>();
            CreateMap<CourseSelectModel, CourseSelectDTO>();
            CreateMap<ThemeSelectModel, ThemeSelectDTO>();
            CreateMap<PhoneAuthModel, PhoneAuthDTO>();
        }
    }
    #pragma warning restore CS1591
}
