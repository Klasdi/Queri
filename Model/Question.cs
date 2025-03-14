using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Queri.Model
{
    [Index("SerialNumber")]
    public class Question
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public TypeAnser TypeAnswer { get; set; }
        public int SerialNumber { get; set; }
        public int SurveyId { get; set; }
        [NotMapped]
        public Survey? Survey { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
    public enum TypeAnser
    {
        [Description("Один ответ")]
        OneAnswer,
        [Description("Несколько ответов")]
        MoreAnswer,
    }
}
