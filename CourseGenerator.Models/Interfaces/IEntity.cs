using MongoDB.Bson;

namespace CourseGenerator.Models.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}
