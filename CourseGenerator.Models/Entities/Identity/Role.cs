﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CourseGenerator.Models.Entities.Identity
{
    public class Role : IdentityRole
    {
        public Role() { }

        public Role(string name)
        {
            Name = name;
        }
    }
}
