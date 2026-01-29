using AutoMapper;
using CancerScreening.Domain.Entities;
using CancerScreening.Application.DTOs;

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
