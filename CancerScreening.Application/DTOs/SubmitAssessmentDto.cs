using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerScreening.Application.DTOs
{
    public class SubmitAssessmentDto
    {
        public string UserId { get; set; } = string.Empty;
        public string CancerType { get; set; } = string.Empty;
        public Dictionary<int, bool> Answers { get; set; } = new();
    }
}

