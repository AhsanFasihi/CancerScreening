using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CancerScreening.Domain.Entities
{
    public class CancerQuestion
    {
        public int Id { get; set; }
        public string CancerType { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Weight { get; set; }
    }
}
