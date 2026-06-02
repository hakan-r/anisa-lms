using anisa_lms.Data;
using anisa_lms.Interfaces.IRepository;
using anisa_lms.Models;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Repositories
{
    public class ProgressRepository(AppDbContext context) : IProgressRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(StudentModuleProgress moduleProgress)
        {
            await _context.ModuleProgresses.AddAsync(moduleProgress);
        }

        public void DeleteAsync(StudentModuleProgress moduleProgress)
        {
            _context.ModuleProgresses.Remove(moduleProgress);
        }

        public async Task<StudentModuleProgress?> GetByIdAsync(int pId)
        {
            return await _context.ModuleProgresses.FirstOrDefaultAsync(p => p.Id == pId);
        }

        public async Task<List<StudentModuleProgress>> GetProgressByStudentAsync(string studentId, int cId)
        {
            return await _context.ModuleProgresses
                .Where(mp => mp.StudentId == studentId && mp.Module.CourseId == cId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
