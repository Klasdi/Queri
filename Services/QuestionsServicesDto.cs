using Microsoft.EntityFrameworkCore;
using Queri.Controllers;
using Queri.Model;

namespace Queri.Services
{
    public class QuestionsServicesDto
    {
        private readonly ApplicationContext _context;

        public QuestionsServicesDto(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Question> GetQuestions(int questionId, int surveyId)
        {
            var question = await _context.Questions.FirstOrDefaultAsync(x => x.Id == questionId && x.SurveyId == surveyId);

            if (question == null)
            {
                throw new Exception("Data not found");
            }

            var result = new Question
            {
               Id = question.Id,
               Name = question.Name,
               TypeAnswer = question.TypeAnswer,
               Answers = question.Answers.Select(x => new Answer { Id = x.Id, Name = x.Name, SerialNumber = x.SerialNumber }).ToList()
            };
            return result;
        }
    }
}
