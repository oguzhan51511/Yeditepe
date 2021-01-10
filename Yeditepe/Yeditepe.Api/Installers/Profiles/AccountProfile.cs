using AutoMapper;
using Yeditepe.Entities.Accounts;
using Yeditepe.Models.Accounts;

namespace Yeditepe.Api.Installers.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountModel>();
            CreateMap<AccountModel, Account>();
            CreateMap<Account, AccountsModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(x => x.Role.Description ?? ""));

            CreateMap<AccountLoginHistory, AccountLoginHistoriesModel>();
            CreateMap<AccountLoginHistory, AccountLoginHistoryModel>();
            CreateMap<AccountLoginHistoryModel, AccountLoginHistory>();

            CreateMap<Role, RolesModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            CreateMap<Rule, RulesModel>();
            CreateMap<Rule, RuleModel>();
            CreateMap<RuleModel, Rule>();
        }
    }
}
