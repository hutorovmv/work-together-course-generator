﻿using System;
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
                Id = 1,
                Code = "UA",
                Name = "Українська",
                OriginalName = "Українська",
                Note = "Примітка"
            },
            new Language
            {
                Id = 2,
                Code = "RU",
                Name = "Російська",
                OriginalName = "Русская",
            },
            new Language
            {
                Id = 3,
                Code = "EN",
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
                LangId = 1
            },
            new HeadingLang
            {
                HeadingId = 2,
                Name = "Модифікації сортування вставками",
                Description = null,
                LangId = 1,
            },
            new HeadingLang
            {
                HeadingId = 3,
                Name = "Алгоритм Шела",
                Description = null,
                LangId = 1
            },
            new HeadingLang
            {
                HeadingId = 4,
                Name = "Програмування",
                Description = "У цій рубриці знаходяться матеріали про програмування",
                LangId = 3
            }
        };

        public static Level[] Levels = {
            new Level
            {
                Id = 1,
                Number = 2,
                Note = "Basic Level"
            },
            new Level
            {
                Id = 2,
                Number = 3,

            },
            new Level
            {
                Id = 3,
                Number = 4,

            },
            new Level
            {
                Id = 4,
                Number = 5,

            }
        };

        public static LevelLang[] LevelLangs = {
            new LevelLang
            {
                LevelId = 1,
                Name = "Базова",
                Description = "Потребує частого керівництва"
            },
            new LevelLang
            {
                LevelId = 2,
                Name = "Проміжна",
                Description = "Потребує періодичного керівництва"
            },
            new LevelLang
            {
                LevelId = 3,
                Name = "Продвинута",
                Description = "Applies the competency in considerably difficult situations." +
                "Generally requires little or no guidance."
            },
            new LevelLang
            {
                LevelId = 4,
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
                LevelId = 1
            },
            new Competency
            {
                Id = 2,
                ParentId = 1,
                LevelId = 2
            },
            new Competency
            {
                Id = 3,
                ParentId = null,
                LevelId = 2
            },

        };

        public static CompetencyLang[] CompetencyLangs = {
            new CompetencyLang
            {
                CompetencyId = 1,
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
                LangId = 1,
                Name = "Домашнє завдання",
                Description = "Завдання, що дається студенту на самостійне опрацювання"
            },
            new MaterialTypeLang
            {
                MaterialTypeId = 2,
                LangId = 1,
                Name = "Практичне завдання",
                Description = null
            },
            new MaterialTypeLang
            {
                MaterialTypeId = 3,
                LangId = 1,
                Name = "Теоретичні завдання",
                Description = null
            },
            new MaterialTypeLang
            {
                MaterialTypeId = 4,
                LangId = 3,
                Name = "Екзаменаційний проект",
                Description = "Проект, який кожен студент повинен здати у кінці року"
            }
        };

        public static Material[] Materials = {
            new Material
            {
                Id = 1,
                Number = 1,
                FileUrl = "Material.mp4",
                BackImageUrl = "background.jpg",
                Url = "metanit.com",
                Note = "Примітка",
                MaterialTypeId = 1,
                ParentId = null,
            },
            new Material
            {
                Id = 2,
                Number = 2,
                FileUrl = "Video.mp4",
                BackImageUrl = "bg.jpg",
                Url = "professorweb.ru",
                MaterialTypeId = 1,
                ParentId = 1,
            },
            new Material
            {
                Id = 3,
                Number = 3,
                FileUrl = "Content.mov",
                BackImageUrl = "bg.png",
                Url = null,
                MaterialTypeId = 2,
                ParentId = null
            }
        };

        public static MaterialLang[] MaterialLangs = {
            new MaterialLang
            {
                MaterialId = 1,
                Name = "ASP.NET Core",
                FileUrl = "MaterialEng.mp4",
                BackImageLangUrl = "backgroundEng.jpg",
                Text = "Платформа ASP.NET Core представляет технологию от компании " +
                "Microsoft, предназначенную для создания различного рода веб-приложений:" +
                " от небольших веб-сайтов до крупных веб-порталов и веб-сервисов.",
                LangId = 3
            },
            new MaterialLang
            {
                MaterialId = 2,
                Name = "Запуск приложения. Класс Program",
                FileUrl = null,
                BackImageLangUrl = null,
                Text = "В любом типе проектов ASP.NET Core, как и в проекте консольного" +
                " приложения, мы можем найти файл Program.cs, в котором определен " +
                "одноименный класс Program и с которого по сути начинается выполнение " +
                "приложения. В ASP.NET Core 3 этот файл выглядит следующим образом:"
            },
            new MaterialLang
            {
                MaterialId = 3,
                Name = "Програмування на C#",
                FileUrl = null,
                BackImageLangUrl = null,
                Text = "..."
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
                LevelId = 1,
                Note = "Примітка"
            },
            new Course
            {
                Id = 2,
                LevelId = 1,
                Note = null
            },
            new Course
            {
                Id = 3,
                LevelId = 2,
                Note = null
            },
            new Course
            {
                Id = 4,
                LevelId = 3,
                Note = null
            }
        };

        public static CourseLang[] CourseLangs = {
            new CourseLang
            {
                CourseId = 1,
                LangId = 1,
                Name = "Основи програмування",
                Description = "Курс, у якому зібрані основи програмування"
            },
            new CourseLang
            {
                CourseId = 2,
                LangId = 1,
                Name = "Основи алгоритмізації",
                Description = null
            },
            new CourseLang
            {
                CourseId = 3,
                LangId = 3,
                Name = "Основи C#",
                Description = null
            },
            new CourseLang
            {
                CourseId = 4,
                LangId = 4,
                Name = "ASP.Net Core"
            }
        };

        public static CourseDependency[] CourseDependencies = {
            new CourseDependency
            {
                CourseId = 1,
                BaseCourseId = null,
                Note = "Примітка"
            },
            new CourseDependency
            {
                CourseId = 2,
                BaseCourseId = null,
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

        public static Theme[] Themes = {
            new Theme
            {
                Id = 1,
                CourseId = 1,
                LevelId = 1,
                ParentId = null,
                Note = "Примітка"
            },
            new Theme
            {
                Id = 2,
                CourseId = 1,
                LevelId = 3,
                ParentId = null,
                Note = null
            },
            new Theme
            {
                Id = 3,
                CourseId = 2,
                LevelId = 2,
                ParentId = null,
                Note = null
            },
            new Theme
            {
                Id = 4,
                CourseId = 2,
                LevelId = 2,
                ParentId = null,
                Note = null
            },
            new Theme
            {
                Id = 5,
                CourseId = 3,
                LevelId = 1,
                ParentId = null,
                Note = null
            },
            new Theme
            {
                Id = 6,
                CourseId = 4,
                LevelId = 4,
                ParentId = null,
                Note = null
            }
        };

        public static ThemeLang[] ThemeLangs ={
            new ThemeLang
            {
                ThemeId = 1,
                LangId = 1,
                Name = "Розгалуження",
                Description = "У цій темі розповідаєтсья про оператори if та switch",
            },
            new ThemeLang
            {
                ThemeId = 2,
                LangId = 1,
                Name = "Покажчики",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 3,
                LangId = 3,
                Name = "Алгоритми сортування",
                Description = "У цій темі описуютсья алгоритми сортування"
            },
            new ThemeLang
            {
                ThemeId = 4,
                LangId = 3,
                Name = "Алгоритми пошуку",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 5,
                LangId = 1,
                Name = "Класи та структури",
                Description = null
            },
            new ThemeLang
            {
                ThemeId = 6,
                LangId = 1,
                Name = "Впровадження залежностей",
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
        public static ThemeHeading[] ThemeHeadings = {
            new ThemeHeading
            {
                ThemeId = 1,
                HeadingId = 4,
                LevelId = 1,
                Note = "Примітка"
            },
            new ThemeHeading
            {
                ThemeId = 2,
                HeadingId = 4,
                LevelId = 3,
                Note = null
            },
            new ThemeHeading
            {
                ThemeId = 3,
                HeadingId = 1,
                LevelId = 3,
                Note = null
            },
            new ThemeHeading
            {
                ThemeId = 4,
                HeadingId = 1,
                LevelId = 3,
                Note = null
            },
            new ThemeHeading
            {
                ThemeId = 5,
                HeadingId = 4,
                LevelId = 1,
                Note = null
            },
            new ThemeHeading
            {
                ThemeId = 6,
                HeadingId = 4,
                LevelId = 4,
                Note = null
            },
        };
        public static ThemeMaterial[] ThemeMaterials = {
            new ThemeMaterial
            {
                ThemeId = 1,
                MaterialId = 3,
                Note = "Примітка"
            },
            new ThemeMaterial
            {
                ThemeId = 2,
                MaterialId = 3,
                Note = null
            },
            new ThemeMaterial
            {
                ThemeId = 3,
                MaterialId = 3,
                Note = null
            },
            new ThemeMaterial
            {
                ThemeId = 4,
                MaterialId = 3,
                Note = null
            },
            new ThemeMaterial
            {
                ThemeId = 5,
                MaterialId = 3,
                Note = null
            },
            new ThemeMaterial
            {
                ThemeId = 6,
                MaterialId = 3,
                Note = null
            },
        };
        #endregion

        #region CourseAccess
        public static UserHeading[] UserHeadings;
        public static UserCourse[] UserCourses;
        public static UserTheme[] UserThemes;
        #endregion
    }
}
