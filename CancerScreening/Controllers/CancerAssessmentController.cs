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

        public async Task<IActionResult> Questions(string cancerType)
        {
            if (string.IsNullOrWhiteSpace(cancerType))
                return RedirectToAction(nameof(SelectCancer));

            var questions = await _service.GetQuestionsByCancerTypeAsync(cancerType);

            var vm = questions.Select(q => new CancerQuestionVM
            {
                Id = q.Id,
                Text = q.Text
            }).ToList();

            ViewBag.CancerType = cancerType;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(
            string cancerType,
            Dictionary<int, bool> answers)
        {
            if (string.IsNullOrWhiteSpace(cancerType) || answers == null || !answers.Any())
                return RedirectToAction(nameof(SelectCancer));

            string? userId = User.Identity?.IsAuthenticated == true
                ? User.Identity.Name
                : null;

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
