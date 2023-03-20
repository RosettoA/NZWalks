using FluentValidation;
using NZWalks.Api.Models.DTO;

namespace NZWalks.Api.Validators
{
    public class AddWalkDifficultyRequestValidator : AbstractValidator<AddWalkDifficultyRequest>
    {
        public AddWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
