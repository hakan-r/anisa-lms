using anisa_lms.DTOs;
using anisa_lms.Models;
using AutoMapper;

namespace anisa_lms.Mappings
{
    public class AssessmentScoreProfile : Profile
    {
        public AssessmentScoreProfile()
        {
            CreateMap<AssessmentScore, AssessmentScoreDto>();

            CreateMap<CreateAssessmentScoreDto, AssessmentScore>();

            CreateMap<UpdateAssessmentScoreDto, AssessmentScore>();
        }
    }
}
