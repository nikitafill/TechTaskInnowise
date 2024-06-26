
using TechTaskInnowise.Data;
using Microsoft.EntityFrameworkCore;
using TechTaskInnowise.Middleware;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Repositories;

namespace TechTaskInnowise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionsString")));

            builder.Services.AddScoped<IActorRepositories, ActorsRepository>();
            builder.Services.AddScoped<IFilmsRepositories, FilmsRepository>();
            builder.Services.AddScoped<IReviewsRepositories, ReviewsRepository>();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseExceptionHandlingMiddleware();

            app.MapControllers();

            app.Run();
        }
    }
}