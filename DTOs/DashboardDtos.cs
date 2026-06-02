using anisa_lms.Models;

namespace anisa_lms.DTOs
{
    public class AdminDashboardDto
    {
        public int TotalUsers { get; set; }
        public int TotalCourses { get; set; }
        public List<Course> PopularCourses { get; set; } = [];
        public List<Course> RecentCourses { get; set; } = [];
    }

    public class InstructorDashboardDto
    {
        public List<Course> MyCourses { get; set; } = [];
        public List<Course> RecentCourses { get; set; } = [];
        public List<ICollection<Assessment>> Assessments { get; set; } = [];
        public int StudentsEnrolled { get; set; }
    }

    public class StudentDashboardDto
    {
        public List<Course?> CoursesInProgress { get; set; } = [];
        public int CompletedAssessments { get; set; }
        public int TotalEnrollments { get; set; }
        public int ModulesCompleted { get; set; }
    }
}
