using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Queri.Model
{
    [Index("Status")]
    public class Interview
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public Status Status { get; set; }

        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
    public enum Status
    {
        [Description("В процессе")]
        Progress,
        [Description("Пройден")]
        Complete,
    }
}
