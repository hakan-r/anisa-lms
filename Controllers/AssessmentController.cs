using anisa_lms.DTOs;
using anisa_lms.Interfaces.IService;
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

        [HttpGet("{aId:int}/results")]
        public async Task<IActionResult> GetResults([FromRoute] int aId, [FromQuery] bool passed)
        {
            return Ok(await _assessmentService.GetResults(aId, passed));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAssessmentDto create)
        {
            await _assessmentService.CreateAssessment(create);

            return Ok(new { message = "Assessment created successfully." });
        }

        [HttpPut("{aId:int}")]
        public async Task<IActionResult> Update([FromRoute] int aId, [FromBody] UpdateAssessmentDto update)
        {
            var result = await _assessmentService.UpdateAssessment(aId, update);
            if (result == null) return NotFound(new { message = "Assessment with given ID does not exist." });

            return NoContent();
        }

        [HttpDelete("{aId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int aId)
        {
            var result = await _assessmentService.DeleteAssessment(aId);
            if (result == null) return NotFound(new { message = "Assessment with given ID does not exist." });

            return NoContent();
        }
    }
}
