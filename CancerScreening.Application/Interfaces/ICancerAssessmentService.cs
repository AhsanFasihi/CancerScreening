using CancerScreening.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CancerScreening.Application.Interfaces
{
    public interface ICancerAssessmentService
    {
        Task<IEnumerable<CancerQuestion>> GetQuestionsByCancerTypeAsync(string cancerType);
        Task<CancerAssessment> SubmitAssessmentAsync(string userId, string cancerType, Dictionary<int, bool> answers);
        Task<IEnumerable<CancerAssessment>> GetUserAssessmentsAsync(string userId);
    }
}
