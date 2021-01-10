using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yeditepe.Business.Abstract.Accounts;
using Yeditepe.DataAccess.Repositories;
using Yeditepe.Entities.Accounts;
using Yeditepe.Models.Accounts;
using YtsFramework.NETCore.Aspects.Security;
using YtsFramework.NETCore.Extensions;
using YtsFramework.NETCore.Helpers;
using YtsFramework.NETCore.Messages;
using YtsFramework.NETCore.Plugins.Authentication.Abstract;
using YtsFramework.NETCore.Plugins.Authentication.Jwt;
using YtsFramework.NETCore.Plugins.Authentication.Models;
using YtsFramework.NETCore.Utilities.Results.DataResult;

namespace Yeditepe.Business.Concrete.Accounts
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IJwtService _jwtService;
        private readonly IDalRepository<Account> _dal;
        private readonly IDalRepository<AccountLoginHistory> _loginHistory;
        private readonly IUserCachingService _userCachingService;
        private readonly IDalRepository<Rule> _ruleDal;
        private readonly WebHelper _helper;

        public AuthenticationService(IJwtService jwtService, IDalRepository<Account> dal, IDalRepository<AccountLoginHistory> loginHistory, WebHelper helper, IUserCachingService userCachingService, IDalRepository<Rule> ruleDal)
        {
            _dal = dal;
            _loginHistory = loginHistory;
            _helper = helper;
            _userCachingService = userCachingService;
            _ruleDal = ruleDal;
            _jwtService = jwtService;
        }

        private async Task<IDataResponse<string>> LoginAsync(Account account)
        {
            if (account == null) return new ErrorDataResponse<string>(null, AccountMessage.AccountNotFound);
            if (account.IsBlocked) return new ErrorDataResponse<string>(null, AccountMessage.AccountIsBlocked);
            await _loginHistory.InsertAsync(new AccountLoginHistory
            {
                AccountId = account.Id,
                Date = DateTime.Now,
                IsSuccess = true,
                IpAddress = _helper.GetIpAddress(),
                Message = AccountMessage.LoginSuccessful.Left(255)
            });
            var accessToken = _jwtService.CreateToken(account.Id);
            var rules = await _ruleDal.TableNoTracking.Where(x => x.RoleId == account.RoleId).ToListAsync();
            await _userCachingService.Set(account.Id, new UserInfo
            {
                AccountId = account.Id,
                FullName = $"{account.FirstName} {account.LastName}",
                IsSuperVisor = account.IsSuperVisor,
                Token = accessToken,
                Rules = account.IsSuperVisor ? null : rules.Select(x => new UserRules
                {
                    ModuleName = x.Module.ToString(),
                    View = x.View,
                    Insert = x.Insert,
                    Update = x.Update,
                    Delete = x.Delete
                }).ToList()
            });
            return new SuccessDataResponse<string>(accessToken.Token, "");
        }
        
        public async Task<IDataResponse<string>> LoginAsync(LoginModel loginModel)
        {
            var account = await _dal.GetAsync(x => x.Email == loginModel.Email);
            if (HashingHelper.VerifyPasswordHash(loginModel.Password, account.PasswordHash, account.PasswordSalt))
                return await LoginAsync(account);

            await _loginHistory.InsertAsync(new AccountLoginHistory
            {
                AccountId = account.Id,
                Date = DateTime.Now,
                IsSuccess = false,
                IpAddress = _helper.GetIpAddress(),
                Message = AccountMessage.PasswordWrong.Left(255)
            });
            return new ErrorDataResponse<string>(null, AccountMessage.PasswordWrong);
        }

        public async Task<IDataResponse<string>> RefreshAsync(string refreshToken)
        {
            var resfreshToken = await _userCachingService.GetByRefreshToken(refreshToken);
            if (resfreshToken == null) return new ErrorDataResponse<string>(null, AccountMessage.TokenExpired);
            return await LoginAsync(await _dal.GetAsync(resfreshToken.AccountId));
        }

        [SecurityAspect]
        public async Task<UserInfo> UserInfo(int accountId) => await _userCachingService.Get(accountId);

        [SecurityAspect]
        public async Task LogoutAsync(int accountId) => await _userCachingService.Remove(accountId);
    }
}
