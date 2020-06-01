using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IAccessManager<TEntity, TId> : IRepository<TEntity> where TEntity: class
    {
        public bool HasAccess(string userId, TId id);
    }
}
