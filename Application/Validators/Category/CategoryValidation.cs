using Application.Dtos.Category.Request;
using FluentValidation;

namespace Application.Validators.Category
{
    public class CategoryValidation : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("{PropertyName} no puede ser null")
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio");

            RuleFor(c => c.Description)
                .MaximumLength(150).WithMessage("{PropertyName} deber ser menor o igual a 150");

            RuleFor(c => c.State)
                .NotNull().WithMessage("{PropertyName} no puede ser null")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} debe ser mayor o igual a 0")
                .LessThanOrEqualTo(1).WithMessage("{PropertyName} debe ser menor o igual a 1");

        }
    }
}
