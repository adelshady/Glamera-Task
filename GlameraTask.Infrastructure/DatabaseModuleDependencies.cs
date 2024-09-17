using GlameraTask.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Infrastructure
{
    public static class DatabaseModuleDependencies
    {
        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectioString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<GlameraTaskDbContext>(options => options.UseSqlServer(connectioString));
            return services;
        }
    }
}
