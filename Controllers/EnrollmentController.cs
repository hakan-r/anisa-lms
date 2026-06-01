using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace anisa_lms.Controllers
{
    [ApiController]
    [Route("api/enrollment")]
    [Authorize(Roles = "Admin,Instructor")]
    public class EnrollmentController(IEnrollmentService enrollmentService) : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService = enrollmentService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentDto create)
        {
            await _enrollmentService.CreateAsync(create);

            return Ok(new { message = "Student enrolled successfully." });
        }

        [HttpPut("{eId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid eId, [FromBody] UpdateEnrollmentDto update)
        {
            var enrollment = await _enrollmentService.UpdateAsync(eId, update);
            if (enrollment == null) return NotFound(new { message = "Enrollment with given ID does not exist." });

            return NoContent();
        }

        [HttpDelete("{eId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid eId)
        {
            var enrollment = await _enrollmentService.DeleteAsync(eId);
            if (enrollment == null) return NotFound(new { message = "Enrollment with given ID does not exist." });

            return NoContent();
        }
    }
}
