using System;
using System.Collections.Generic;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;
using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.Models
{
    public class TestData
    {
        #region Info block
        public static Language[] Languages;
        public static Heading[] Headings;
        public static HeadingLang[] HeadingLangs;
        public static Level[] Levels;
        public static LevelLang[] LevelLangs;
        public static Competency[] Competencies;
        public static CompetencyLang[] CompetencyLangs;
        public static HeadingCompetency[] HeadingCompetencies;
        public static MaterialType[] MaterialTypes;
        public static MaterialTypeLang[] MaterialTypeLangs;
        public static Material[] Materials;
        public static MaterialLang[] MaterialLangs;
        public static MaterialCompetency[] MaterialCompetencies;
        public static HeadingMaterial[] HeadingMaterials;
        #endregion

        #region InfoByThemes
        public static Course[] Courses;
        public static CourseLang[] CourseLangs;
        public static CourseDependency[] CourseDependencies;
        public static Theme[] Themes;
        public static ThemeLang[] ThemeLangs;
        public static CourseHeading[] CourseHeadings;
        public static ThemeHeading[] ThemeHeadings;
        public static ThemeMaterial[] ThemeMaterials;
        #endregion

        #region CourseAccess
        public static UserHeading[] UserHeadings;
        public static UserCourse[] UserCourses;
        public static UserTheme[] UserThemes;
        #endregion
    }
}
