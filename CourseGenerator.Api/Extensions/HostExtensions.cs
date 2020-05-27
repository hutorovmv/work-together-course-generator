using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CourseGenerator.DAL.Context;

namespace CourseGenerator.Api.Extensions
{
#pragma warning disable CS1591
    public static class HostExtensions
    {
        public static IHost InitDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                ApplicationContext db = services.GetRequiredService<ApplicationContext>();
                
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            return host;
        }
    }
    #pragma warning restore CS1591
}
