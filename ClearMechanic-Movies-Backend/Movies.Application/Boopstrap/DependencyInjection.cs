using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.MappingProfile;

namespace Movies.Application.Boopstrap;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }

        builder.Services.AddAutoMapper(typeof(MoviesMapping));

        return builder;
    }
}
