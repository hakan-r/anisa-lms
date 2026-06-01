using anisa_lms.DTOs;

namespace anisa_lms.Interfaces
{
    public interface IModuleService
    {
        public Task CreateAsync(CreateModuleDto create);
        public Task<bool?> UpdateAsync(Guid mId, UpdateModuleDto update);
        public Task<bool?> DeleteAsync(Guid mId);
    }
}
