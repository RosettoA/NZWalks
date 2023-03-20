using FluentValidation;
using NZWalks.Api.Models.DTO;

namespace NZWalks.Api.Validators
{
    public class AddWalkRequestValidator : AbstractValidator<AddWalkRequest>
    {
        public AddWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
