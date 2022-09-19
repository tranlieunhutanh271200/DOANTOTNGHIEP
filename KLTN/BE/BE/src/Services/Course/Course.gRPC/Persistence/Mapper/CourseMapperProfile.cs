using AutoMapper;
using Course.gRPC.Protos;
using Service.Core.Models.Courses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.gRPC.Persistence.Mapper
{
    public class CourseMapperProfile : Profile
    {
        public CourseMapperProfile()
        {
            CreateMap<CRUDSubjectReq, Subject>()
            .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<Subject, SubjectModel>()
            .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<SectionScript, SectionScriptModel>()
            .ForMember(x => x.ScriptType, opt => opt.MapFrom(src => src.GetType().Name))
            .ForMember(x => x.DocumentTitle, opt => opt.MapFrom(src => (src as DocumentScript).DocumentTitle))
            .ForMember(x => x.DocumentUrl, opt => opt.MapFrom(src => (src as DocumentScript).DocumentUrl))
            .ForMember(x => x.DocumentPassword, opt => opt.MapFrom(src => (src as DocumentScript).DocumentPassword))
            .ForMember(x => x.FileType, opt => opt.MapFrom(src => (src as DocumentScript).FileType))
            .ForMember(x => x.AssignmentScriptOpenAt, opt => opt.MapFrom(src => (src as AssignmentScript).OpenAt.ToString("yyyy-MM-dd")))
            .ForMember(x => x.AssignmentScriptDueTo, opt => opt.MapFrom(src => (src as AssignmentScript).DueTo.ToString("yyyy-MM-dd")))
            .ForMember(x => x.AssignmentScriptTitle, opt => opt.MapFrom(src => (src as AssignmentScript).Title))
            .ForMember(x => x.AssignmentScriptDescription, opt => opt.MapFrom(src => (src as AssignmentScript).Description))
            .ForMember(x => x.Detail, opt => opt.MapFrom(src => (src as AssignmentScript).Detail))
            .ForMember(x => x.IsReopen, opt => opt.MapFrom(src => (src as AssignmentScript).IsReopen))
            .ForMember(x => x.Detail, opt => opt.MapFrom(src => (src as AssignmentScript).Description))
            .ForMember(x => x.OpenAt, opt => opt.MapFrom(src => (src as ExamScript).OpenAt.ToString("yyyy-MM-dd")))
            .ForMember(x => x.DueTo, opt => opt.MapFrom(src => (src as ExamScript).DueTo.ToString("yyyy-MM-dd")))
            .ForMember(x => x.TotalAttempt, opt => opt.MapFrom(src => (src as ExamScript).TotalAttempt))
            .ForMember(x => x.Title, opt => opt.MapFrom(src => (src as ExamScript).Title))
            .ForMember(x => x.Description, opt => opt.MapFrom(src => (src as ExamScript).Description))
            .ForMember(x => x.Duration, opt => opt.MapFrom(src => (src as ExamScript).Duration))
            .ForMember(x => x.Heading, opt => opt.MapFrom(src => (src as ContextScript).Heading))
            .ForMember(x => x.Body, opt => opt.MapFrom(src => (src as ContextScript).Body))
            .ForMember(x => x.Footer, opt => opt.MapFrom(src => (src as ContextScript).Footer))
             .ForMember(x => x.VideoScriptTitle, opt => opt.MapFrom(src => (src as VideoScript).Title))
            .ForMember(x => x.VideoScriptDescription, opt => opt.MapFrom(src => (src as VideoScript).Description))
             .ForMember(x => x.VideoPath, opt => opt.MapFrom(src => (src as VideoScript).VideoPath))
              .ForMember(x => x.VideoId, opt => opt.MapFrom(src => (src as VideoScript).VideoId))
            .ForAllMembers(x => x.Condition((src, dest, property) => property != null));

            CreateMap<SubjectSection, SubjectSectionModel>()
                .ForMember(x => x.FromDate, opt => opt.MapFrom(src => src.FromDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.ToDate, opt => opt.MapFrom(src => src.ToDate.ToString("yyyy-MM-dd")))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SubjectSectionModel, SubjectSection>()
                .ForMember(x => x.FromDate, opt => opt.MapFrom(src => DateTime.Parse(src.FromDate)))
                .ForMember(x => x.ToDate, opt => opt.MapFrom(src => DateTime.Parse(src.ToDate)))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CRUDSectionReq, SubjectSection>()
            .ForMember(x => x.FromDate, opt => opt.MapFrom(src => DateTime.Parse(src.FromDate)))
            .ForMember(x => x.ToDate, opt => opt.MapFrom(src => src.ToDate))
            .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<CRUDAssignmentScriptReq, AssignmentScript>()
            .ForMember(x => x.OpenAt, opt => opt.MapFrom(src => DateTime.Parse(src.OpenAt)))
            .ForMember(x => x.DueTo, opt => opt.MapFrom(src => DateTime.Parse(src.DueTo))).ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CRUDContextScriptReq, ContextScript>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CRUDDocumentScriptReq, DocumentScript>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<CRUDExamScriptReq, ExamScript>()
            .ForMember(x => x.OpenAt, opt => opt.MapFrom(src => DateTime.Parse(src.OpenAt)))
            .ForMember(x => x.DueTo, opt => opt.MapFrom(src => src.DueTo))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CRUDClassReq, TeacherSubject>()
            .ForMember(x => x.Students, opt => opt.MapFrom(src => src.Students.Count > 0 ? src.Students.Select(x => new StudentClass
            {
                StudentId = Guid.Parse(x.Id),
                SemesterId = int.Parse(src.SemesterId),
                SubjectId = src.Id,
                StartAt = !string.IsNullOrEmpty(src.StartDate) ? DateTime.Parse(src.StartDate) : DateTime.Now,
                EndAt = !string.IsNullOrEmpty(src.EndDate) ? DateTime.Parse(src.EndDate) : DateTime.Now
            }) : new List<StudentClass>()))
            .ForMember(x => x.StartDate, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.StartDate) ? DateTime.Now : DateTime.Parse(src.StartDate)))
            .ForMember(x => x.EndDate, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.EndDate) ? DateTime.Now : DateTime.Parse(src.EndDate)))
                        .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CRUDVideoScriptReq, VideoScript>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CRUDTeacherReq, Teacher>()
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(src => DateTime.Parse(src.BirthDate)));

            CreateMap<CRUDStudentReq, Student>()
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(src => DateTime.Parse(src.BirthDate)));
            CreateMap<Student, StudentModel>()
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString("yyyy-MM-dd")))
            .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<Teacher, TeacherModel>()
                        .ForMember(x => x.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString("yyyy-MM-dd"))).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));

            CreateMap<CRUDSemesterReq, Semester>()
            .ForMember(x => x.SemesterStart, opt => opt.MapFrom(src => DateTime.Parse(src.SemesterStart)))
            .ForMember(x => x.SemesterEnd, opt => opt.MapFrom(src => DateTime.Parse(src.SemesterEnd)));

            CreateMap<TeacherSubject, TeacherSubjectModel>()
            .ForMember(x => x.Students, opt => opt.MapFrom(src => src.Students.Select(x => x.Student)))
            .ForMember(x => x.TotalStudent, opt => opt.MapFrom(src => src.Students.Count))
        .ForMember(x => x.TeacherName, opt => opt.MapFrom(src => src.Teacher.Fullname))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Semester, SemesterModel>()
            .ForMember(x => x.SemesterStart, opt => opt.MapFrom(src => src.SemesterStart.ToString("yyyy-MM-dd")))
             .ForMember(x => x.SemesterEnd, opt => opt.MapFrom(src => src.SemesterEnd.ToString("yyyy-MM-dd")))
             .ForMember(x => x.TotalClasses, opt => opt.MapFrom(src => src.Subjects.Count()));

            CreateMap<Answer, AnswerModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Question, QuestionModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Exam, ExamModel>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<SubmitAssignmentReq, StudentAssignment>()
            .ForMember(x => x.AssigmentId, opt => opt.MapFrom(src => src.AssignmentId))
            .ForMember(x => x.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.Empty : Guid.Parse(src.Id)))
             .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<StudentAssignment, AssignmentResultModel>()
            .ForMember(x => x.SubmitDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(x => x.AssignmentId, opt => opt.MapFrom(src => src.AssigmentId))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AssignmentScript, CRUDAssignmentScriptReq>()
            .ForMember(x => x.OpenAt, opt => opt.MapFrom(src => src.OpenAt.ToString("yyyy-MM-dd")))
            .ForMember(x => x.DueTo, opt => opt.MapFrom(src => src.DueTo.ToString("yyyy-MM-dd")));
        }
    }
}
