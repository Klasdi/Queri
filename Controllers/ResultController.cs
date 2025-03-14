using Microsoft.AspNetCore.Mvc;
using Queri.Model;

namespace Queri.Controllers
{
    [Route("api/surveys/{surveyId}/interviews/{interviewId}/results")]
    public class ResultsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ResultsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SaveResult(int surveyId, int interviewId, [FromBody] SaveResultRequest request)
        {
            var interview = _context.Interviews.FirstOrDefault(i => i.Id == interviewId && i.SurveyId == surveyId);

            if (interview == null)
            {
                return NotFound();
            }

            var result = new Result
            {
                InterviewId = interviewId,
                QuestionId = request.QuestionId,
                AnswerId = request.SelectedAnswers, 
                AnswerTime = request.AnswerTime
            };

            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            var nextQuestion = _context.Questions
                .Where(q => q.SurveyId == surveyId && q.SerialNumber > request.SerialNumber)
                .OrderBy(q => q.SerialNumber)
                .FirstOrDefault();

            return Ok(new { NextQuestionId = nextQuestion?.Id });
        }
    }

    public class SaveResultRequest
    {
        public int QuestionId { get; set; }
        public int SelectedAnswers { get; set; }
        public DateTime AnswerTime { get; set; }
        public int SerialNumber { get; set; }
    }
}
