using FluentValidation;
using Yeditepe.Models.Accounts;

namespace Yeditepe.Business.Validations.Accounts
{
    public class AccountValidator : AbstractValidator<AccountModel>
    {
        public AccountValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 35);
            RuleFor(x => x.LastName).Length(1, 20);
            RuleFor(x => x.Gsm).MinimumLength(10).MaximumLength(10);
            RuleFor(x => x.Email).EmailAddress().MaximumLength(100);
        }
    }
}
