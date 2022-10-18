using MagicVilla_VillaApi.Logging.Abstract;
using MagicVilla_VillaApi.Logging.Concrete;
using MagicVilla_VillaApi.Models.Contexts;
using MagicVilla_VillaApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace MagicVilla_VillaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(option=>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));
            // Add services to the container.
            //Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File(
            //   "Serilog/LogHistory.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            //builder.Host.UseSerilog();
            builder.Services.AddControllers(/*option=>*/
            /*option.ReturnHttpNotAcceptable=true*/).AddNewtonsoftJson()/*.AddXmlDataContractSerializerFormatters()*/;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSingleton<ILogging<VillaDto>,Logging<VillaDto>>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}