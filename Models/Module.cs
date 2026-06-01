namespace anisa_lms.Models
{
    public class Module
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CourseId { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public int OrderIndex { get; set; }

        public virtual Course? Course { get; set; }
    }
}
