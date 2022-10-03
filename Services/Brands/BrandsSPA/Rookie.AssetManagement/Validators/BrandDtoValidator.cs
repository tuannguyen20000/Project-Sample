using FluentValidation;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Business.Interfaces;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Constants;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using System.Threading.Tasks;

namespace Services.Brands.BrandsSPA.Rookie.AssetManagement.Validators
{
    public class BrandDtoValidator : BaseValidator<BrandDto>
    {
        public BrandDtoValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThan(0)
                .WithMessage(x => string.Format(ErrorTypes.Common.NumberGreaterThanError, nameof(x.Id), 0));

            RuleFor(m => m.Name)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)));

            RuleFor(m => m.Type)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Type)));
        }
    }
}
