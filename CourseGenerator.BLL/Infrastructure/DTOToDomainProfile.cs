using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Security;

namespace CourseGenerator.BLL.Infrastructure
{
    public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile()
        {
            CreateMap<UserRegistrationDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<PhoneAuthDTO, PhoneAuth>();
        }
    }
}
