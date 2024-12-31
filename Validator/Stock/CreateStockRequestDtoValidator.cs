using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using FluentValidation;

namespace api.Validator
{
    public class CreateStockRequestDtoValidator : AbstractValidator<CreateStockRequestDto>
    {
        public CreateStockRequestDtoValidator()
        {
            RuleFor(x => x.Symbol).NotEmpty().WithMessage("Symbol is required.");
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("CompanyName is required.");
            RuleFor(x => x.Pruchase).GreaterThan(0).WithMessage("Purchase must be greater than 0.");
            RuleFor(x => x.LastDiv).GreaterThanOrEqualTo(0).WithMessage("LastDiv must be a non-negative number.");
            RuleFor(x => x.Industry).NotEmpty().WithMessage("Industry is required.");
            RuleFor(x => x.MarketCap).GreaterThan(0).WithMessage("MarketCap must be greater than 0.");
        }
    }
}