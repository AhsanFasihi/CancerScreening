using AutoMapper;
using CancerScreening.Application.DTOs;
using CancerScreening.Domain.Entities;

namespace CancerScreening.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CancerQuestion, CancerQuestionDto>();
            CreateMap<CancerAssessment, CancerAssessmentDto>();
        }
    }
}
