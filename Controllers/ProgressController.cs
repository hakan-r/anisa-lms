using anisa_lms.DTOs;
using anisa_lms.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace anisa_lms.Controllers
{
    [ApiController]
    [Route("api/progress")]
    [Authorize(Roles = "Admin,Instructor")]
    public class ProgressController(IProgressService progressService) : ControllerBase
    {
        private readonly IProgressService _progressService = progressService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentModuleProgressDto create)
        {
            await _progressService.CreateProgress(create);

            return NoContent();
        }

        [HttpPut("{pId:int}")]
        public async Task<IActionResult> Update([FromRoute] int pId, [FromBody] UpdateStudentModuleProgress update)
        {
            var result = await _progressService.UpdateProgress(pId, update);
            if (result == null) return NotFound(new { message = "Progress with given ID does not exist." });

            return NoContent();
        }

        [HttpDelete("{pId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int pId)
        {
            var result = await _progressService.DeleteProgress(pId);
            if (result == null) return NotFound(new { message = "Progress with given ID does not exist." });

            return NoContent();
        }
    }
}
