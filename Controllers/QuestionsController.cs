using Microsoft.AspNetCore.Mvc;
using Queri.Services;

namespace Queri.Controllers
{
    [ApiController]
    [Route("api/surveys/{surveyId}/questions")]
    public class QuestionsController : Controller
    {
        private readonly QuestionsServicesDto _questionsServicesDto;

        public QuestionsController(QuestionsServicesDto questionsServicesDto)
        {
            _questionsServicesDto = questionsServicesDto;
        }
        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestion(int surveyId, int questionId)
        {
            try
            {
                var result = await _questionsServicesDto.GetQuestions(questionId, surveyId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
