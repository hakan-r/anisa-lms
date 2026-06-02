using anisa_lms.DTOs;
using anisa_lms.Models;
using AutoMapper;

namespace anisa_lms.Mappings
{
    public class StudentModuleProgressProfile : Profile
    {
        public StudentModuleProgressProfile()
        {
            CreateMap<StudentModuleProgress, StudentModuleProgressDto>();

            CreateMap<CreateStudentModuleProgressDto, StudentModuleProgress>();

            CreateMap<UpdateStudentModuleProgress, StudentModuleProgress>();
        }
    }
}
