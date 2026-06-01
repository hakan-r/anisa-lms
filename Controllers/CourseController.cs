using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace anisa_lms.Controllers
{
    [ApiController]
    [Route("api/course")]
    [Authorize(Roles = "Admin")]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        private readonly ICourseService _courseService = courseService;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto create)
        {
            await _courseService.CreateAsync(create);

            return Ok(new { message = "Course created successfully." });
        }

        [HttpPut("{cId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid cId, [FromBody] UpdateCourseDto update)
        {
            var result = await _courseService.UpdateAsync(cId, update);
            if (result == null) return NotFound(new { message = "Course with given ID does not exist." });

            return NoContent();
        }

        [HttpDelete("{cId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid cId)
        {
            var result = await _courseService.DeleteAsync(cId);
            if (result == null) return NotFound(new { message = "Course with given ID does not exist." });

            return NoContent();
        }
    }
}
