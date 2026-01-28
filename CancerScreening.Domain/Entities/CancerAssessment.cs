namespace CancerScreening.Domain.Entities 

{
    public class CancerAssessment
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string CancerType { get; set; } = string.Empty;
        public int Score { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
    }
}