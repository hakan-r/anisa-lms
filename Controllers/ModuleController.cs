using anisa_lms.DTOs;
using anisa_lms.Interfaces.IService;
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

        [HttpGet("~/api/course/{cId:int}/module")]
        public async Task<IActionResult> GetModulesForStudent([FromRoute] int cId, [FromBody] string studentId)
        {
            return Ok(await _moduleService.GetModulesForStudent(cId, studentId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModuleDto create)
        {
            await _moduleService.CreateModule(create);

            return Ok(new { message = "Module created successfully." });
        }

        [HttpPut("{mId:int}")]
        public async Task<IActionResult> Update([FromRoute] int mId, [FromBody] UpdateModuleDto update)
        {
            var result = await _moduleService.UpdateModule(mId, update);
            if (result == null) return NotFound(new { message = "Module with given ID does not exist." });

            return NoContent();
        }

        [HttpDelete("{mId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int mId)
        {
            var result = await _moduleService.DeleteModule(mId);
            if (result == null) return NotFound(new { message = "Module with given ID does not exist." });

            return NoContent();
        }
    }
}
