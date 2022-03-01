using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using GoalIt.Core.Application.Behaviours;

namespace Application
{
  public static class ApplicationInjector
  {
    public static void AddApplicationLayer(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      services.AddFluentValidation(s =>
      {
        s.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      });
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogginBehaviour<,>));
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
      
    }
  }
}