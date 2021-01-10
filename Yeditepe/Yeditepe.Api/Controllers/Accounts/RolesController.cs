using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yeditepe.Api.Repositories;
using Yeditepe.Business.Abstract.Accounts;
using Yeditepe.Models.Accounts;
using Yeditepe.Models.Filters;

namespace Yeditepe.Api.Controllers.Accounts
{
    public class RolesController : ControllerRepository<IRoleService, RoleModel>
    {

        private readonly IRoleService _service;
        public RolesController(IRoleService service) : base(service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterModel filter) => Ok(await _service.GetAllAsync(filter));

        [HttpGet("Select")]
        public async Task<IActionResult> SelectList() => Ok(await _service.SelectAsync());

    }
}