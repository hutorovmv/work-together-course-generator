﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.BLL.Infrastructure
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<User, UserRegistrationDTO>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<CourseLang, CourseItemDTO>();
        }
    }
}
