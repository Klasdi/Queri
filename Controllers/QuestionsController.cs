using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Queri.Controllers
{
    [ApiController]
    [Route("api/surveys/{surveyId}/questions")]
    public class QuestionsController : Controller
    {
        private readonly ApplicationContext _context;

        public QuestionsController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestion(int surveyId, int questionId)
        {
            var question = await _context.Questions
                .Include(x => x.Answers)
                .FirstOrDefaultAsync(x => x.Id == questionId && x.SurveyId == surveyId);

            if (question == null)
            {
                return NotFound();
            }

            var result = new
            {
                question.Id,
                question.Name,
                question.TypeAnswer,
                Answers = question.Answers.Select(x => new { x.Id, x.Name, x.SerialNumber})
            };

            return Ok(result);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

    }
}
