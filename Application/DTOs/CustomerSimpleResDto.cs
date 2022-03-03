namespace Application.DTOs
{
  public record CustomerSimpleResDto
  {
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
  }
}