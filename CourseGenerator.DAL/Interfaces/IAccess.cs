using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IAccess<TEntity> : IRepository<TEntity> where TEntity: class
    {
        public bool HasAccess(string userId, int id);
    }
}
