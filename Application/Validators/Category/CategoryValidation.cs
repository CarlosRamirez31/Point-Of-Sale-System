using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validators.Category
{
    public class CategoryValidation : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("El campo Name no puede ser null")
                .NotEmpty().WithMessage("El campo Name no puede estar vacio");

            RuleFor(c => c.Description)
                .MaximumLength(150).WithMessage("El campo description deber ser menor o igual a 150");

            RuleFor(c => c.State)
                .NotNull().WithMessage("El campo state no puede ser null")
                .GreaterThanOrEqualTo(0).WithMessage("El campo state debe ser mayor o igual a 0")
                .LessThanOrEqualTo(1).WithMessage("El campo state debe ser menor o igual a 1");

        }
    }
}
