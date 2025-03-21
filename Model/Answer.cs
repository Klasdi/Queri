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
        public virtual Question? Question { get; set; }
        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
