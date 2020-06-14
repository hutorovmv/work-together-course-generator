using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Content;
using System;
using System.Collections.Generic;

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
                Code = "1",
                UDC = "01",
                Note = "Примітка"
            },
            new Heading
            {
                Id = 2,
                Code = "1.1",
                UDC = "1.1",
                Note = "Дочірня рубрика минулої"
            },
            new Heading
            {
                Id = 3,
                Code = "1.1.1",
                UDC = "1.1.1",
                Note = null
            },
            new Heading
            {
                Id = 4,
                Code = "1.1.2",
                UDC = "1.1.2",
                Note = null
            },
            new Heading
            {
                Id = 5,
                Code = "2",
                UDC = "2",
                Note = "Нова рубрика"
            },
            new Heading
            {
                Id = 6,
                Code = "1.1.1.1",
                UDC = "1.1.1.1",
                Note = null
            },
            new Heading
            {
                Id = 7,
                Code = "2.1",
                UDC = "2.1",
                Note = "New Test Heading"
            },
            new Heading
            {
                Id = 8,
                Code = "3",
                UDC = "3",
                Note = null
            },
            new Heading
            {
                Id = 9,
                Code = "4",
                UDC = "3",
                Note = null
            },
            new Heading
            {
                Id = 10,
                Code = "5",
                UDC = "3",
                Note = null
            },
            new Heading
            {
                Id = 11,
                Code = "6",
                UDC = "3",
                Note = null
            },
        };

        public static HeadingLang[] HeadingLangs = {
            new HeadingLang
            {
                HeadingId = 1,
                Name = "Алгоритми",
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
            },
            new HeadingLang
            {
                HeadingId = 5,
                Name = "New Heading",
                Description = "Heading for test",
                LangCode = "ENG"
            },
            new HeadingLang
            {
                HeadingId = 6,
                Name = "New SubHeading",
                Description = "This SubHeading is heading for previous",
                LangCode = "ENG"
            },
            new HeadingLang
            {
                HeadingId = 7,
                Name = "SubHeading for second heading",
                Description = "This is good subheading",
                LangCode = "ENG"
            },
            new HeadingLang
            {
                HeadingId = 8,
                Name = "Файлове введення/виведення",
                Description = null,
                LangCode = "UA"
            },
            new HeadingLang
            {
                HeadingId = 9,
                Name = "Класи і об'єкти",
                Description = null,
                LangCode = "UA"
            },
            new HeadingLang
            {
                HeadingId = 10,
                Name = "Узагальнене проектування",
                Description = null,
                LangCode = "UA"
            },
            new HeadingLang
            {
                HeadingId = 11,
                Name = "Успадкування",
                Description = null,
                LangCode = "UA"
            },
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
            },
            new Material
            {
                Id = 4,
                IsPractical = false,
                Note = null
            },
            new Material
            {
                Id = 5,
                IsPractical = false,
                Note = null
            },
            new Material
            {
                Id = 6,
                IsPractical = true,
                Note = "Практична робота"
            },
            new Material
            {
                Id = 7,
                IsPractical = false,
                Note = "Ієрархії класів"
            },
            new Material
            {
                Id = 8,
                IsPractical = false,
                Note = "Покажчики першого порядку"
            },
            new Material
            {
                Id = 9,
                IsPractical = false,
                Note = "Покажчики на методи"
            },
            new Material
            {
                Id = 10,
                IsPractical = false,
                Note = "Покажчики на масиви"
            },
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
            },
            new MaterialLang
            {
                MaterialId = 4,
                LangCode = "UA",
                Name = "Оператор if",
            },
            new MaterialLang
            {
                MaterialId = 5,
                LangCode = "UA",
                Name = "Оператор switch",
            },
            new MaterialLang
            {
                MaterialId = 6,
                LangCode = "UA",
                Name = "Практична робота з операторами розгалуження"
            },
            new MaterialLang
            {
                MaterialId = 7,
                LangCode = "ENG",
                Name = "Class Hierarchy"
            },
            new MaterialLang
            {
                MaterialId = 8,
                LangCode = "UA",
                Name = "Покажчики першого порядку"
            },
             new MaterialLang
            {
                MaterialId = 9,
                LangCode = "UA",
                Name = "Покажчики на методи"
            },
              new MaterialLang
            {
                MaterialId = 10,
                LangCode = "UA",
                Name = "Покажчики на масиви"
            },
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
                CourseId = 3,
                LevelNumber = 1,
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
                CourseId = 3,
                LevelNumber = 1,
                Number = 6,
                ParentId = 5,
                MaterialId = 1,
                Note = null
            },
            new Theme
            {
                Id = 7,
                CourseId = 1,
                LevelNumber = 1,
                Number = 7,
                ParentId = 1,
                MaterialId = 4
            },
            new Theme
            {
                Id = 8,
                CourseId = 1,
                LevelNumber = 1,
                Number = 8,
                ParentId = 1,
                MaterialId = 5
            },
            new Theme
            {
                Id = 9,
                CourseId = 1,
                LevelNumber = 2,
                Number = 9,
                ParentId = 1,
                MaterialId = 6
            },
            new Theme
            {
                Id = 10,
                CourseId = 1,
                LevelNumber = 3,
                Number = 10,
                ParentId = null,
                MaterialId = 7
            },
            new Theme
            {
                Id = 11,
                CourseId = 1,
                LevelNumber = 3,
                Number = 11,
                ParentId = 2,
                MaterialId = 8 
            },
            new Theme
            {
                Id = 12,
                CourseId = 1,
                LevelNumber = 3,
                Number = 11,
                ParentId = 2,
                MaterialId = 9
            },
            new Theme
            {
                Id = 13,
                CourseId = 1,
                LevelNumber = 3,
                Number = 11,
                ParentId = 2,
                MaterialId = 10
            },
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
                ThemeId = 4,
                LangCode = "UA",
                Name = "Пошукові алгоритми",
                Description = "Тут опис"
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
            },
            new ThemeLang
            {
                ThemeId = 7,
                LangCode = "UA",
                Name = "Використання оператору if",
                Description = "У цій темі описано нюанси використання " +
                "оператору розгалуження if"
            },
            new ThemeLang
            {
                ThemeId = 8,
                LangCode = "UA",
                Name = "Використання оператору switch",
                Description = "У цій темі описано нюанси використання " +
                "оператору розгалуження switch"
            },
            new ThemeLang
            {
                ThemeId = 9,
                LangCode = "UA",
                Name = "Практична робота з розгалуженням",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 10,
                LangCode = "ENG",
                Name = "Class Hierarchy",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 11,
                LangCode = "UA",
                Name = "Покажчики першого порядку",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 12,
                LangCode = "UA",
                Name = "Покажчики на методи",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 13,
                LangCode = "UA",
                Name = "Покажчики на масиви",
                Description = null
            },
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

        public static MaterialManager[] MaterialManagers =
        {
            new MaterialManager
            {
                UserId = "User1",
                MaterialId = 1,
                IsOwner = false,
                Note = "Примітка"
            }
        };
        #endregion

        #region documentalDataBase
        public static Article[] Articles =
        {
            new Article
            {
                Author = "Andrew Ryzhkov",
                LastEdited = new DateTime(2020, 04, 29),
                LastEditedBy = "Mykola Hutorov",
                SourceUris = new List<string> { "wikipedia.org/source-1", "wikipedia.org/source-2"},
                Localization = new List<ArticleLang>
                {
                    new ArticleLang
                    {
                        LangCode = "UA",
                        Heading = "Основи C#",
                        FileId = null
                    },
                    new ArticleLang
                    {
                        LangCode = "RU",
                        Heading = "Основы C#",
                        FileId = null
                    },
                    new ArticleLang
                    {
                        LangCode = "EN",
                        Heading = "C# Basic",
                        FileId = null
                    }
                }
            },
            new Article
            {
                Author = "Vyacheslav Nikinyk",
                LastEdited = new DateTime(2020, 04, 29),
                LastEditedBy = "Oleksandr Volos",
                SourceUris = new List<string> { "wikipedia.org/source-1", "wikipedia.org/source-2"},
                Localization = new List<ArticleLang>
                {
                    new ArticleLang
                    {
                        LangCode = "UA",
                        Heading = "Алогритми",
                        FileId = null
                    },
                    new ArticleLang
                    {
                        LangCode = "RU",
                        Heading = "Алогритми",
                        FileId = null
                    },
                }
            },
        };
        #endregion
    }
}
