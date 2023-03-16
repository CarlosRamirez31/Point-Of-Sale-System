using Application.Dtos.Provider.Request;
using FluentValidation;

namespace Application.Validators.Provider
{
    public class ProviderValidator : AbstractValidator<ProviderRequestDto>
    {
        public ProviderValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} No puede estar vacio")
                .MaximumLength(130).WithMessage("{PropertyName} no puede ser mayor a 130");
        }
    }
}
