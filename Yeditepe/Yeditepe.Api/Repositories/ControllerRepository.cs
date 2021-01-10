using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yeditepe.Business.Repositories;
using YtsFramework.NETCore.Extensions;
using YtsFramework.NETCore.Signatures;

namespace Yeditepe.Api.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerRepository<TService, TModel> : ControllerBase
        where TModel : class, IBaseModel, new()
        where TService : class, IServiceRepository<TModel>

    {
        private readonly TService _service;
        public ControllerRepository(TService service) => _service = service;

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!await _service.AnyAsync(id)) return BadRequest("Data not found");
            return Ok(await _service.GetAsync(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Insert([FromBody] TModel model) => Ok(await _service.InsertAsync(model));

        [HttpPost("InsertRange")]
        public virtual async Task<IActionResult> InsertRange([FromBody] List<TModel> models) => Ok((await _service.InsertRangeAsync(models)).ToJson());

        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TModel model) => Ok(await _service.UpdateAsync(model));

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id) => Ok(await _service.DeleteAsync(id));

        [HttpDelete("DeleteRange")]
        public virtual async Task<IActionResult> DeleteRange([FromBody] List<int> list) => Ok((await _service.DeleteRangeAsync(list)).ToJson());

        [HttpPost("RemoveCache")]
        public virtual async Task<IActionResult> RemoveCache()
        {
            await _service.RemoveCacheAsync();
            return Ok("Bellek Silindi.");
        }
    }
}