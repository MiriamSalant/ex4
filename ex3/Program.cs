
using ex3.Repository;
using ex3.Services;
using ex3.Services.Logger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TasksApi.Services.Logger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksDBcontext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskServices, TaskServices>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<IAttachmentService, AttachmentService>();

/*builder.Services.AddScoped<ILoggerService,ConsoleLoggerService>();
*/
builder.Services.AddScoped<FileLoggerService>(provider =>
    new FileLoggerService("logs.txt")
);

builder.Services.AddScoped<DbLoggerService>();
builder.Services.AddScoped<LoggerRepository>();


builder.Services.AddScoped<TasksApi.Services.Logger.LoggerFactory>();

// Add services to the container.
builder.Services.AddControllers(); // This registers controller services

// Add Swagger services to the container.
builder.Services.AddEndpointsApiExplorer(); // For exposing endpoints

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Books API",
        Description = "A simple example ASP.NET Core API to manage books",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
            Url = new Uri("https://yourwebsite.com"),
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.)
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers(); // This maps attribute-based routing controllers like [Route("api/[controller]")]


app.Run();