using System;
using Application;
using Infrastructure.Persistence.Seeds;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Digibox.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddApplicationLayer();
      services.AddMediatR(typeof(Startup));
      services.AddRelatedInfrastructures(Configuration);
      services.AddSwaggerExtension();
      services.AddApiVersioningExtension();
      services.AddCorsExtension();
      services.AddControllers();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        if(Configuration.GetSection("SeedDb").Get<bool>()) SeedManager.InitializeDatabase(app, env);   
      }
      app.UseRouting();
      app.UseCors("CorsPolicy");
      app.UseAuthorization();
      app.UseErrorHandlingMiddleware();
      app.UseSwaggerExtension();
      app.UseEndpoints(endpoints => endpoints.MapControllers());
      Console.WriteLine($"******** Running Environment: {env.EnvironmentName}  ********\n\n");
    }
  }
}