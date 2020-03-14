using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    public class Course
    {
        public int Id { get; set; }
        
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public string Note { get; set; }

        public ICollection<CourseDependency> CourseDependencies { get; set; }
        public ICollection<CourseDependency> BaseCourseDependencies { get; set; }
        public ICollection<Theme> Themes { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<CourseHeading> CourseHeadings { get; set; }
        public ICollection<CourseLang> CourseLangs { get; set; }

    }
}
