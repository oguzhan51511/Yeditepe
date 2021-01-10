using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yeditepe.Business.Abstract.Accounts;
using Yeditepe.Models.Accounts;
using YtsFramework.NETCore.Messages;
using YtsFramework.NETCore.Plugins.Authentication.Abstract;

namespace Yeditepe.Api.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public AuthenticationsController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authenticationService.LoginAsync(loginModel);
            if (result.Success) return Ok(result);
            return Unauthorized(result.Message);
        }

        [HttpGet("UserInfo")]
        public async Task<IActionResult> UserInfo()
        {
            if (_userService.IsAuthenticated && _userService.AccountId > 0)
                return Ok(await _authenticationService.UserInfo(_userService.AccountId));
            return Unauthorized("Giriş Yapın");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (!_userService.IsAuthenticated || _userService.AccountId <= 0)
                return BadRequest("Zaten Giriş Yapılmamış");
            await _authenticationService.LogoutAsync(_userService.AccountId);
            return Ok(AccountMessage.LogoutSuccessful);
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromQuery] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken) || refreshToken.Length != 32) return BadRequest(AccountMessage.TokenNotFound);
            var result = await _authenticationService.RefreshAsync(refreshToken);
            if (result.Success) return Ok(result);
            return Unauthorized(result.Message);
        }
    }
}
