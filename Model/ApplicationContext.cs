using Microsoft.EntityFrameworkCore;
using Queri.Model;

public class ApplicationContext : DbContext
{
    public DbSet<Survey> Surveys { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<Interview> Interviews { get; set; } = null!;
    public DbSet<Result> Results { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Для быстрого поиска ответа по заданной сессии и вопросу
        modelBuilder.Entity<Result>().HasIndex(u => new { u.InterviewId, u.QuestionId });
        //Для быстрого поиска вопросовов по заданной анкете. SerialNumber использовать для сортировки
        modelBuilder.Entity<Question>().HasIndex(u => new { u.SurveyId, u.SerialNumber });
    }
}
