using anisa_lms.DTOs;
using anisa_lms.Interfaces.IRepository;
using anisa_lms.Interfaces.IService;
using anisa_lms.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Services
{
    public class AssessmentService(IAssessmentRepository repo, IMapper mapper) : IAssessmentService
    {
        private readonly IAssessmentRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAssessment(CreateAssessmentDto create)
        {
            var assessment = _mapper.Map<Assessment>(create);

            await _repo.CreateAsync(assessment);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool?> DeleteAssessment(int aId)
        {
            var assessment = await _repo.GetByIdAsync(aId);
            if (assessment == null) return null;

            _repo.DeleteAsync(assessment);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<List<AssessmentScoreDto>> GetResults(int aId, bool passed)
        {
            var query = _repo.GetAssessmentScores(aId);
            
            if(passed)
            {
                return await query
                    .Include(s => s.Assessment)
                    .Where(s => s.Score >= s.Assessment.PassRequirement)
                    .ProjectTo<AssessmentScoreDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            } else
            {
                return await query
                    .Include(s => s.Assessment)
                    .Where(s => s.Score < s.Assessment.PassRequirement)
                    .ProjectTo<AssessmentScoreDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }

        public async Task<List<AssessmentDto>> GetUpcomingAssessments(int cId)
        {
            var assessments = _repo.GetUpcomingQueryable(cId);

            return await assessments
                .ProjectTo<AssessmentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool?> UpdateAssessment(int aId, UpdateAssessmentDto update)
        {
            var assessment = await _repo.GetByIdAsync(aId);
            if (assessment == null) return null;

            _mapper.Map(update, assessment);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
