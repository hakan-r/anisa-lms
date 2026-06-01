using anisa_lms.DTOs;

namespace anisa_lms.Interfaces
{
    public interface IAssessmentService
    {
        public Task CreateAsync(CreateAssessmentDto create);
        public Task<bool?> UpdateAsync(Guid aId, UpdateAssessmentDto update);
        public Task<bool?> DeleteAsync(Guid aId);
    }
}
