using DigiboxAssessment.Test.Helpers.Persistence.Seeds;
using Infrastructure.Persistence.Contexts;

namespace DigiboxAssessment.Test.Helpers.Persistence.Resources
{
  public static class DbInitializer
  {
    public static void Initialize(CustomersDbContext context)
    {
      CustomerSeed.Seed(context);
    }
  }
}