using anisa_lms.Data;
using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using anisa_lms.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Services
{
    public class CourseService(AppDbContext context, IMapper mapper) : ICourseService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        
        public async Task CreateAsync(CreateCourseDto create)
        {
            var course = _mapper.Map<Course>(create);

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> DeleteAsync(Guid cId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == cId);
            if (course == null) return null;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            return await _context.Courses
                .OrderByDescending(c => c.CreatedAt)
                .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool?> UpdateAsync(Guid cId, UpdateCourseDto update)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == cId);
            if (course == null) return null;

            _mapper.Map(update, course);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
