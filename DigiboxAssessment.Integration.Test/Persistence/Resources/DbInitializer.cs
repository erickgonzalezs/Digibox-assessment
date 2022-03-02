using DigiboxAssessment.Integration.Test.Persistence.Seeds;
using Infrastructure.Persistence.Contexts;

namespace DigiboxAssessment.Integration.Test.Persistence.Resources
{
  public static class DbInitializer
  {
    public static void Initialize(CustomersDbContext context)
    {
      CustomerSeed.Seed(context);
    }
  }
}