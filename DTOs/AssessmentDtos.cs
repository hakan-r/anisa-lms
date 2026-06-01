using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace anisa_lms.DTOs
{
    public class AssessmentBaseDto
    {
        [Required]
        public string Title { get; set; } = "";
        [Precision(18, 2)]
        public decimal MaxPoints { get; set; }
    }

    public class CreateAssessmentDto : AssessmentBaseDto
    {
        [Required]
        public Guid CourseId { get; set; }
    }

    public class UpdateAssessmentDto : AssessmentBaseDto { }

    public class AssessmentDto : AssessmentBaseDto {
        public Guid Id { get; set; }
    }
}
