using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Application.DTOs;

namespace Web_Shop.Application.Validation
{
    public class AddUpdateProductDTOValidator : AbstractValidator<AddUpdateProductDTO>
    {
        public AddUpdateProductDTOValidator()
        {
            RuleFor(request => request.Name).Length(3, 32).WithMessage("Pole 'Nazwa Produktu' należy wypełnić w zakresie {MinLength} - {MaxLength} znaków");
            RuleFor(request => request.Description).Length(6, 350).WithMessage("Pole 'Opis' należy wypełnić w zakresie {MinLength} - {MaxLength} znaków");
            RuleFor(request => request.Sku)
                .NotEmpty().WithMessage("Pole 'SKU' jest wymagane.")
                .Matches(@"^#[A-Za-z0-9]{3}-[A-Za-z0-9]{3}$")
                .WithMessage("Pole 'SKU' musi być w formacie #xxx-xxx (litery lub cyfry).");
        }
    }
}
