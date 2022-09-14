using FluentValidation;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.BrandDtos;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Validators
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
