using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace anisa_lms.Controllers
{
    [ApiController]
    [Route("api/module")]
    [Authorize(Roles = "Admin,Instructor")]
    public class ModuleController(IModuleService moduleService) : ControllerBase
    {
        private readonly IModuleService _moduleService = moduleService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModuleDto create)
        {
            await _moduleService.CreateAsync(create);

            return Ok(new { message = "Module created successfully." });
        }

        [HttpPut("{mId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid mId, [FromBody] UpdateModuleDto update)
        {
            var result = await _moduleService.UpdateAsync(mId, update);
            if (result == null) return NotFound(new { message = "Module with given ID does not exist." });

            return NoContent();
        }

        [HttpDelete("{mId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid mId)
        {
            var result = await _moduleService.DeleteAsync(mId);
            if (result == null) return NotFound(new { message = "Module with given ID does not exist." });

            return NoContent();
        }
    }
}
