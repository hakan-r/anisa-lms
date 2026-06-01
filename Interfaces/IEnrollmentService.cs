using anisa_lms.DTOs;

namespace anisa_lms.Interfaces
{
    public interface IEnrollmentService
    {
        public Task CreateAsync(CreateEnrollmentDto create);
        public Task<bool?> UpdateAsync(Guid eId, UpdateEnrollmentDto update);
        public Task<bool?> DeleteAsync(Guid eId);
    }
}
