using AutoMapper;
using Course.gRPC.Persistence;
using Course.gRPC.Protos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Core.Extensions;
using Service.Core.Models.Consts;
using Service.Core.Models.Courses;
using Service.Core.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.gRPC.Services
{
    public class SubjectService : SubjectProtoService.SubjectProtoServiceBase
    {
        private readonly ILogger<SubjectService> _logger;
        private readonly CourseDbContext _courseDbContext;
        private readonly ISeeder _seeder;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        public SubjectService(ILogger<SubjectService> logger, CourseDbContext courseDbContext, ISeeder seeder, IMapper mapper, IIdentityService identityService)
        {
            _logger = logger;
            _courseDbContext = courseDbContext;
            _seeder = seeder;
            _mapper = mapper;
            _identityService = identityService;
        }
        public override async Task<CRUDResp> ArrangeScript(ArrangeScriptReq request, ServerCallContext context)
        {

            var result = false;
            foreach (var item in request.Arrange)
            {
                var script = await _courseDbContext.SectionScripts.FirstOrDefaultAsync(x => x.Id == item.Id);
                if(script != null){
                    script.Order = item.Order;
                }
            }
            if(await _courseDbContext.SaveChangesAsync() > 0){
                result = true;
            }
            return new CRUDResp{
                Result = result
            };
        }
        public override async Task<CRUDResp> CRUDVideoScript(CRUDVideoScriptReq request, ServerCallContext context)
        {
             bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    var lastScript = await _courseDbContext.SectionScripts.Where(x => x.SectionId.ToString() == request.SectionId).OrderByDescending(x => x.Order).FirstOrDefaultAsync();
                    VideoScript videoScript = _mapper.Map<VideoScript>(request);
                    videoScript.Order = lastScript == null ? 0 : lastScript.Order + 1;
                    _courseDbContext.Add(videoScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.UPDATE:
                    var updateScript = await _courseDbContext.VideoScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (updateScript == null)
                    {
                        result = false;
                        break;
                    }
                    _mapper.Map(request, updateScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.DELETE:
                    var deleteScript = await _courseDbContext.VideoScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (deleteScript == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(deleteScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<GetAvailableTeacherResp> GetAvailableTeacher(GetAvailableTeacherReq request, ServerCallContext context)
        {
            var availTeachers = await _courseDbContext.StudentClasses.Where(x => x.StudentId.ToString() == request.Id)
            .Include(x => x.Subject).Include(inc => inc.Semester).Where(x => x.Semester.Year == DateTime.Now.Year).Select(x => x.Subject.Teacher).AsSplitQuery().ToListAsync();
            List<TeacherModel> teachers = _mapper.Map<List<TeacherModel>>(availTeachers);
            return new GetAvailableTeacherResp
            {
                Data = { teachers }
            };
        }
        public override async Task<GetClassResp> GetClasses(GetClassReq request, ServerCallContext context)
        {
            var classes = await _courseDbContext.TeacherSubjects.Where(x => x.Semester.Year == DateTime.Now.Year && x.Semester.DomainId.ToString() == request.DomainId)
            .Include(inc => inc.Subject).Include(inc => inc.Teacher)
            .Include(inc => inc.Students).ThenInclude(inc => inc.Student).ToListAsync();

            return new GetClassResp
            {
                Classes = { _mapper.Map<List<TeacherSubjectModel>>(classes) }
            };
        }
        public override async Task<GetClassStudentResp> GetClassStudent(GetClassStudentReq request, ServerCallContext context)
        {
            var subject = await _courseDbContext.TeacherSubjects.FirstOrDefaultAsync(x => x.Id == request.TeacherSubjectId);
            var students = await _courseDbContext.StudentClasses.Where(x => x.SemesterId == subject.SemesterId && x.SubjectId == subject.Id).Include(inc => inc.Student).Select(x => x.Student).ToListAsync();

            return new GetClassStudentResp
            {
                Students = { _mapper.Map<List<StudentModel>>(students.OrderBy(x => x.Fullname)) }
            };
        }
        public override Task<CRUDResp> AssignTeacherSubject(AssignTeacherSubjectReq request, ServerCallContext context)
        {
            return base.AssignTeacherSubject(request, context);
        }
        public override async Task<GetAssignmentResultResp> GetScriptAssignmentResult(GetAssignmentResultReq request, ServerCallContext context)
        {
            var assignmentScript = await _courseDbContext.AssignmentScripts.Where(x => x.Section.TeacherSubjectId == request.TeacherSubjectId).ToListAsync();
            List<AssignmentResultModel> assignmentResults = new List<AssignmentResultModel>();

            foreach (var item in assignmentScript)
            {
                var studentSubmitted = await _courseDbContext.StudentAssignments.Where(x => x.AssigmentId == item.Id).FirstOrDefaultAsync();
                if (studentSubmitted != null)
                {
                    var assignment = _mapper.Map<AssignmentResultModel>(studentSubmitted);
                    assignment.IsSubmit = true;
                    assignmentResults.Add(assignment);
                }
            }
            return new GetAssignmentResultResp
            {
                AssignmentResult = { assignmentResults }
            };
        }
        public override async Task<GetStudentResp> GetStudent(GetStudentReq request, ServerCallContext context)
        {
            var response = new GetStudentResp();
            var student = await _courseDbContext.Students.FirstOrDefaultAsync(x => x.AccountId.ToString() == request.AccountId);
            response.Student = _mapper.Map<StudentModel>(student);
            return response;
        }
        public override async Task<GetTeacherResp> GetTeacher(GetTeacherReq request, ServerCallContext context)
        {
            GetTeacherResp response = new GetTeacherResp();
            var teacher = await _courseDbContext.Teachers.FirstOrDefaultAsync(x => x.AccountId.ToString() == request.AccountId);
            response.Teacher = _mapper.Map<TeacherModel>(teacher);
            return response;
        }
        public override async Task<GetDeadlineEventResp> GetDeadlineEvent(GetDeadlineEventReq request, ServerCallContext context)
        {
            var submitAssignments = await _courseDbContext.AssignmentScripts.Where(x => x.Section.TeacherSubjectId == request.SubjectId).Include(x => x.StudentAssignments).ToListAsync();
            return new GetDeadlineEventResp
            {
                Data = { _mapper.Map<List<CRUDAssignmentScriptReq>>(submitAssignments) }
            };
        }
        public override async Task<GetScheduleResp> GetSchedule(GetScheduleReq request, ServerCallContext context)
        {
            GetScheduleResp getScheduleResp = new GetScheduleResp
            {
                Data = { }
            };
            var studentSubjects = await _courseDbContext.StudentClasses.Where(x => x.StudentId.ToString() == request.StudentId && x.EndAt > DateTime.Now).ToListAsync();
            var schedules = await _courseDbContext.Schedules.Where(x => x.StartTime.Date >= DateTime.Parse(request.StartDate).Date && x.EndTime.Date <= DateTime.Parse(request.EndDate).Date).ToListAsync();
            List<ScheduleModel> scheduleModels = new List<ScheduleModel>();
            return getScheduleResp;
        }
        public override Task<GetCurrentSubjectResp> GetCurrentSubjects(GetCurrentSubjectReq request, ServerCallContext context)
        {
            return base.GetCurrentSubjects(request, context);
        }
        public override async Task<GetMasterDataResponse> GetMasterData(GetMasterDataRequest request, ServerCallContext context)
        {
            GetMasterDataResponse resp = new GetMasterDataResponse
            {
                Masterdata = { }
            };
            var student = await _courseDbContext.Students.FirstOrDefaultAsync(x => x.AccountId == Guid.Parse(request.AccountId));
            if (student == null)
            {
                var teacher = await _courseDbContext.Teachers.FirstOrDefaultAsync(x => x.AccountId.ToString() == request.AccountId);
                if (teacher == null)
                {
                    return resp;
                }
                var dbSemester1s = await _courseDbContext.TeacherSubjects.Where(x => x.TeacherId == teacher.Id).Include(inc => inc.Semester).Include(inc => inc.Subject).ToListAsync();
                if (dbSemester1s.Count == 0)
                {
                    return resp;
                }
                var groupByYear1 = dbSemester1s.Select(x => x.Semester).GroupBy(key => key.Year).ToDictionary(x => x.Key, val => val.Distinct().ToList());
                List<MasterDataModel> data1 = new List<MasterDataModel>();
                foreach (var semester in groupByYear1)
                {
                    List<SemesterModel> semesterModels = new List<SemesterModel>();
                    foreach (var item in semester.Value)
                    {
                        List<TeacherSubjectModel> teacherSubjectModels = new List<TeacherSubjectModel>();
                        foreach (var sub in item.Subjects)
                        {
                            TeacherSubjectModel teacherSubjectModel = new TeacherSubjectModel
                            {
                                Id = sub.Id,
                                TeacherName = sub.Teacher.Fullname,
                                Subject = new SubjectModel
                                {
                                    Id = sub.Id.ToString(),
                                    Title = sub.Subject.Title,
                                    CoverImageUrl = string.IsNullOrEmpty(sub.Subject.CoverImageUrl) ? "/img/1.jpg" : sub.Subject.CoverImageUrl,
                                    Description = sub.Subject.Description,
                                    Credit = sub.Subject.Credit,
                                    Code = sub.Subject.Code
                                },
                                SubjectId = sub.SubjectId.ToString()
                            };
                            teacherSubjectModels.Add(teacherSubjectModel);
                        }
                        SemesterModel semesterModel = new SemesterModel()
                        {
                            Id = item.Id,
                            SemesterName = item.SemesterName,
                            SemesterStart = item.SemesterStart.ToString("dd-MM-yyyy"),
                            SemesterEnd = item.SemesterEnd.ToString("dd-MM-yyyy"),
                            Year = item.Year,
                            Subjects = { teacherSubjectModels }
                        };
                        semesterModels.Add(semesterModel);
                    }
                    MasterDataModel masterdata = new MasterDataModel
                    {
                        Year = semester.Key,
                        Semesters = { semesterModels }
                    };
                    data1.Add(masterdata);
                }
                resp = new GetMasterDataResponse
                {
                    Masterdata = { data1 }
                };
                return resp;
            }
            var studentClasses = await _courseDbContext.StudentClasses.Where(x => x.StudentId == student.Id).Include(inc => inc.Semester).Include(inc => inc.Subject).ThenInclude(inc => inc.Teacher).ToListAsync();
            if (studentClasses.Count == 0)
            {
                return resp;
            }
            var groupByYear = studentClasses.Select(x => x.Semester).Distinct().GroupBy(key => key.Year).ToDictionary(x => x.Key, val => val);
            List<MasterDataModel> data = new List<MasterDataModel>();
            foreach (var semester in groupByYear)
            {
                List<SemesterModel> semesterModels = new List<SemesterModel>();
                foreach (var item in semester.Value)
                {
                    List<TeacherSubjectModel> teacherSubjectModels = new List<TeacherSubjectModel>();
                    foreach (var sub in item.Subjects)
                    {
                        sub.Subject = await _courseDbContext.Subjects.FirstOrDefaultAsync(x => x.Id == sub.SubjectId);
                        TeacherSubjectModel teacherSubjectModel = new TeacherSubjectModel
                        {
                            Id = sub.Id,
                            TeacherName = sub.Teacher.Fullname,
                            Subject = new SubjectModel
                            {
                                Id = sub.Id.ToString(),
                                Title = sub.Subject.Title,
                                CoverImageUrl = string.IsNullOrEmpty(sub.Subject.CoverImageUrl) ? "/img/1.jpg" : sub.Subject.CoverImageUrl,
                                Description = sub.Subject.Description,
                                Credit = sub.Subject.Credit,
                                Code = sub.Code
                            },
                            SubjectId = sub.SubjectId.ToString()
                        };
                        teacherSubjectModels.Add(teacherSubjectModel);
                    }
                    SemesterModel semesterModel = new SemesterModel()
                    {
                        Id = item.Id,
                        SemesterName = item.SemesterName,
                        SemesterStart = item.SemesterStart.ToString("dd-MM-yyyy"),
                        SemesterEnd = item.SemesterEnd.ToString("dd-MM-yyyy"),
                        Year = item.Year,
                        Subjects = { teacherSubjectModels }
                    };
                    semesterModels.Add(semesterModel);
                }
                MasterDataModel masterdata = new MasterDataModel
                {
                    Year = semester.Key,
                    Semesters = { semesterModels }
                };
                data.Add(masterdata);
            }
            GetMasterDataResponse response = new GetMasterDataResponse
            {
                Masterdata = { data }
            };
            return response;
        }
        public override async Task<SubjectListModel> GetAllSubjectByDomain(GetSubjectsByDomainRequest request, ServerCallContext context)
        {
            var subjectsFromDb = await _courseDbContext.Subjects.Where(x => x.DomainId.ToString() == request.DomainId).Include(x => x.TeacherSubjects).ToListAsync();
            List<SubjectModel> subjectModels = new List<SubjectModel>();
            foreach (var item in subjectsFromDb)
            {
                SubjectModel subjectModel = new SubjectModel
                {
                    Id = item.Id.ToString(),
                    CoverImageUrl = "/img/1.jpg",
                    Title = item.Title,
                    Description = item.Description,
                    Credit = item.Credit,
                    Code = item.Code ?? "Default"
                };
                subjectModels.Add(subjectModel);
            }
            return new SubjectListModel
            {
                Subjects = { subjectModels }
            };
        }
        public override async Task<GetTeachersResp> GetTeachersOfStudent(GetTeachersOfStudentReq request, ServerCallContext context)
        {
            var studentClasses = await _courseDbContext.StudentClasses.Where(x => x.Student.AccountId.ToString() == request.AccountId && x.EndAt > DateTime.Now).Select(x => x.SubjectId).Distinct().ToListAsync();
            var teachers = await _courseDbContext.TeacherSubjects.Where(x => x.EndDate > DateTime.Now && studentClasses.Contains(x.Id)).Include(x => x.Teacher).Select(x => x.Teacher).Distinct().ToListAsync();
            return new GetTeachersResp
            {
                Teachers = { _mapper.Map<List<TeacherModel>>(teachers) }
            };
        }
        public override async Task<CRUDResp> CRUDSubject(CRUDSubjectReq request, ServerCallContext context)
        {
            try
            {
                if (request.Id == "")
                {
                    request.Id = Guid.Empty.ToString();
                }
                bool result = false;
                switch (request.Action)
                {
                    case (int)ActionConst.CREATE:
                        Subject subject = _mapper.Map<Subject>(request);
                        if (await _courseDbContext.Subjects.AnyAsync(x => x.Title == request.Title))
                        {
                            result = false;
                            break;
                        }
                        _courseDbContext.Add(subject);
                        await _courseDbContext.SaveChangesAsync();
                        result = true;
                        break;
                    case (int)ActionConst.UPDATE:
                        Subject subjectUpdate = await _courseDbContext.Subjects.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                        if (subjectUpdate == null)
                        {
                            result = false;
                            break;
                        }
                        _mapper.Map(request, subjectUpdate);
                        await _courseDbContext.SaveChangesAsync();
                        result = true;
                        break;
                    case (int)ActionConst.DELETE:
                        Subject subjectDelete = await _courseDbContext.Subjects.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                        if (subjectDelete == null)
                        {
                            result = false;
                            break;
                        }
                        _courseDbContext.Remove(subjectDelete);
                        await _courseDbContext.SaveChangesAsync();
                        result = true;
                        break;
                    default:
                        break;
                }
                return new CRUDResp
                {
                    Result = result
                };
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
        public override Task<SubjectListModel> GetStudentSubjectsBySemester(GetStudentSubjectsBySemesterRequest request, ServerCallContext context)
        {
            return base.GetStudentSubjectsBySemester(request, context);
        }
        public override async Task<DoExamResponse> DoExam(DoExamRequest request, ServerCallContext context)
        {
            DoExamResponse doExamResponse = new DoExamResponse()
            {

            };
            return doExamResponse;
        }
        public override async Task<GetQuestionsResp> GetQuestions(GetQuestionsReq request, ServerCallContext context)
        {
            var questions = await _courseDbContext.Exams.Where(x => x.OwnerId.ToString() == request.TeacherId).Include(x => x.Questions).ThenInclude(inc => inc.Question).SelectMany(x => x.Questions).Select(x => x.Question).ToListAsync();
            foreach (var question in questions)
            {
                question.Answers = await _courseDbContext.Answers.Where(x => x.QuestionId == question.Id).ToListAsync();
            }
            List<QuestionModel> questionModels = _mapper.Map<List<QuestionModel>>(questions);
            GetQuestionsResp getQuestionsResp = new GetQuestionsResp
            {
                Questions = { questionModels }
            };
            return getQuestionsResp;
        }
        public override async Task<GetExamResponse> GetExam(GetExamRequest request, ServerCallContext context)
        {
            var exams = await _courseDbContext.Exams.Where(x => x.Owner.AccountId.ToString() == request.TeacherId).Include(x => x.Questions).AsNoTracking().ToListAsync();
            List<ExamModel> examModels = _mapper.Map<List<ExamModel>>(exams);
            GetExamResponse getExamResponse = new GetExamResponse()
            {
                Exams = { examModels }
            };
            return getExamResponse;

        }

        public override async Task<GetSemesterResp> GetSemesters(GetSemesterReq request, ServerCallContext context)
        {
            var semesters = await _courseDbContext.Semesters.Where(x => x.DomainId.ToString() == request.DomainId && x.Year == request.Year)
            .Include(inc => inc.Subjects).ToListAsync();
            return new GetSemesterResp
            {
                Semesters = { _mapper.Map<List<SemesterModel>>(semesters) }
            };
        }
        public override async Task<CRUDResp> CRUDSemester(CRUDSemesterReq request, ServerCallContext context)
        {
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    Semester semester = _mapper.Map<Semester>(request);
                    if (await _courseDbContext.Semesters.AnyAsync(x => x.SemesterName.ToLower().Trim().Equals(request.SemesterName.Trim().ToLower())))
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Add(semester);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                case (int)ActionConst.UPDATE:
                    Semester update = await _courseDbContext.Semesters.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (update == null)
                    {
                        break;
                    }
                    _mapper.Map(request, update);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                case (int)ActionConst.DELETE:
                    Semester delete = await _courseDbContext.Semesters.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (delete == null)
                    {
                        break;
                    }
                    _courseDbContext.Remove(delete);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<GetSubjectDetailResponse> GetSubjectDetail(GetSubjectDetailRequest request, ServerCallContext context)
        {
            var sections = await _courseDbContext.TeacherSubjects.Where(x => x.SubjectId == Guid.Parse(request.SubjectId) && x.Id == int.Parse(request.ClassId))
                .Include(inc => inc.Sections)
                .Select(x => x.Sections.Where(x => x.RootId.HasValue == false))
                .FirstOrDefaultAsync();
            if (sections == null)
            {
                return new GetSubjectDetailResponse
                {
                    Sections = { },
                };
            }
            foreach (var section in sections.ToList())
            {
                section.Children = await _courseDbContext.Sections.Where(x => x.RootId == section.Id).ToListAsync();
                if (section.Children.Count == 0)
                {
                    section.Scripts = await _courseDbContext.SectionScripts.Where(x => x.SectionId == section.Id).OrderBy(x => x.Order).ToListAsync();
                }
                else
                {
                    foreach (var child in section.Children)
                    {
                        child.Scripts = await _courseDbContext.SectionScripts.Where(x => x.SectionId == child.Id).OrderBy(x => x.Order).ToListAsync();
                    }
                }
            }
            var mappedSections = _mapper.Map<List<SubjectSectionModel>>(sections);
            GetSubjectDetailResponse subjectDetail = new GetSubjectDetailResponse
            {
                Sections = { mappedSections },
            };
            return subjectDetail;
        }
        public override async Task<SeedResponse> SeedData(SeedRequest request, ServerCallContext context)
        {
            _seeder.Seed(_courseDbContext, Guid.Parse(request.DomainId), Guid.Parse(request.AccountId));

            return new SeedResponse
            {
                Result = true
            };
        }
        public override async Task<CRUDResp> CRUDSection(CRUDSectionReq request, ServerCallContext context)
        {
            bool result = false;
            if (string.IsNullOrEmpty(request.Id))
            {
                request.Id = Guid.Empty.ToString();
            }
            if (string.IsNullOrEmpty(request.RootId))
            {
                request.RootId = Guid.Empty.ToString();
            }
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    SubjectSection root = new SubjectSection();
                    if (request.RootId != Guid.Empty.ToString())
                    {
                        root = await _courseDbContext.Sections.Where(x => x.Id.ToString() == request.RootId).Include(inc => inc.Scripts).FirstOrDefaultAsync();
                        if (root == null)
                        {
                            result = false;
                            break;
                        }
                    }
                    SubjectSection section = _mapper.Map<SubjectSection>(request);
                    var sectionOrder = await _courseDbContext.Sections.Where(x => x.TeacherSubjectId == request.TeacherSubjectId && x.RootId == null).ToListAsync();
                    section.Order = sectionOrder.Count + 1;
                    section.RootId = request.RootId == Guid.Empty.ToString() ? null : Guid.Parse(request.RootId);
                    _courseDbContext.Add(section);
                    if (root.Scripts.Count > 0)
                    {
                        foreach (var script in root.Scripts)
                        {
                            script.Section = section;
                        }
                    }
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    result = false;
                    break;
                case (int)ActionConst.UPDATE:
                    SubjectSection updateSection = await _courseDbContext.Sections.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                    if (updateSection == null)
                    {
                        break;
                    }
                    if (updateSection.RootId != null)
                    {
                        request.RootId = updateSection.RootId.ToString();
                    }
                    _mapper.Map(request, updateSection);
                    if (request.RootId == Guid.Empty.ToString())
                    {
                        updateSection.RootId = null;
                    }
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    result = false;
                    break;
                case (int)ActionConst.DELETE:
                    SubjectSection deleteSection = await _courseDbContext.Sections.Where(x => x.Id.ToString() == request.Id).Include(inc => inc.Children).FirstOrDefaultAsync();
                    if (deleteSection == null)
                    {
                        break;
                    }
                    if (deleteSection.Children.Count > 0)
                    {
                        _courseDbContext.Sections.RemoveRange(deleteSection.Children);
                    }
                    _courseDbContext.Remove(deleteSection);

                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override Task<CRUDResp> CRUDQuestion(CRUDQuestionReq request, ServerCallContext context)
        {
            return base.CRUDQuestion(request, context);
        }
        public override async Task<CRUDResp> CRUDStudentCategory(CRUDStudentCategoryReq request, ServerCallContext context)
        {
            var result = false;
            int code = 500;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    if(await _courseDbContext.StudentCategories.AnyAsync(x => x.Name == request.Name))
                    {
                        result = false;
                        code = 400;
                        break;
                    }
                    var studentCategory = _mapper.Map<StudentCategory>(request);
                    _courseDbContext.Add(studentCategory);
                    if(await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                    }
                    break;
                case (int)ActionConst.UPDATE:
                    var update = await _courseDbContext.StudentCategories.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if(update == null)
                    {
                        result = false;
                        code = 404;
                        break;
                    }
                    _mapper.Map(request, update);
                    if(await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        code = 200;
                        break;
                    }
                    break;
                case (int)ActionConst.DELETE:
                    var delete = await _courseDbContext.StudentCategories.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if(delete == null)
                    {
                        code = 404;
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(delete);
                    if(await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                    }
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<CRUDResp> CRUDExamScript(CRUDExamScriptReq request, ServerCallContext context)
        {
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    ExamScript examScript = _mapper.Map<ExamScript>(request);
                    if (_courseDbContext.ExamScripts.Any(x => x.SectionId.ToString() == request.SectionId && x.ExamId.ToString() == request.ExamId))
                    {
                        result = false;
                        break;
                    }
                    if (!_courseDbContext.Exams.Any(x => x.Id.ToString() == request.ExamId))
                    {
                        result = false;
                        break;
                    }
                    var lastScript = await _courseDbContext.SectionScripts.Where(x => x.SectionId.ToString() == request.SectionId).OrderByDescending(x => x.Order).FirstOrDefaultAsync();
                    examScript.Order = lastScript == null ? 0 : lastScript.Order + 1;
                    _courseDbContext.Add(examScript);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                case (int)ActionConst.UPDATE:
                    ExamScript update = await _courseDbContext.ExamScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (update == null)
                    {
                        result = false;
                        break;
                    }
                    if (!_courseDbContext.Exams.Any(x => x.Id.ToString() == request.ExamId))
                    {
                        result = false;
                        break;
                    }
                    _mapper.Map(request, update);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                case (int)ActionConst.DELETE:
                    ExamScript delete = await _courseDbContext.ExamScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (delete == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(delete);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<CRUDResp> CRUDClass(CRUDClassReq request, ServerCallContext context)
        {
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:

                    TeacherSubject create = _mapper.Map<TeacherSubject>(request);
                    if (await _courseDbContext.TeacherSubjects.AnyAsync(x => x.Code == request.Code))
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Add(create);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;

                case (int)ActionConst.UPDATE:
                    TeacherSubject updateClass = await _courseDbContext.TeacherSubjects.Where(x => x.Id == request.Id).Include(inc => inc.Students).FirstOrDefaultAsync();
                    if (updateClass == null)
                    {
                        result = false;
                        break;
                    }
                    var removeStudents = updateClass.Students.Where(x => !request.Students.Any(x => x.StudentID == x.Id)).ToList();
                    _mapper.Map(request, updateClass);
                    if (removeStudents.Count > 0)
                    {
                        _courseDbContext.RemoveRange(removeStudents);
                    }
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                case (int)ActionConst.DELETE:
                    TeacherSubject delete = await _courseDbContext.TeacherSubjects.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (delete == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(delete);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<CRUDResp> CRUDContextScript(CRUDContextScriptReq request, ServerCallContext context)
        {
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    var lastScript = await _courseDbContext.SectionScripts.Where(x => x.SectionId.ToString() == request.SectionId).OrderByDescending(x => x.Order).FirstOrDefaultAsync();
                    ContextScript contextScript = _mapper.Map<ContextScript>(request);
                    contextScript.Order = lastScript == null ? 0 : lastScript.Order + 1;
                    _courseDbContext.ContextScripts.Add(contextScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.UPDATE:
                    ContextScript dbContextScript = await _courseDbContext.ContextScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (dbContextScript == null)
                    {
                        result = false;
                        break;
                    }
                    _mapper.Map(request, dbContextScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.DELETE:
                    ContextScript delete = await _courseDbContext.ContextScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (delete == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.ContextScripts.Remove(delete);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<CRUDResp> CRUDDocumentScript(CRUDDocumentScriptReq request, ServerCallContext context)
        {
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    var lastScript = await _courseDbContext.SectionScripts.Where(x => x.SectionId.ToString() == request.SectionId).OrderByDescending(x => x.Order).FirstOrDefaultAsync();
                    DocumentScript documentScript = _mapper.Map<DocumentScript>(request);
                    documentScript.Order = lastScript == null ? 0 : lastScript.Order + 1;
                    _courseDbContext.Add(documentScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.UPDATE:
                    var updateScript = await _courseDbContext.DocumentScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (updateScript == null)
                    {
                        result = false;
                        break;
                    }
                    _mapper.Map(request, updateScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.DELETE:
                    var deleteScript = await _courseDbContext.DocumentScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (deleteScript == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(deleteScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<CRUDResp> CRUDTeacher(CRUDTeacherReq request, ServerCallContext context)
        {
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    Teacher teacher = _mapper.Map<Teacher>(request);
                    if (_courseDbContext.Teachers.Any(x => x.IdentityNo == teacher.IdentityNo))
                    {
                        result = false;
                        break;
                    }
                    Guid accountId = Guid.NewGuid();
                    teacher.AccountId = accountId;
                    teacher.TeacherID = _courseDbContext.Teachers.Where(x => x.DomainId.ToString() == request.DomainId).Count().ToString().PadLeft(6, '4');
                    _courseDbContext.Teachers.Add(teacher);
                    string username = request.FullName.GenerateUsername(teacher.TeacherID);
                    result = await _identityService.CreateAccount(accountId, username, "password@123", Guid.Parse(request.DomainId), $"{username}");
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.UPDATE:
                    Teacher teacherFromDb = await _courseDbContext.Teachers.FirstOrDefaultAsync(x => x.DomainId.ToString() == request.DomainId && x.Id.ToString() == request.Id);
                    if (teacherFromDb == null)
                    {
                        result = false;
                        break;
                    }
                    _mapper.Map(request, teacherFromDb);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                case (int)ActionConst.DELETE:
                    Teacher teacherDelete = await _courseDbContext.Teachers.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                    if (teacherDelete == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Teachers.Remove(teacherDelete);
                    result = await _identityService.DeleteAccount(teacherDelete.AccountId);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<CRUDResp> CRUDStudent(CRUDStudentReq request, ServerCallContext context)
        {
            bool result = false;
            if (string.IsNullOrEmpty(request.Id))
            {
                request.Id = Guid.Empty.ToString();
            }
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    Student studentCreate = _mapper.Map<Student>(request);
                    if (_courseDbContext.Students.Any(x => x.StudentID == studentCreate.StudentID))
                    {
                        result = false;
                        break;
                    }
                    Guid accountId = Guid.NewGuid();
                    studentCreate.AccountId = accountId;
                    studentCreate.StudentID = _courseDbContext.Students.Where(x => x.DomainId.ToString() == request.DomainId).Count().ToString().PadLeft(6, '0');
                    _courseDbContext.Add(studentCreate);
                    string username = request.FullName.GenerateUsername(studentCreate.StudentID);
                    result = await _identityService.CreateAccount(accountId, username, "password@123", Guid.Parse(request.DomainId), $"{username}");
                    await _courseDbContext.SaveChangesAsync();

                    break;
                case (int)ActionConst.UPDATE:
                    Student studentUpdate = await _courseDbContext.Students.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                    if (studentUpdate == null)
                    {
                        result = false;
                        break;
                    }
                    _mapper.Map(request, studentUpdate);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.DELETE:
                    Student studentDelete = await _courseDbContext.Students.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                    if (studentDelete == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(studentDelete);
                    await _courseDbContext.SaveChangesAsync();
                    result = await _identityService.DeleteAccount(studentDelete.AccountId);
                    break;
                default:
                    break;
            }

            return new CRUDResp
            {
                Result = result
            };

        }
        public override async Task<CRUDResp> CRUDAssignmentScript(CRUDAssignmentScriptReq request, ServerCallContext context)
        {
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    var lastScript = await _courseDbContext.SectionScripts.Where(x => x.SectionId.ToString() == request.SectionId).OrderByDescending(x => x.Order).FirstOrDefaultAsync();
                    var assignmentScript = _mapper.Map<AssignmentScript>(request);
                    assignmentScript.Order = lastScript != null ? lastScript.Order + 1 : 0;
                    _courseDbContext.Add(assignmentScript);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.UPDATE:
                    AssignmentScript dbAssignment = await _courseDbContext.AssignmentScripts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                    if (dbAssignment == null)
                    {
                        result = false;
                        break;
                    }
                    _mapper.Map(request, dbAssignment);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                case (int)ActionConst.DELETE:
                    var dbAssign = await _courseDbContext.AssignmentScripts.FirstOrDefaultAsync(x => x.Id == request.Id);
                    if (dbAssign == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(dbAssign);
                    await _courseDbContext.SaveChangesAsync();
                    result = true;
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<GetStudentsResp> GetStudents(GetStudentsReq request, ServerCallContext context)
        {
            var students = await _courseDbContext.Students.Where(x => x.DomainId.ToString() == request.DomainId).ToListAsync();

            GetStudentsResp getStudentsResp = new GetStudentsResp
            {
                Students = { _mapper.Map<List<StudentModel>>(students) }
            };
            return getStudentsResp;
        }
        public override async Task<GetTeachersResp> GetTeachers(GetTeachersReq request, ServerCallContext context)
        {
            var teachers = await _courseDbContext.Teachers.Where(x => x.DomainId.ToString() == request.DomainId).ToListAsync();
            GetTeachersResp getTeachersResp = new GetTeachersResp
            {
                Teachers = { _mapper.Map<List<TeacherModel>>(teachers) }
            };
            return getTeachersResp;
        }
        public override async Task<CRUDResp> DeleteScript(DeleteScriptReq request, ServerCallContext context)
        {
            var script = await _courseDbContext.SectionScripts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (script == null)
            {
                return new CRUDResp
                {
                    Result = false
                };
            }
            _courseDbContext.Remove(script);
            await _courseDbContext.SaveChangesAsync();
            return new CRUDResp
            {
                Result = true
            };
        }
        public override async Task<CRUDResp> SubmitAssignment(SubmitAssignmentReq request, ServerCallContext context)
        {
            var assignment = await _courseDbContext.AssignmentScripts.FirstOrDefaultAsync(x => x.Id == request.AssignmentId);
            if (assignment == null)
            {
                return new CRUDResp
                {
                    Result = false
                };
            }
            bool result = false;
            switch (request.Action)
            {
                case (int)ActionConst.CREATE:
                    StudentAssignment studentAssignment = _mapper.Map<StudentAssignment>(request);
                    _courseDbContext.Add(studentAssignment);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                    }
                    break;
                case (int)ActionConst.UPDATE:
                    StudentAssignment dbAssignment = await _courseDbContext.StudentAssignments.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                    if (dbAssignment == null)
                    {
                        break;
                    }
                    _mapper.Map(request, dbAssignment);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                        break;
                    }
                    break;
                case (int)ActionConst.DELETE:
                    StudentAssignment deleteAssignment = await _courseDbContext.StudentAssignments.FirstOrDefaultAsync(x => x.Id.ToString() == request.Id);
                    if (deleteAssignment == null)
                    {
                        result = false;
                        break;
                    }
                    _courseDbContext.Remove(deleteAssignment);
                    if (await _courseDbContext.SaveChangesAsync() > 0)
                    {
                        result = true;
                    }
                    break;
                default:
                    break;
            }
            return new CRUDResp
            {
                Result = result
            };
        }
        public override async Task<GetStudentAssignmentResp> GetStudentAssignments(GetStudentAssignmentsReq request, ServerCallContext context)
        {
            var results = await _courseDbContext.AssignmentScripts.Where(x => x.SectionId.ToString() == request.SectionId).Include(x => x.StudentAssignments).SelectMany(x => x.StudentAssignments).ToListAsync();
            GetStudentAssignmentResp getStudentAssignmentResp = new GetStudentAssignmentResp
            {
                Result = { _mapper.Map<List<AssignmentResultModel>>(results) }
            };
            return getStudentAssignmentResp;
        }
    }
}
