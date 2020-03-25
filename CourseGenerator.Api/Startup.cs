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
using AutoMapper;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Services;
using CourseGenerator.BLL.Repositories;
using CourseGenerator.DAL.Context;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.BLL.Infrastructure;

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

            string connectionString = Configuration.GetConnectionString("CourseGeneratorDB");
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<ApplicationContext>();

            services.AddAutoMapper(c => {
                c.AddProfile<DomainToDTOProfile>();
                c.AddProfile<DTOToDomainProfile>();
            }, typeof(Startup));

            services.AddScoped(typeof(IGenericEFRepository<>), typeof(GenericEFRepository<>));
            
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserManagementService, UserManagementService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider sp)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //IUnitOfWork uow = sp.GetService<IUnitOfWork>();

            //AddDefaultRoles(uow, new string[] {
            //    "Admin",
            //    "ContentAdmin",
            //    "ContentManager",
            //    "User"
            //});
        }

        private async void AddDefaultRoles(IUnitOfWork uow, string[] roles)
        {
            foreach (var role in roles) {
                var exists = await uow.RoleManager.RoleExistsAsync(role);
                if (!exists)
                    await uow.RoleManager.CreateAsync(new Role(role));
            }
        }
    }
}
