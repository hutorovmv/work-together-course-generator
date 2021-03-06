﻿using AutoMapper;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.DTO.User;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.Security;

namespace CourseGenerator.BLL.Infrastructure
{
    public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile()
        {
            CreateMap<RegisterDTO, User>()
                .ForMember(dest => dest.UserName, 
                    opt => opt.MapFrom(src => src.Email));
            CreateMap<CodeAuthDTO, CodeAuth>();
            CreateMap<HeadingDTO, Heading>();
            CreateMap<HeadingLangDTO, HeadingLang>();
            CreateMap<HeadingSelectDTO, HeadingLang>();
            CreateMap<HeadingManagerDTO, HeadingManager>();
            CreateMap<UserSettingsDTO, User>()
                .ForAllMembers(opt => 
                    opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
