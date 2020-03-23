using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;

namespace CourseGenerator.BLL.Infrastructure
{
    public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile()
        {
            CreateMap<UserRegistrationDTO, User>();
        }
    }
}
