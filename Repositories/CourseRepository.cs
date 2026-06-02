using anisa_lms.Data;
using anisa_lms.Interfaces.IRepository;
using anisa_lms.Models;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Repositories
{
    public class CourseRepository(AppDbContext context) : ICourseRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
        }

        public async void DeleteAsync(Course course)
        {
            _context.Courses.Remove(course);
        }

        public IQueryable<Course> GetAllQueryable()
        {
            return _context.Courses.OrderByDescending(c => c.CreatedAt);
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> GetEnrollmentsCountAsync(int id)
        {
            return await _context.Courses.Where(c => c.Id == id).SelectMany(c => c.Enrollments).CountAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
