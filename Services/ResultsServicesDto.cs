using Microsoft.EntityFrameworkCore;
using Queri.Model;
using Queri.RequestModel;

namespace Queri.Services
{
    public class ResultsServicesDto
    {
        private readonly ApplicationContext _context;

        public ResultsServicesDto(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Question> PostResults(SaveResultRequest request)
        {
            var interview = _context.Interviews.FirstOrDefault(i => i.Id == request.InterviewId && i.SurveyId == request.SurveyId);

            if (interview == null)
            {
                throw new Exception("Interview not found");
            }

            var result = new Result
            {
                InterviewId = request.InterviewId,
                QuestionId = request.DataResult.QuestionId,
                AnswerId = request.DataResult.SelectedAnswers,
                AnswerTime = request.DataResult.AnswerTime
            };

            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            var nextQuestion = _context.Questions
                .Where(q => q.SurveyId == request.SurveyId && q.SerialNumber > request.DataResult.SerialNumber)
                .OrderBy(q => q.SerialNumber)
                .FirstOrDefault();

            if (nextQuestion == null) 
            {
                throw new Exception("NextQuestion not found");
            }
            else
            {
                return nextQuestion;
            }
        }
    }
}
