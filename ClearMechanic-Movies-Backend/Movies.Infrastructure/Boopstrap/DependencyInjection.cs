using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Contracts;
using Movies.Infrastructure.Persistence;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure.Boopstrap;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder, string connectionString)
    {
        builder.Services.AddSqlServer<AppDbContext>(connectionString, b => b.MigrationsAssembly("Movies.API"));

        builder.Services.AddScoped<IMovieServices, MovieServices>();
        builder.Services.AddScoped<IFreeMovieApiServices, FreeMovieApiServices>();

        return builder;
    }
}

public static class Migration
{
    public static void ApplySqlMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using AppDbContext context = scope.ServiceProvider.GetService<AppDbContext>();

        context.Database.Migrate();
    }
}
