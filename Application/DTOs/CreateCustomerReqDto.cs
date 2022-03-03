namespace Application.DTOs
{
  public record CreateCustomerReqDto
  {
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
  }
}