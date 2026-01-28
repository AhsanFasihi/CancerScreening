using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerScreening.Application
{
    public class SubmitCancerAssessmentCommand
    {
        public string CancerType { get; set; } = string.Empty;
        public bool[] Answers { get; set; } = Array.Empty<bool>();
    }
}
