using anisa_lms.Data;
using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using anisa_lms.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Services
{
    public class AssessmentService(AppDbContext context, IMapper mapper) : IAssessmentService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(CreateAssessmentDto create)
        {
            var assessment = _mapper.Map<Assessment>(create);

            await _context.Assessments.AddAsync(assessment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> DeleteAsync(Guid aId)
        {
            var assessment = await _context.Assessments.FirstOrDefaultAsync(a => a.Id == aId);
            if (assessment == null) return null;

            _context.Assessments.Remove(assessment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateAsync(Guid aId, UpdateAssessmentDto update)
        {
            var assessment = await _context.Assessments.FirstOrDefaultAsync(a => a.Id == aId);
            if (assessment == null) return null;

            _mapper.Map(update, assessment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
