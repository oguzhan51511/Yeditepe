using FluentValidation;
using Yeditepe.Models.Accounts;

namespace Yeditepe.Business.Validations.Accounts
{
    public class RuleValidator : AbstractValidator<RuleModel>
    {
        public RuleValidator()
        {
            RuleFor(x => x.Module).Length(1,100);
            RuleFor(x => x.RoleId).GreaterThan(0);
        }
    }
}
