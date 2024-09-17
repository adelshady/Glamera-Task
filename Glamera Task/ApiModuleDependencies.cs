using GlameraTask.Application.Services.Implementation;
using GlameraTask.Application.Services.Interfaces;
using GlameraTask.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GlameraTask
{
    public static class ApiModuleDependencies
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GlameraTaskDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IReportService, ReportService>();

            //services.AddControllers(options =>
            //{
            //    options.Filters.Add<CustomExceptionFilterAttribute>();
            //});

            return services;
        }
    }
}
