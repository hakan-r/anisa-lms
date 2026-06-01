namespace anisa_lms.Models
{
    public class Enrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudentId { get; set; } = "";
        public Guid CourseId { get; set; }
        public decimal ProgressPercentage { get; set; }
        public DateTime EnrolledAt { get; set; }

        public virtual AppUser? Student { get; set; }
        public virtual Course? Course { get; set; }
    }
}
