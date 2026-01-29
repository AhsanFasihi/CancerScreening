namespace CancerScreening.Domain.Entities
{
    public class CancerAssessment
    {
        public int Id { get; set; }

        // Nullable for anonymous users
        public string? UserId { get; set; }
        public string CancerType { get; set; } = string.Empty;
        public int Score { get; set; }
        public string RiskLevel { get; set; } = string.Empty;

        // Optional but useful
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
