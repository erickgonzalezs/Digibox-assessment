using System;
using Application;
using Infrastructure.Persistence;
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

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddApplicationLayer();
      services.AddMediatR(typeof(Startup));
      services.AddPersistenceInfrastructure(Configuration);
      services.AddSwaggerExtension();
      services.AddApiVersioningExtension();
      services.AddCorsExtension();
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      //SeedManager.InitializeDatabase(app);          
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