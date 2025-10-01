using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Template.Core;

namespace Template.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            AddSwaggerDocumentation(c);

            AddSwaggerAuthentication(c);
        });

        return services;
    }

    private static void AddSwaggerDocumentation(SwaggerGenOptions c)
    {
        c.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = $"{Constants.ApplicationName} API",
                Version = "v1",
                Description = "Describe API here in the future",
            }
        );

        var currentAssembly = Assembly.GetExecutingAssembly();

        var xmlFile = $"{currentAssembly.GetName().Name}.xml";

        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        c.IncludeXmlComments(xmlPath);

        var xmlDocs = currentAssembly
            .GetReferencedAssemblies()
            .Union([currentAssembly.GetName()])
            .Select(a =>
                Path.Combine(Path.GetDirectoryName(currentAssembly.Location)!, $"{a.Name}.xml")
            )
            .Where(File.Exists)
            .ToArray();

        Array.ForEach(xmlDocs, (d) => c.IncludeXmlComments(d));
    }

    private static void AddSwaggerAuthentication(SwaggerGenOptions c)
    {
        c.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                In = ParameterLocation.Header,
                Description = "JWT Authorization Header using Bearer method.",
            }
        );

        c.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    Array.Empty<string>()
                },
            }
        );
    }
}
