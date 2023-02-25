﻿using Application.Dtos.Request;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace Application.Validators.Category
{
    public class CategoryValidation : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("El campo Name no puede ser null")
                .NotEmpty().WithMessage("El campo Name no puede estar vacio");
        }
    }
}
