using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Content
{
    public class Article
    {
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        public string Author { get; set; }

        [BsonIgnoreIfDefault]
        public DateTime LastEdited { get; set; }

        [BsonIgnoreIfNull]
        public string LastEditedBy { get; set; }

        [BsonIgnoreIfNull]
        public List<string> SourceUris { get; set; }

        public ICollection<ArticleLang> Localization { get; set; }
    }
}
