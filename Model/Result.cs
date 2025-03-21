namespace Queri.Model
{
    public class Result
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public DateTime AnswerTime { get; set; }

        public virtual Interview? Interview { get; set; }

        public virtual Question? Question { get; set; }

        public virtual Answer? Answer { get; set; }
    }
}
