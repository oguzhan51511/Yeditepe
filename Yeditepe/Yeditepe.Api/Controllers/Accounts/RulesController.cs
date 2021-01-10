using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yeditepe.Api.Repositories;
using Yeditepe.Business.Abstract.Accounts;
using Yeditepe.Models.Accounts;

namespace Yeditepe.Api.Controllers.Accounts
{
    public class RulesController : ControllerRepository<IRuleService, RuleModel>
    {

        private readonly IRoleService _roleService;
        private readonly IRuleService _service;
        public RulesController(IRuleService service, IRoleService roleService) : base(service)
        {
            _service = service;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery, Required] int roleId)
        {
            if (!await _roleService.AnyAsync(roleId)) return BadRequest("RoleId Not Found");
            return Ok(await _service.GetAllAsync(roleId));
        }

    }
}