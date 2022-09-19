using Microsoft.Extensions.Configuration;
using Service.Core.Models.Courses;
using Service.Core.Persistence;
using System;
using System.Threading.Tasks;

namespace Course.gRPC.Persistence
{
    public class CourseRepository : AsyncRepository<Subject, Guid>, ICourseRepository
    {
        public CourseRepository(CourseDbContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public ValueTask<SectionScript> CreateSectionScriptAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<SubjectSection> CreateSubjectSectionAsync(Guid teacherSubjectId, Guid teacherId, SubjectSection subjectSection)
        {
            throw new NotImplementedException();
        }
    }
}
