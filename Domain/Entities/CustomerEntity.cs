using GoalIt.Core.Domain.Common;

namespace Domain.Entities
{
  public class CustomerEntity : AuditableBaseEntity
  {
    public string Name { get; set; }
  }
}