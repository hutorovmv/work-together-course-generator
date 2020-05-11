using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CourseGenerator.Models;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Configs.Info;
using CourseGenerator.Models.Configs.InfoByThemes;
using CourseGenerator.Models.Configs.CourseAccess;
using CourseGenerator.Models.Configs.Identity;
using CourseGenerator.Models.Configs.Security;
using CourseGenerator.Models.Entities.Security;

namespace CourseGenerator.DAL.Context
{
    public class ApplicationContext : IdentityDbContext<User, Role, string>
    {
        #region Info
        public DbSet<Language> Languages { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<HeadingLang> HeadingLangs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<LevelLang> LevelLangs { get; set; }
        public DbSet<Competency> Competencies { get; set; }
        public DbSet<CompetencyLang> CompetencyLangs { get; set; }
        public DbSet<HeadingCompetency> HeadingCompetencies { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<MaterialTypeLang> MaterialTypeLangs { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialLang> MaterialLangs { get; set; }
        public DbSet<MaterialCompetency> MaterialCompetencies { get; set; }
        public DbSet<HeadingMaterial> HeadingMaterials { get; set; }
        #endregion

        #region InfoByThemes
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLang> CourseLangs { get; set; }
        public DbSet<CourseDependency> CourseDependencies { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ThemeLang> ThemeLangs { get; set; }
        public DbSet<CourseHeading> CourseHeadings { get; set; }

        #endregion

        #region CourseAccess
        public DbSet<UserHeading> UserHeadings { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserTheme> UserThemes { get; set; }
        public DbSet<UserLanguagePriority> UserLanguagePriorities { get; set; }
        public DbSet<HeadingManager> HeadingManagers { get; set; }
        public DbSet<MaterialManager> MaterialManagers { get; set; }
        #endregion


        public DbSet<PhoneAuth> PhoneAuths { get; set; }
        public DbSet<CodeAuth> CodeAuths { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new HeadingConfig());
            modelBuilder.ApplyConfiguration(new HeadingLangConfig());
            modelBuilder.ApplyConfiguration(new LevelConfig());
            modelBuilder.ApplyConfiguration(new LevelLangConfig());
            modelBuilder.ApplyConfiguration(new CompetencyConfig());
            modelBuilder.ApplyConfiguration(new CompetencyLangConfig());
            modelBuilder.ApplyConfiguration(new HeadingCompetencyConfig());
            modelBuilder.ApplyConfiguration(new MaterialTypeConfig());
            modelBuilder.ApplyConfiguration(new MaterialTypeLangConfig());
            modelBuilder.ApplyConfiguration(new MaterialConfig());
            modelBuilder.ApplyConfiguration(new MaterialLangConfig());
            modelBuilder.ApplyConfiguration(new MaterialCompetencyConfig());
            modelBuilder.ApplyConfiguration(new HeadingMaterialConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new CourseLangConfig());
            modelBuilder.ApplyConfiguration(new CourseDependencyConfig());
            modelBuilder.ApplyConfiguration(new ThemeConfig());
            modelBuilder.ApplyConfiguration(new ThemeLangConfig());
            modelBuilder.ApplyConfiguration(new CourseHeadingConfig());
            modelBuilder.ApplyConfiguration(new UserHeadingConfig());
            modelBuilder.ApplyConfiguration(new UserCourseConfig());
            modelBuilder.ApplyConfiguration(new UserThemeConfig());
            modelBuilder.ApplyConfiguration(new MaterialBlockConfig());
            modelBuilder.ApplyConfiguration(new MaterialDependencyConfig());
            modelBuilder.ApplyConfiguration(new CourseMaterialConfig());
            modelBuilder.ApplyConfiguration(new PhoneAuthConfig());
            modelBuilder.ApplyConfiguration(new ContentTypeConfig());
            modelBuilder.ApplyConfiguration(new MaterialDependencyKindConfig());
            modelBuilder.ApplyConfiguration(new MaterialStructureKindConfig());
            modelBuilder.ApplyConfiguration(new CourseDependencyKindConfig());
            modelBuilder.ApplyConfiguration(new OrganizationFormConfig());
            modelBuilder.ApplyConfiguration(new OrganizationFormLangConfig());
            modelBuilder.ApplyConfiguration(new MaterialOrganizationFormConfig());
            modelBuilder.ApplyConfiguration(new ConductingMethodConfig());
            modelBuilder.ApplyConfiguration(new ConductingMethodLangConfig());
            modelBuilder.ApplyConfiguration(new MaterialConductingMethodConfig());
            modelBuilder.ApplyConfiguration(new UserCourseMessageConfig());
            modelBuilder.ApplyConfiguration(new UserMaterialConfig());
            modelBuilder.ApplyConfiguration(new UserMaterialResultConfig());
            modelBuilder.ApplyConfiguration(new UserMaterialMessageConfig());
            modelBuilder.ApplyConfiguration(new GroupConfig());
            modelBuilder.ApplyConfiguration(new UserGroupConfig());
            modelBuilder.ApplyConfiguration(new GroupMessageConfig());
            modelBuilder.ApplyConfiguration(new CodeAuthConfig());
            modelBuilder.ApplyConfiguration(new UserLanguagePriorityConfig());
            modelBuilder.ApplyConfiguration(new HeadingManagerConfig());
            modelBuilder.ApplyConfiguration(new MaterialManagerConfig());

            #region Info block
            modelBuilder.Entity<Language>().HasData(TestData.Languages);
            modelBuilder.Entity<Heading>().HasData(TestData.Headings);
            modelBuilder.Entity<HeadingLang>().HasData(TestData.HeadingLangs);
            modelBuilder.Entity<Level>().HasData(TestData.Levels);
            modelBuilder.Entity<LevelLang>().HasData(TestData.LevelLangs);
            modelBuilder.Entity<Competency>().HasData(TestData.Competencies);
            modelBuilder.Entity<CompetencyLang>().HasData(TestData.CompetencyLangs);
            modelBuilder.Entity<HeadingCompetency>().HasData(TestData.HeadingCompetencies);
            modelBuilder.Entity<MaterialType>().HasData(TestData.MaterialTypes);
            modelBuilder.Entity<MaterialTypeLang>().HasData(TestData.MaterialTypeLangs);
            modelBuilder.Entity<Material>().HasData(TestData.Materials);
            modelBuilder.Entity<MaterialLang>().HasData(TestData.MaterialLangs);
            modelBuilder.Entity<MaterialCompetency>().HasData(TestData.MaterialCompetencies);
            modelBuilder.Entity<HeadingMaterial>().HasData(TestData.HeadingMaterials);
            modelBuilder.Entity<MaterialBlock>().HasData(TestData.MaterialBlocks);
            modelBuilder.Entity<MaterialDependency>().HasData(TestData.MaterialDependencies);

            #endregion

            #region InfoByThemes
            modelBuilder.Entity<Course>().HasData(TestData.Courses);
            modelBuilder.Entity<CourseLang>().HasData(TestData.CourseLangs);
            modelBuilder.Entity<CourseDependency>().HasData(TestData.CourseDependencies);
            modelBuilder.Entity<Theme>().HasData(TestData.Themes);
            modelBuilder.Entity<ThemeLang>().HasData(TestData.ThemeLangs);
            modelBuilder.Entity<CourseHeading>().HasData(TestData.CourseHeadings);
            modelBuilder.Entity<CourseMaterial>().HasData(TestData.CourseMaterials);
            #endregion

            #region CourseAccess
            //modelBuilder.Entity<UserHeading>().HasData(TestData.UserHeadings);
            //modelBuilder.Entity<UserCourse>().HasData(TestData.UserCourses);
            //modelBuilder.Entity<UserTheme>().HasData(TestData.UserThemes);
            #endregion



            base.OnModelCreating(modelBuilder);
        }
    }
}
