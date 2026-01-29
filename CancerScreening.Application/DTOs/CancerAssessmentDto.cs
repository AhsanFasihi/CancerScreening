using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerScreening.Application.DTOs
{
    public class CancerAssessmentDto
    {
        public string CancerType { get; set; } = string.Empty;
        public int Score { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
    }
}

