using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Core.Models.Courses
{
    public class BaremScore
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Percent { get; set; }
        public int TeacherSubjectId { get; set; }
        [ForeignKey(nameof(TeacherSubjectId))]
        public virtual TeacherSubject TeacherSubject { get; set; }
    }
}