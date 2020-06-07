namespace CourseGenerator.DAL.Interfaces
{
    public interface IAccessManager<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        public bool HasAccess(string userId, params object[] id);
    }
}
