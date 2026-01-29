namespace CancerScreening.Web.ViewModels
{
    public class CancerAssessmentSubmitVM
    {
        public string CancerType { get; set; } = string.Empty;

        // QuestionId → Yes/No
        public Dictionary<int, bool> Answers { get; set; } = new();
    }
}
