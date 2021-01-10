using System.Threading.Tasks;
using Yeditepe.Models.Accounts;
using YtsFramework.NETCore.Plugins.Authentication.Models;
using YtsFramework.NETCore.Utilities.Results.DataResult;

namespace Yeditepe.Business.Abstract.Accounts
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Account Login
        /// </summary>
        /// <param name="loginModel">Email and Password</param>
        /// <returns>return Token, RefreshToken, TokenExpiration</returns>
        Task<IDataResponse<string>> LoginAsync(LoginModel loginModel);

        /// <summary>
        /// Get User Info
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<UserInfo> UserInfo(int accountId);

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task LogoutAsync(int accountId);


        /// <summary>
        /// Login By Refresh Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<IDataResponse<string>> RefreshAsync(string refreshToken);
    }
}