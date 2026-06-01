using System.ComponentModel.DataAnnotations;

namespace anisa_lms.DTOs
{
    public class EnrollmentBaseDto
    {
        public decimal ProgressPercentage { get; set; }
    }

    public class CreateEnrollmentDto : EnrollmentBaseDto
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public string StudentId { get; set; } = "";
    }

    public class UpdateEnrollmentDto : EnrollmentBaseDto { }

    public class EnrollmentDto : EnrollmentBaseDto
    {
        public Guid Id { get; set; }
        public string StudentFullName { get; set; } = "";
    }
}
