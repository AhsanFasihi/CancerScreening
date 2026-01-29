using CancerScreening.Application.Interfaces;
using CancerScreening.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CancerScreening.Web.Controllers
{
    public class CancerAssessmentController : Controller
    {
        private readonly ICancerAssessmentService _service;

        public CancerAssessmentController(ICancerAssessmentService service)
        {
            _service = service;
        }

        // STEP 1: Select cancer type
        public IActionResult SelectCancer()
        {
            return View();
        }

        // STEP 2: Show questions
        public async Task<IActionResult> Questions(string cancerType)
        {
            var questions = await _service.GetQuestionsByCancerTypeAsync(cancerType);

            var vm = questions.Select(q => new CancerQuestionVM
            {
                Id = q.Id,
                Text = q.Text
            }).ToList();

            ViewBag.CancerType = cancerType;
            return View(vm);
        }

        // STEP 3: Submit assessment
        [HttpPost]
        public async Task<IActionResult> Submit(
            string cancerType,
            Dictionary<int, bool> answers)
        {
            string userId = User.Identity?.Name ?? "Guest";

            var result = await _service.SubmitAssessmentAsync(
                userId,
                cancerType,
                answers);

            var vm = new CancerAssessmentResultVM
            {
                CancerType = result.CancerType,
                Score = result.Score,
                RiskLevel = result.RiskLevel
            };

            return View("Result", vm);
        }
    }
}
