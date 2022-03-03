using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Digibox.Api
{
  public static class ServiceExtensions
  {
    public static void AddCorsExtension(this IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddDefaultPolicy(
          builder => builder
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader());
        options.AddPolicy("CorsPolicy",
          builder => builder
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());
      });
    }

   

    public static void AddSwaggerExtension(this IServiceCollection services)
    {
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Evaluación técnica Digibox", Version = "v1" });
        c.AddSecurityDefinition("Bearer",
          new OpenApiSecurityScheme
          {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description =
              "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
          });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new List<string>()
          }
        });
        c.ResolveConflictingActions(a => a.FirstOrDefault());
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }

    public static void AddApiVersioningExtension(this IServiceCollection services)
    {
      services.AddApiVersioning(config =>
      {
        config.DefaultApiVersion = new ApiVersion(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
        config.ReportApiVersions = true;
        config.ApiVersionReader = new UrlSegmentApiVersionReader();
      });
    }
  }
}