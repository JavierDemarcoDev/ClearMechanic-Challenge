using Movies.API.Managers;
using Movies.API.Middlewares;
using Movies.Application.Boopstrap;
using Movies.Infrastructure.Boopstrap;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var settings = builder.Configuration.GetSection("Settings").Get<SettingsManager>();
builder.AddInfrastructure(settings.ConnectionString);
builder.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplySqlMigrations();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
