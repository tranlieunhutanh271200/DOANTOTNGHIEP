using FluentValidation;
using Service.Core.Models.Identities;

namespace Service.Core.Models.Validators.Identites
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Username).NotEmpty().Length(10);
        }
    }
}
