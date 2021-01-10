using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yeditepe.Api.Repositories;
using Yeditepe.Business.Abstract.Accounts;
using Yeditepe.Models.Accounts;
using Yeditepe.Models.Filters;

namespace Yeditepe.Api.Controllers.Accounts
{
    public class AccountsController : ControllerRepository<IAccountService, AccountModel>
    {

        private readonly IAccountService _service;
        public AccountsController(IAccountService service) : base(service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll( [FromQuery] int? roleId, [FromQuery] FilterModel filter) => Ok(await _service.GetAllAsync( roleId, filter));

        [HttpGet("Histories")]
        public async Task<IActionResult> Histories([FromQuery] int accountId) => Ok(await _service.HistoriesAsync(accountId));

    }
}