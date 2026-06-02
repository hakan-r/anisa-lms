using anisa_lms.DTOs;
using anisa_lms.Interfaces.IRepository;
using anisa_lms.Interfaces.IService;
using anisa_lms.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Services
{
    public class CourseService(ICourseRepository repo, IMapper mapper) : ICourseService
    {
        private readonly ICourseRepository _repo = repo;
        private readonly IMapper _mapper = mapper;
        
        public async Task CreateCourse(CreateCourseDto create)
        {
            var course = _mapper.Map<Course>(create);

            await _repo.CreateAsync(course);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool?> DeleteCourse(int cId)
        {
            var course = await _repo.GetByIdAsync(cId);
            if (course == null) return null;

            _repo.DeleteAsync(course);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<PagedListDto<CourseDto>> GetAllCourses(CourseQueryParams query)
        {
            var courses = _repo.GetAllQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
                courses = courses.Where(c => c.Title.Contains(query.Title));

            var totalCount = await courses.CountAsync();

            return new PagedListDto<CourseDto>
            {
                Items = await courses
                    .Skip((query.Page - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(),
                TotalCount = totalCount,
                Page = query.Page,
                PageSize = query.PageSize
            };
        }

        public async Task<bool?> UpdateCourse(int cId, UpdateCourseDto update)
        {
            var course = await _repo.GetByIdAsync(cId);
            if (course == null) return null;

            _mapper.Map(update, course);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
