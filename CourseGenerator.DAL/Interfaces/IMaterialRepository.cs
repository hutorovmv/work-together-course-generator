﻿using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IMaterialRepository: IRepository<Material>
    {
        Task<IEnumerable<Material>> GetChildrenAsync(int childrenId);
    }
}
