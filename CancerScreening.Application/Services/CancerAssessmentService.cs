using AutoMapper;
using CancerScreening.Application.DTOs;
using CancerScreening.Application.Interfaces;
using CancerScreening.Domain.Entities;
using CancerScreening.Domain.Interfaces;

namespace CancerScreening.Application.Services
{
    public class CancerAssessmentService : ICancerAssessmentService
    {
        private readonly ICancerAssessmentRepository _assessmentRepo;
        private readonly ICancerQuestionRepository _questionRepo;
        private readonly IMapper _mapper;

        public CancerAssessmentService(
            ICancerAssessmentRepository assessmentRepo,
            ICancerQuestionRepository questionRepo,
            IMapper mapper)
        {
            _assessmentRepo = assessmentRepo;
            _questionRepo = questionRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CancerQuestionDto>> GetQuestionsByCancerTypeAsync(string cancerType)
        {
            var questions = await _questionRepo.ListByCancerTypeAsync(cancerType);
            return _mapper.Map<IEnumerable<CancerQuestionDto>>(questions);
        }

        public async Task<CancerAssessmentDto> SubmitAssessmentAsync(
            string userId,
            string cancerType,
            Dictionary<int, bool> answers)
        {
            var questions = await _questionRepo.ListByCancerTypeAsync(cancerType);

            int totalScore = 0;
            foreach (var q in questions)
            {
                if (answers.TryGetValue(q.Id, out bool yes) && yes)
                    totalScore += q.Weight;
            }

            string riskLevel =
                totalScore < 5 ? "Low" :
                totalScore < 10 ? "Medium" : "High";

            var assessment = new CancerAssessment
            {
                UserId = userId,
                CancerType = cancerType,
                Score = totalScore,
                RiskLevel = riskLevel
            };

            var saved = await _assessmentRepo.AddAsync(assessment);
            return _mapper.Map<CancerAssessmentDto>(saved);
        }

        public async Task<IEnumerable<CancerAssessmentDto>> GetUserAssessmentsAsync(string userId)
        {
            var assessments = await _assessmentRepo.ListByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<CancerAssessmentDto>>(assessments);
        }
    }
}
