namespace anisa_lms.Models
{
    public class Assessment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CourseId { get; set; }
        public string Title { get; set; } = "";
        public decimal MaxPoints { get; set; }

        public virtual Course? Course { get; set; }
    }
}
