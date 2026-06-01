using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace anisa_lms.Controllers
{
    [ApiController]
    [Route("api/assessment")]
    [Authorize(Roles = "Admin,Instructor")]
    public class AssessmentController(IAssessmentService assessmentService) : ControllerBase
    {
        private readonly IAssessmentService _assessmentService = assessmentService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAssessmentDto create)
        {
            await _assessmentService.CreateAsync(create);

            return Ok(new { message = "Assessment created successfully." });
        }

        [HttpPut("{aId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid aId, [FromBody] UpdateAssessmentDto update)
        {
            var result = await _assessmentService.UpdateAsync(aId, update);
            if (result == null) return NotFound(new { message = "Assessment with given ID does not exist." });

            return NoContent();
        }

        [HttpDelete("{aId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid aId)
        {
            var result = await _assessmentService.DeleteAsync(aId);
            if (result == null) return NotFound(new { message = "Assessment with given ID does not exist." });

            return NoContent();
        }
    }
}
