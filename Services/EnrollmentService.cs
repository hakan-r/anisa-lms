using anisa_lms.Data;
using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using anisa_lms.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Services
{
    public class EnrollmentService(AppDbContext context, IMapper mapper) : IEnrollmentService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(CreateEnrollmentDto create)
        {
            var enrollment = _mapper.Map<Enrollment>(create);

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> DeleteAsync(Guid eId)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == eId);
            if (enrollment == null) return null;

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateAsync(Guid eId, UpdateEnrollmentDto update)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == eId);
            if (enrollment == null) return null;

            _mapper.Map(update, enrollment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
