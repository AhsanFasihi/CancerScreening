using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerScreening.Application
{
    public class SubmitCancerAssessmentHandler
    {
        public CancerRiskResultDto Handle(SubmitCancerAssessmentCommand command)
        {
            int score = command.Answers.Count(a => a);
            string risk = score < 2 ? "Low" : score < 4 ? "Moderate" : "High";
            return new CancerRiskResultDto
            {
                CancerType = command.CancerType,
                RiskLevel = risk,
                Recommendation = risk == "Low" ? "Routine screening as per guidelines" : "Screening advised"
            };
        }
    }
}
