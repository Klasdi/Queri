using Microsoft.EntityFrameworkCore;

namespace Queri.Model
{
    [Index("SerialNumber")]
    public class Answer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SerialNumber { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
