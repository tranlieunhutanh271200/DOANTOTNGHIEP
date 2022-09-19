using Service.Core.Models.Courses;
using System;
using System.Threading.Tasks;

namespace Course.gRPC.Persistence
{
    public interface ICourseRepository
    {
        ValueTask<SubjectSection> CreateSubjectSectionAsync(Guid teacherSubjectId, Guid teacherId, SubjectSection subjectSection);
        ValueTask<SectionScript> CreateSectionScriptAsync();
    }
}
