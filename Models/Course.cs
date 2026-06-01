namespace anisa_lms.Models
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? InstructorId { get; set; } = "";
        public string Title { get; set; } = "";
        public string? Description { get; set; } = "";
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } = [];
        public virtual ICollection<Module> Modules { get; set; } = [];
        public virtual ICollection<Assessment> Assessments { get; set; } = [];

        public virtual AppUser? Instructor { get; set; }
    }
}
