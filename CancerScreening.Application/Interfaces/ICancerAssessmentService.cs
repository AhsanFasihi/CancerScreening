using CancerScreening.Application.DTOs;

namespace CancerScreening.Application.Interfaces
{
    public interface ICancerAssessmentService
    {
        Task<IEnumerable<CancerQuestionDto>> GetQuestionsByCancerTypeAsync(string cancerType);

        Task<CancerAssessmentDto> SubmitAssessmentAsync(
            string userId,
            string cancerType,
            Dictionary<int, bool> answers);

        Task<IEnumerable<CancerAssessmentDto>> GetUserAssessmentsAsync(string userId);
    }
}
