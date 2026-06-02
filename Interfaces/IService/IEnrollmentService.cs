using anisa_lms.DTOs;

namespace anisa_lms.Interfaces.IService
{
    public interface IEnrollmentService
    {
        public Task CreateEnrollment(CreateEnrollmentDto create);
        public Task<bool?> UpdateEnrollment(int eId, UpdateEnrollmentDto update);
        public Task<bool?> DeleteEnrollment(int eId);
    }
}
