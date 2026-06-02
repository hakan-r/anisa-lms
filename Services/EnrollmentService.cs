using anisa_lms.Data;
using anisa_lms.DTOs;
using anisa_lms.Interfaces.IRepository;
using anisa_lms.Interfaces.IService;
using anisa_lms.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Services
{
    public class EnrollmentService(IEnrollmentRepository repo, ICourseRepository courseRepo, IMapper mapper) : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repo = repo;
        private readonly ICourseRepository _courseRepo = courseRepo;
        private readonly IMapper _mapper = mapper;

        public async Task CreateEnrollment(CreateEnrollmentDto create)
        {
            var course = await _courseRepo.GetByIdAsync(create.CourseId) ?? throw new Exception("Course not found");
            var enrollmentsCount = await _courseRepo.GetEnrollmentsCountAsync(create.CourseId);

            if (course.MaxEnrollments <= enrollmentsCount)
                throw new Exception("Course is full. You cannot enroll anymore students");

            var enrollment = _mapper.Map<Enrollment>(create);

            await _repo.CreateAsync(enrollment);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool?> DeleteEnrollment(int eId)
        {
            var enrollment = await _repo.GetByIdAsync(eId);
            if (enrollment == null) return null;

            _repo.DeleteAsync(enrollment);
            await _repo.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateEnrollment(int eId, UpdateEnrollmentDto update)
        {
            var enrollment = await _repo.GetByIdAsync(eId);
            if (enrollment == null) return null;

            _mapper.Map(update, enrollment);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
