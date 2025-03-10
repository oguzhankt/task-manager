using Microsoft.OpenApi.Models;
using task_manager.Configurations;
using task_manager.Domain.Contexts;
using task_manager.Domain.Repositories.Contracts;
using task_manager.Repositories;
using task_manager.Services;

namespace task_manager;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddDbContext<DataContext>();
        // SQLite Database Setup
        string? connectionString = builder.Configuration.GetConnectionString("Database") ?? "Data Source=Database.db";
        builder.Services.AddSqlite<DataContext>(connectionString);
        
        builder.Services.AddAutoMapper(typeof(MapperConfig));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddScoped<ITaskService, TaskService>();
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();
        
        
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Task Management API",
                Version = "v1",
                Description = "Task API used to manage a todo list",
            });
        });

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


