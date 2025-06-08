namespace PISA_APP.Models
{
    public class StudentAnswer
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int Points { get; set; }
    }

    public class ExamResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Score { get; set; }
        public int TotalPoints { get; set; }
        public double Percentage => TotalPoints > 0 ? (double)Score / TotalPoints * 100 : 0;
        public bool IsCompleted { get; set; }
        public List<StudentAnswer> Answers { get; set; } = new();
        public TimeSpan? TimeTaken => EndTime?.Subtract(StartTime);
    }
}