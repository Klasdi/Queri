using Microsoft.EntityFrameworkCore;

namespace Queri.Model
{
    [Index("IsActive")]
    public class Survey
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
