
namespace Glamera_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            //// Add services to the container.
            //Log.Logger = new LoggerConfiguration()
            // .ReadFrom.Configuration(configuration)
            // .CreateLogger();

            // Add services to the container.
            builder.Services
            .AddApiDependencies(configuration)
            .AddInfrastructureDependencies(configuration)
            .AddDatabaseDependencies(configuration)
            .AddDomainDependencies(configuration)
           .AddApplicationDependencies(configuration);


          
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
          


            var AllowedHosts = builder.Configuration.GetValue<string>("AllowedHosts");
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins(AllowedHosts.Split(','))
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
            });
            var app = builder.Build();
            app.UseCors("AllowSpecificOrigin");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
     
            //app.UseSerilogRequestLogging(); // Enable Serilog request logging

            app.UseHttpsRedirection();

            app.UseExceptionHandler(opt => { });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
