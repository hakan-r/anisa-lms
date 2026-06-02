using anisa_lms.Models;

namespace anisa_lms.Interfaces.IRepository
{
    public interface IEnrollmentRepository
    {
        public Task<Enrollment?> GetByIdAsync(int id);
        public Task CreateAsync(Enrollment enrollment);
        public void DeleteAsync(Enrollment enrollment);
        public Task SaveChangesAsync();
    }
}
