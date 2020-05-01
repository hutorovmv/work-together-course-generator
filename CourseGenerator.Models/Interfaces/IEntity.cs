using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}
