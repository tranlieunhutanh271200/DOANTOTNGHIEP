using Course.gRPC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Service.Core.Models;
using Service.Core.Models.Courses;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Course.gRPC.Persistence
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {

        }
        public DbSet<StudentCategory> StudentCategories { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ImageAnswer> ImageAnswers { get; set; }
        public DbSet<AudioAnswer> AudioAnswers { get; set; }
        public DbSet<MultichoiceQuestion> MultichoiceQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FilloutQuestion> FilloutQuestions { get; set; }
        public DbSet<ArrangeQuestion> ArrangeQuestions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuestionAllocation> QuestionAllocation { get; set; }
        public DbSet<SubjectSection> Sections { get; set; }
        public DbSet<SubjectSchedule> Schedules { get; set; }
        public DbSet<SectionScript> SectionScripts { get; set; }
        public DbSet<AssignmentScript> AssignmentScripts { get; set; }
        public DbSet<ContextScript> ContextScripts { get; set; }
        public DbSet<DocumentScript> DocumentScripts { get; set; }
        public DbSet<ExamScript> ExamScripts { get; set; }
        public DbSet<QuizScript> QuizScripts { get; set; }
        public DbSet<VideoScript> VideoScripts{get;set;}
        public DbSet<Score> Scores { get; set; }
        public DbSet<BaremScore> BaremScores { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Semester>(opt =>
            {
                opt.HasMany(x => x.Classes).WithOne(o => o.Semester).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(k => k.SemesterId);
                opt.HasMany(x => x.Subjects).WithOne(o => o.Semester).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Student>()
                .HasIndex(idx => new { idx.Id, idx.AccountId, idx.StudentID }).IsUnique();
            modelBuilder.Entity<TeacherSubject>(opt =>
            {
                opt.HasIndex(idx => new { idx.SubjectId, idx.SemesterId, idx.Code, idx.TeacherId });
                opt.HasMany(m => m.Students).WithOne(o => o.Subject).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Semester>()
                .HasIndex(key => new { key.DomainId, key.Year, key.SemesterName }).IsUnique();

            modelBuilder.Entity<StudentClass>().HasKey(key => new
            {
                key.SemesterId,
                key.StudentId,
                key.SubjectId
            });
            modelBuilder.Entity<Exam>().HasOne(o => o.Owner).WithMany(m => m.Exams).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StudentAssignment>()
                .HasIndex(index => new { index.StudentId, index.AssigmentId }).IsUnique();

            modelBuilder.Entity<SubjectSection>(opt =>
            {
                opt.HasOne(o => o.Root).WithMany(m => m.Children).OnDelete(DeleteBehavior.NoAction);
                opt.HasMany(o => o.Children).WithOne(o => o.Root).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Question>()
                .HasDiscriminator<string>("QuestionType")
                .HasValue<MultichoiceQuestion>(nameof(MultichoiceQuestion))
                .HasValue<FilloutQuestion>(nameof(FilloutQuestion))
                .HasValue<ArrangeQuestion>(nameof(ArrangeQuestion));

            modelBuilder.Entity<Answer>()
                .HasDiscriminator<string>("AnswerType")
                .HasValue<BasicAnswer>(nameof(BasicAnswer))
                .HasValue<AudioAnswer>(nameof(AudioAnswer))
                .HasValue<ImageAnswer>(nameof(ImageAnswer));

            modelBuilder.Entity<SectionScript>()
                .HasDiscriminator<string>("ScriptType")
                .HasValue<AssignmentScript>(nameof(AssignmentScript))
                .HasValue<DocumentScript>(nameof(DocumentScript))
                .HasValue<ContextScript>(nameof(ContextScript))
                .HasValue<ExamScript>(nameof(ExamScript))
                .HasValue<QuizScript>(nameof(QuizScript))
                .HasValue<VideoScript>(nameof(VideoScript));
            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var _httpContextAccessor = this.GetService<IHttpContextAccessor>();
            var refreshService = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IHubService>();

            var entries = ChangeTracker.Entries().Where(e => e.Entity is AuditEntity).ToList();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((AuditEntity)entry.Entity).CreatedBy = _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "System";
                    ((AuditEntity)entry.Entity).CreatedDate = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    Entry((AuditEntity)entry.Entity).Property(p => p.CreatedBy).IsModified = false;
                    Entry((AuditEntity)entry.Entity).Property(p => p.CreatedDate).IsModified = false;
                    ((AuditEntity)entry.Entity).ModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                    ((AuditEntity)entry.Entity).ModifiedDate = DateTime.Now;
                }
            }
            try
            {
                if (await base.SaveChangesAsync(cancellationToken) > 0)
                {
                    await refreshService.Refresh();
                }

            }
            catch
            {
                return 0;
            }
            return 1;

        }
    }
}
