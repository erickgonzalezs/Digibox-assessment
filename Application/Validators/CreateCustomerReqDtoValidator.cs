using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
  public class CreateCustomerReqDtoValidator : AbstractValidator<CreateCustomerReqDto>
  {
    public CreateCustomerReqDtoValidator()
    {
      RuleFor(x => x.CustomerId)
        .NotEmpty()
        .NotNull()
        .MinimumLength(16)
        .MaximumLength(32)
        .WithMessage("El valor del ID debe ser mínimo 16 caracteres y máximo 32");
      RuleFor(x => x.CustomerName)
        .NotEmpty()
        .NotNull()
        .MinimumLength(4)
        .MaximumLength(100)
        .WithMessage("El valor del Nombre debe ser mínimo 4 caracteres y máximo 100");
    }
  }
}