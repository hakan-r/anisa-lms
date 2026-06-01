using anisa_lms.DTOs;

namespace anisa_lms.Interfaces
{
    public interface ICourseService
    {
        public Task<List<CourseDto>> GetAllAsync();
        public Task CreateAsync(CreateCourseDto create);
        public Task<bool?> UpdateAsync(Guid cId, UpdateCourseDto update);
        public Task<bool?> DeleteAsync(Guid cId);
    }
}
