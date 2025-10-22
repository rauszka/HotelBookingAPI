using HotelBookingAPI.Controllers.Booking;
using HotelBookingAPI.Controllers.Room;
using HotelBookingAPI.Repositorys;
using Microsoft.OpenApi.Models;

namespace HotelBookingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IRoomRepository, InMemoryRoomRepository>();
            builder.Services.AddSingleton<IBookingRepository, InMemoryBookingRepository>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hotel Booking API",
                    Version = "v1",
                    Description = "API for managing hotel rooms and bookings"
                });

                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel Booking API");
                    options.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
