using CancerScreening.Application.Interfaces;
using CancerScreening.Domain.Entities;
using CancerScreening.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerScreening.Application.Services
{
    public class CancerAssessmentService : ICancerAssessmentService
    {
        private readonly ICancerAssessmentRepository _assessmentRepo;
        private readonly ICancerQuestionRepository _questionRepo;

        public CancerAssessmentService(ICancerAssessmentRepository assessmentRepo, ICancerQuestionRepository questionRepo)
        {
            _assessmentRepo = assessmentRepo;
            _questionRepo = questionRepo;
        }

        public async Task<IEnumerable<CancerQuestion>> GetQuestionsByCancerTypeAsync(string cancerType)
        {
            return await _questionRepo.ListByCancerTypeAsync(cancerType);
        }

        public async Task<CancerAssessment> SubmitAssessmentAsync(string userId, string cancerType, Dictionary<int, bool> answers)
        {
            int totalScore = 0;
            var questions = await _questionRepo.ListByCancerTypeAsync(cancerType);

            foreach (var answer in answers)
            {
                var question = questions.FirstOrDefault(q => q.Id == answer.Key);
                if (question != null && answer.Value)
                    totalScore += question.Weight;
            }

            string riskLevel = totalScore switch
            {
                < 5 => "Low",
                < 10 => "Moderate",
                _ => "High"
            };

            var assessment = new CancerAssessment
            {
                UserId = userId,
                CancerType = cancerType,
                Score = totalScore,
                RiskLevel = riskLevel
            };

            return await _assessmentRepo.AddAsync(assessment);
        }

        public async Task<IEnumerable<CancerAssessment>> GetUserAssessmentsAsync(string userId)
        {
            return await _assessmentRepo.ListByUserIdAsync(userId);
        }
    }
}
