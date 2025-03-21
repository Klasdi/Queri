namespace Queri.RequestModel
{
    public class SaveResultRequest
    {
        public int SurveyId { get; set; }
        public int InterviewId { get; set; }
        public DataResult DataResult { get; set; } 
    }
}
