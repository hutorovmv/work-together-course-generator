using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Infrastructure;
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
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.IO;
using CourseGenerator.BLL.DTO.User;
using MongoDB.Driver;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Api
{
#pragma warning disable CS1591
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string[] allowedOrigins = Configuration.GetSection("AllowedOrigins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader();
                });
                options.AddPolicy("DevCorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

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
                c.AddProfile<ViewModelToDTOProfile>();
                c.AddProfile<DTOToViewModelProfile>();
            }, typeof(Startup));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v0.1.0", new OpenApiInfo
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

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme.\n" +
                    "Example: \"Authorization: Bearer {token}\""
                });

                #region JWT Global Auth
                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            }
                //        },
                //        new string[] { }
                //    }
                //});
                #endregion

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.EnableAnnotations();

                options.OperationFilter<SwaggerAuthJWTAttribute>();
            });


            #region Sessions configuration
            //services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = "CourseGenerator.Session";
            //    options.IdleTimeout = TimeSpan.FromDays(1);
            //});
            #endregion
          
            string connectionStringMongoDb = Configuration.GetConnectionString("CourseGeneratorMongoDB");
            
            services.AddSingleton(c => authOptions);

            #region Repositories and Services registration
            services.AddScoped(c => new MongoContext(connectionStringMongoDb));
            services.AddScoped(typeof(IRepository<>), typeof(GenericEFRepository<>));
            services.AddScoped<IPhoneAuthRepository, PhoneAuthRepository>();
            services.AddScoped<IRepository<Language>, GenericEFRepository<Language>>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IRepository<CourseLang>, CourseLangRepository>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IHeadingRepository, HeadingRepository>();
            services.AddScoped<ICodeAuthRepository, CodeAuthRepository>();
            services.AddScoped<IRepository<HeadingLang>, HeadingLangRepository>();
            services.AddScoped<IHeadingManagerRepository, HeadingManagerRepository>();
            services.AddScoped<IUserCoursesRepository, UserCourseRepository>();
            services.AddScoped<IFileRepository, FileMongoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IHeadingService, HeadingService>();
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
                    c.DocumentTitle = "Practifly Api Documentation";
                    c.DocExpansion(DocExpansion.None);
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors("DevCorsPolicy");
            }
            else
            {
                app.UseCors();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            #region User related sample info initialization
            IdentityDataInitializer.AddRoles(roleManager);

            RegisterDTO defaultAdmin = Configuration.GetSection("DefaultAdmin").Get<RegisterDTO>();
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
    #pragma warning restore CS1591
}
