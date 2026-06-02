using anisa_lms.DTOs;

namespace anisa_lms.Interfaces.IService
{
    public interface IModuleService
    {
        public Task<List<ModuleDto>> GetModulesForStudent(int cId, string studentId);
        public Task CreateModule(CreateModuleDto create);
        public Task<bool?> UpdateModule(int mId, UpdateModuleDto update);
        public Task<bool?> DeleteModule(int mId);
    }
}
