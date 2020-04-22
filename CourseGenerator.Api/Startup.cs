using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Services;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Repositories;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Api.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;
using Microsoft.OpenApi.Models;

namespace CourseGenerator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            string connectionString = Configuration.GetConnectionString("CourseGeneratorDB");
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 8;
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddUserManager<ApplicationUserManager>();

            AuthOptions authOptions = Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();
            services
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = authOptions.Issuer,
                        ValidAudience = authOptions.Audience,
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),

                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAutoMapper(c => {
                c.AddProfile<DomainToDTOProfile>();
                c.AddProfile<DTOToDomainProfile>();
            }, typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.1.0", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Practifly Api",
                    Description = "Документація REST API навчальної платформи Practifly.",
                    #region Additional info
                    /*TermsOfService = new Uri(""),
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = "",
                        Url = new Uri("")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "",
                        Url = new Uri("")
                    }*/
                    #endregion
                });
            });

            #region Sessions configuration
            //services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = "CourseGenerator.Session";
            //    options.IdleTimeout = TimeSpan.FromDays(1);
            //});
            #endregion

            services.AddSingleton(c => authOptions);

            #region Repositories and Services registration
            services.AddScoped(typeof(IRepository<>), typeof(GenericEFRepository<>));
            services.AddScoped<IPhoneAuthRepository, PhoneAuthRepository>();
            services.AddScoped<IRepository<Language>, GenericEFRepository<Language>>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IRepository<UserCourse>, GenericEFRepository<UserCourse>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILanguageService, LanguageService>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, 
            IWebHostEnvironment env, 
            IUserManagementService userManagementService,
            ICourseService courseService,
            RoleManager<Role> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v0.1.0/swagger.json", "Practifly Api v0.1.0");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            #region User related sample info initialization
            IdentityDataInitializer.AddRoles(roleManager);

            UserRegistrationDTO defaultAdmin = Configuration.GetSection("DefaultAdmin").Get<UserRegistrationDTO>();
            IdentityDataInitializer.AddAdmin(userManagementService, defaultAdmin);
            IdentityDataInitializer.AddTestUsersAndCourseAccessData(userManagementService, courseService);
            #endregion

            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
