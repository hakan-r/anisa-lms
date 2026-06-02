using anisa_lms.DTOs;
using anisa_lms.Interfaces.IRepository;
using anisa_lms.Interfaces.IService;
using anisa_lms.Models;
using AutoMapper;

namespace anisa_lms.Services
{
    public class ProgressService(IProgressRepository repo, IMapper mapper) : IProgressService
    {
        private readonly IProgressRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        public async Task CreateProgress(CreateStudentModuleProgressDto create)
        {
            var progress = _mapper.Map<StudentModuleProgress>(create);

            await _repo.CreateAsync(progress);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool?> DeleteProgress(int pId)
        {
            var progress = await _repo.GetByIdAsync(pId);
            if (progress == null) return null;

            _repo.DeleteAsync(progress);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateProgress(int pId, UpdateStudentModuleProgress update)
        {
            var progress = await _repo.GetByIdAsync(pId);
            if (progress == null) return null;

            _mapper.Map(update, progress);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
