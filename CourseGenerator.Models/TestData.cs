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
        public static Language[] Languages = {
            new Language
            {
                Code = "UA",
                Name = "Українська",
                OriginalName = "Українська",
                Note = "Примітка"
            },
            new Language
            {
                Code = "RU",
                Name = "Російська",
                OriginalName = "Русская",
            },
            new Language
            {
                Code = "ENG",
                Name = "Англійська",
                OriginalName = "English"
            }
        };

        public static Heading[] Headings = {
            new Heading
            {
                Id = 1,
                Code = "01",
                UDC = "01",
                Note = "Примітка"
            },
            new Heading
            {
                Id = 2,
                Code = "01.01",
                UDC = "01.01",
                Note = "Дочірня рубрика минулої"
            },
            new Heading
            {
                Id = 3,
                Code = "01.01.01",
                UDC = "01.01.01",
                Note = null
            },
            new Heading
            {
                Id = 4,
                Code = "02",
                UDC = "02",
                Note = "Нова рубрика"
            }
        };

        public static HeadingLang[] HeadingLangs = {
            new HeadingLang
            {
                HeadingId = 1,
                Name = "Алгоритми ",
                Description = "У цій рубриці знаходяться статті та матеріали про алгоритмізацію",
                LangCode = "UA"
            },
            new HeadingLang
            {
                HeadingId = 2,
                Name = "Модифікації сортування вставками",
                Description = null,
                LangCode = "UA",
            },
            new HeadingLang
            {
                HeadingId = 3,
                Name = "Алгоритм Шела",
                Description = null,
                LangCode = "UA"
            },
            new HeadingLang
            {
                HeadingId = 4,
                Name = "Програмування",
                Description = "У цій рубриці знаходяться матеріали про програмування",
                LangCode = "UA"
            }
        };

        public static Level[] Levels = {
            new Level
            {
                Number = 1,
                Note = "Basic Level"
            },
            new Level
            {
                Number = 2,
                Note = "Note"
            },
            new Level
            {
                Number = 3,
                Note = null
            },
            new Level
            {
                Number = 4,
                Note = null
            }
        };

        public static LevelLang[] LevelLangs = {
            new LevelLang
            {
                LevelNumber = 1,
                LangCode = "UA",
                Name = "Базова",
                Description = "Потребує частого керівництва"
            },
            new LevelLang
            {
                LevelNumber = 2,
                LangCode = "UA",
                Name = "Проміжна",
                Description = "Потребує періодичного керівництва"
            },
            new LevelLang
            {
                LevelNumber = 3,
                LangCode = "ENG",
                Name = "Advanced",
                Description = "Applies the competency in considerably difficult situations." +
                "Generally requires little or no guidance."
            },
            new LevelLang
            {
                LevelNumber = 4,
                LangCode = "ENG",
                Name = "Expert",
                Description = "Applies the competency in exceptionally difficult situations." +
                "Serves as a key resourse and advises others."
            }
        };

        public static Competency[] Competencies = {
            new Competency
            {
                Id = 1,
                Note = "Примітка",
                ParentId = null,
                LevelNumber = 1
            },
            new Competency
            {
                Id = 2,
                ParentId = 1,
                LevelNumber = 2
            },
            new Competency
            {
                Id = 3,
                ParentId = null,
                LevelNumber = 2
            },

        };

        public static CompetencyLang[] CompetencyLangs = {
            new CompetencyLang
            {
                CompetencyId = 1,
                LangCode = "UA",
                Name = "Інформаційна компетентність",
                Description = "За допомогою реальних об'єктів (телевізор, магнітофон, " +
                "телефон, факс, комп'ютер, принтер, модем, копір тощо) й інформаційних" +
                " технологій (аудіо-, відеозапис, електронна пошта, ЗМІ, Інтернет)" +
                " формуються вміння самостійно шукати, аналізувати та відбирати необхідну " +
                "інформацію, організовувати, перетворювати, зберігати та передавати її. " +
                "Дана компетентність забезпечує навички діяльності учня стосовно " +
                "інформації, що міститься в навчальних предметах та освітніх галузях, " +
                "а також у навколишньому світі."
            },
            new CompetencyLang
            {
                CompetencyId = 2,
                LangCode = "UA",
                Name = "Навчально-пізнавальна компетентність",
                Description = "Це сукупність компетентностей учня у сфері самостійної " +
                "пізнавальної діяльності, що включає елементи логічної, методологічної," +
                " евристичної, загальнонавчальної діяльності, співвіднесеної з реальними" +
                " об'єктами, які пізнаються учнем. Сюди входять знання й уміння " +
                "організації цілепокладання, планування, генерації ідей, аналізу, " +
                "рефлексії, самооцінки навчально-пізнавальної діяльності. Стосовно " +
                "досліджуваних об'єктів учень опановує креативні навички продуктивної " +
                "діяльності: добуванням знань безпосередньо з реальності, володінням " +
                "прийомами дій у нестандартних ситуаціях, евристичними методами рішення " +
                "проблем. У рамках даної компетентності визначаються вимоги відповідної " +
                "функціональної грамотності: уміння відрізняти факти від домислів, " +
                "володіння вимірювальними навичками, використання ймовірнісних, " +
                "статистичних та інших методів пізнання.",
            },
            new CompetencyLang
            {
                CompetencyId = 3,
                LangCode = "UA",
                Name = "Компетентність особистісного самовдосконалення",
                Description = "спрямована на засвоєння способів фізичного, " +
                "духовного й інтелектуального саморозвитку, емоційної саморегуляції" +
                " та самопідтримки. Реальним об'єктом у сфері даної компетентності " +
                "виступає сам учень. Він опановує способи діяльності у власних інтересах " +
                "і можливостях, що виражається в його безперервному самопізнанні, розвитку" +
                " необхідних сучасній людині особистісних якостей, формуванні психологічної" +
                " грамотності, культури мислення та поведінки. До даної компетентності " +
                "відносяться правила особистої гігієни, турбота про власне здоров'я, " +
                "статева грамотність, внутрішня екологічна культура. Сюди ж входить " +
                "комплекс якостей, пов'язаних з основами безпечної життєдіяльності " +
                "особистості."
            }
        };

        public static HeadingCompetency[] HeadingCompetencies = {
            new HeadingCompetency
            {
                HeadingId = 1,
                CompetencyId = 1,
                Note = "Примітка",
            },
            new HeadingCompetency
            {
                HeadingId = 2,
                CompetencyId = 1,
                Note = null,
            },
            new HeadingCompetency
            {
                HeadingId = 3,
                CompetencyId = 1,
                Note = null
            },
            new HeadingCompetency
            {
                HeadingId = 4,
                CompetencyId = 2,
                Note = null,
            }
        };
        public static MaterialType[] MaterialTypes = {
            new MaterialType
            {
                Id = 1,
                Note = "Примітка",
                ParentId = null
            },
            new MaterialType
            {
                Id = 2,
                Note = null,
                ParentId = 1
            },
            new MaterialType
            {
                Id = 3,
                Note = null,
                ParentId = 1
            },
            new MaterialType
            {
                Id = 4,
                Note = null,
                ParentId = null
            }
        };
        public static MaterialTypeLang[] MaterialTypeLangs = {
            new MaterialTypeLang
            {
                MaterialTypeId = 1,
                LangCode = "UA",
                Name = "Домашнє завдання",
                Description = "Завдання, що дається студенту на самостійне опрацювання"
            },
            new MaterialTypeLang
            {
                MaterialTypeId = 2,
                LangCode = "UA",
                Name = "Практичне завдання",
                Description = null
            },
            new MaterialTypeLang
            {
                MaterialTypeId = 3,
                LangCode = "UA",
                Name = "Теоретичні завдання",
                Description = null
            },
            new MaterialTypeLang
            {
                MaterialTypeId = 4,
                LangCode = "UA",
                Name = "Екзаменаційний проект",
                Description = "Проект, який кожен студент повинен здати у кінці року"
            }
        };

        public static Material[] Materials = {
            new Material
            {
                Id = 1,
                IsPractical = true,
                Note = "Примітка",
            },
            new Material
            {
                Id = 2,
                IsPractical = false,
                Note = null
            },
            new Material
            {
                Id = 3,
                IsPractical = false,
                Note = null
            }
        };

        public static MaterialBlock[] MaterialBlocks =
        {
            new MaterialBlock
            {
                ParentId = 1,
                ChildId = 2,
                Number = 2,
                Note = "Це примітка"
            },
        };

        public static MaterialDependency[] MaterialDependencies =
        {
            new MaterialDependency
            {
                MaterialId = 1,
                BaseMaterialId = 2,
                Note = "Приміточка"
            }
        };

        public static MaterialLang[] MaterialLangs = {
            new MaterialLang
            {
                MaterialId = 1,
                LangCode = "ENG",
                Name = "ASP.NET Core",
                
            },
            new MaterialLang
            {
                MaterialId = 2,
                LangCode = "UA",
                Name = "Запуск приложения. Класс Program",
               
            },
            new MaterialLang
            {
                MaterialId = 3,
                LangCode = "UA",
                Name = "Програмування на C#",
                
            }
        };

        public static MaterialCompetency[] MaterialCompetencies = {
            new MaterialCompetency
            {
                MaterialId = 1,
                CompetencyId = 1,
                Note = "Примітка"
            },
            new MaterialCompetency
            {
                MaterialId = 2,
                CompetencyId = 1,
                Note = null
            },
            new MaterialCompetency
            {
                MaterialId = 3,
                CompetencyId = 1,
                Note = null
            }
        };
        public static HeadingMaterial[] HeadingMaterials = {
            new HeadingMaterial
            {
                HeadingId = 1,
                MaterialId = 1,
                Note = "Примітка"
            },
            new HeadingMaterial
            {
                HeadingId = 2,
                MaterialId = 2,
                Note = null
            },
            new HeadingMaterial
            {
                HeadingId = 3,
                MaterialId = 3,
                Note = null
            },
        };
        #endregion

        #region InfoByThemes
        public static Course[] Courses = {
            new Course
            {
                Id = 1,
                Note = "Примітка"
            },
            new Course
            {
                Id = 2,
                Note = null
            },
            new Course
            {
                Id = 3,
                Note = null
            },
            new Course
            {
                Id = 4,
                Note = null
            }
        };

        public static CourseLang[] CourseLangs = {
            new CourseLang
            {
                CourseId = 1,
                LangCode = "UA",
                Name = "Основи програмування",
                Description = "Курс, у якому зібрані основи програмування"
            },
            new CourseLang
            {
                CourseId = 2,
                LangCode = "UA",
                Name = "Основи алгоритмізації",
                Description = null
            },
            new CourseLang
            {
                CourseId = 3,
                LangCode = "UA",
                Name = "Основи C#",
                Description = null
            },
            new CourseLang
            {
                CourseId = 4,
                LangCode = "ENG",
                Name = "ASP.Net Core"
            },
            new CourseLang
            {
                CourseId = 3,
                LangCode = "Eng",
                Name = "C# Basic",
                Description = "Base about C#"
            }
        };

        public static CourseDependency[] CourseDependencies = {
            //new CourseDependency
            //{
            //    CourseId = 1,
            //    BaseCourseId = null,
            //    Note = "Примітка"
            //},
            new CourseDependency
            {
                CourseId = 2,
                BaseCourseId = 1,
                Note = null
            },
            new CourseDependency
            {
                CourseId = 3,
                BaseCourseId = 1,
                Note = null
            },
            new CourseDependency
            {
                CourseId = 4,
                BaseCourseId = 3,
                Note = null
            }
        };

        public static CourseMaterial[] CourseMaterials =
        {
            new CourseMaterial
            {
                CourseId = 1,
                MaterialId = 1,
                PriorityLevel = 1,
                Note = "Примітка для Курс/Матеріал"
            },
            new CourseMaterial
            {
                CourseId = 1,
                MaterialId = 2,
                PriorityLevel = 2,
                Note = null
            },
            new CourseMaterial
            {
                CourseId = 2,
                MaterialId = 3,
                PriorityLevel = 1,
                Note = "Другий курс"
            }
        };

        public static Theme[] Themes = {
            new Theme
            {
                Id = 1,
                CourseId = 1,
                LevelNumber = 1,
                Number = 1,
                ParentId = null,
                MaterialId = 1,
                Note = "Примітка"
            },
            new Theme
            {
                Id = 2,
                CourseId = 1,
                LevelNumber = 3,
                Number = 2,
                ParentId = null,
                MaterialId = 2,
                Note = null
            },
            new Theme
            {
                Id = 3,
                CourseId = 2,
                LevelNumber = 2,
                Number = 3,
                ParentId = null,
                MaterialId = 2,
                Note = null
            },
            new Theme
            {
                Id = 4,
                CourseId = 2,
                LevelNumber = 2,
                Number = 4,
                ParentId = null,
                MaterialId = 1,
                Note = null
            },
            new Theme
            {
                Id = 5,
                CourseId = 3,
                LevelNumber = 1,
                Number = 5,
                ParentId = null,
                MaterialId = 1,
                Note = null
            },
            new Theme
            {
                Id = 6,
                CourseId = 4,
                LevelNumber = 4,
                Number = 6,
                ParentId = null,
                MaterialId = 1,
                Note = null
            }
        };

        public static ThemeLang[] ThemeLangs ={
            new ThemeLang
            {
                ThemeId = 1,
                LangCode = "UA",
                Name = "Розгалуження",
                Description = "У цій темі розповідаєтсья про оператори if та switch",
            },
            new ThemeLang
            {
                ThemeId = 2,
                LangCode = "UA",
                Name = "Покажчики",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 3,
                LangCode = "UA",
                Name = "Алгоритми сортування",
                Description = "У цій темі описуютсья алгоритми сортування"
            },
            new ThemeLang
            {
                ThemeId = 4,
                LangCode = "ENG",
                Name = "Search algorithms",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 5,
                LangCode = "UA",
                Name = "Класи та структури",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 6,
                LangCode = "ENG",
                Name = "Dependency injection",
                Description = null
            }

        };

        public static CourseHeading[] CourseHeadings = {
            new CourseHeading
            {
                CourseId = 1,
                HeadingId = 4,
                Note = "Примітка"
            },
            new CourseHeading
            {
                CourseId = 2,
                HeadingId = 1,
                Note = null
            },
            new CourseHeading
            {
                CourseId = 3,
                HeadingId = 4,
                Note = null
            },
            new CourseHeading
            {
                CourseId = 4,
                HeadingId = 4,
                Note = null
            }
        };
       
        #endregion

        #region CourseAccess
        public static UserHeading[] UserHeadings;
        public static UserCourse[] UserCourses;
        public static UserTheme[] UserThemes;
        #endregion
    }
}
