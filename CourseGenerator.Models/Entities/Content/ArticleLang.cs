using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Content
{
    public class ArticleLang
    {
        public string LangCode { get; set; }

        [BsonIgnoreIfNull]
        public string Heading { get; set; }

        [BsonIgnoreIfDefault]
        public ObjectId FileId { get; set; }
    }
}
