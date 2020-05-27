using System;
using System.Collections.Generic;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string Note { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<GroupMessage> GroupMessages { get; set; }

        public Group()
        {
            UserGroups = new List<UserGroup>();
            GroupMessages = new List<GroupMessage>();
        }
    }
}
