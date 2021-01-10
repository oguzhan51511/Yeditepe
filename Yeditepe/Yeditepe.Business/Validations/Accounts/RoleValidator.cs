using FluentValidation;
using Yeditepe.Models.Accounts;

namespace Yeditepe.Business.Validations.Accounts
{
    public class RoleValidator : AbstractValidator<RoleModel>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Description).Length(1, 100);
        }
    }
}
