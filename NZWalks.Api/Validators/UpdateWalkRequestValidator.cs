using FluentValidation;
using NZWalks.Api.Models.DTO;

namespace NZWalks.Api.Validators
{
    public class UpdateWalkRequestValidator : AbstractValidator<UpdateWalkRequest>
    {
        public UpdateWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
