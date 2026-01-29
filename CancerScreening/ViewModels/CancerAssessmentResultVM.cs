namespace CancerScreening.Web.ViewModels
{
    public class CancerAssessmentResultVM
    {
        public string CancerType { get; set; } = string.Empty;
        public int Score { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
    }
}
