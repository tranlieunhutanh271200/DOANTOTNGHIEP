using API.Gateways.Models;
using AutoMapper;
using Course.gRPC.Protos;
using System;
using System.Threading.Tasks;

namespace API.Gateways.Services
{
    public class SubjectGrpcService
    {
        private readonly SubjectProtoService.SubjectProtoServiceClient _subjectServiceClient;
        private readonly IMapper _mapper;
        public SubjectGrpcService(SubjectProtoService.SubjectProtoServiceClient subjectServiceClient, IMapper mapper)
        {
            _subjectServiceClient = subjectServiceClient ?? throw new ArgumentNullException(nameof(subjectServiceClient));
            _mapper = mapper;
        }
        public async ValueTask<SeedResponse> DoSeed(Guid domainId, Guid accountId)
        {
            return await _subjectServiceClient.SeedDataAsync(new SeedRequest { DomainId = domainId.ToString(), AccountId = accountId.ToString() });
        }
        public async ValueTask<object> GetMasterDataAsync(Guid accountId)
        {
            var result = await _subjectServiceClient.GetMasterDataAsync(new GetMasterDataRequest { AccountId = accountId.ToString() });
            return result;
        }
        public async ValueTask<object> GetSections(Guid subjectId, int classId)
        {
            var result = await _subjectServiceClient.GetSubjectDetailAsync(new GetSubjectDetailRequest { SubjectId = subjectId.ToString(), ClassId = classId.ToString() });
            return result;
        }
        public async ValueTask<object> GetSubjectsByDomain(Guid domainId)
        {
            var result = await _subjectServiceClient.GetAllSubjectByDomainAsync(new GetSubjectsByDomainRequest { DomainId = domainId.ToString() });
            return result;
        }
        public async ValueTask<object> GetTeachersByDomain(Guid domainId)
        {
            var result = await _subjectServiceClient.GetTeachersAsync(new GetTeachersReq { DomainId = domainId.ToString() });
            return result;
        }
        public async ValueTask<object> GetStudentsByDomain(Guid domainId)
        {
            var result = await _subjectServiceClient.GetStudentsAsync(new GetStudentsReq { DomainId = domainId.ToString() });
            return result;
        }
        public async ValueTask<object> GetClassByDomain(Guid domainId)
        {
            var result = await _subjectServiceClient.GetClassesAsync(new GetClassReq { DomainId = domainId.ToString() });
            return result;
        }
        public async ValueTask<object> GetSemesterByDomain(Guid domainId, int year)
        {
            var result = await _subjectServiceClient.GetSemestersAsync(new GetSemesterReq { DomainId = domainId.ToString(), Year = year });
            return result;
        }
        public async ValueTask<bool> CRUDTeacher(TeacherDTO teacherDTO)
        {
            var result = await _subjectServiceClient.CRUDTeacherAsync(_mapper.Map<CRUDTeacherReq>(teacherDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDStudent(StudentDTO studentDTO)
        {
            var result = await _subjectServiceClient.CRUDStudentAsync(_mapper.Map<CRUDStudentReq>(studentDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDSemester(SemesterDTO semester)
        {
            var result = await _subjectServiceClient.CRUDSemesterAsync(_mapper.Map<CRUDSemesterReq>(semester));
            return result.Result;
        }
        public async ValueTask<bool> DeleteScript(int id)
        {
            var result = await _subjectServiceClient.DeleteScriptAsync(new DeleteScriptReq { Id = id });
            return result.Result;
        }
        public async ValueTask<bool> CRUDSection(SectionDTO sectionDTO)
        {
            var result = await _subjectServiceClient.CRUDSectionAsync(_mapper.Map<CRUDSectionReq>(sectionDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDClass(ClassDTO classDTO)
        {
            var result = await _subjectServiceClient.CRUDClassAsync(_mapper.Map<CRUDClassReq>(classDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDContextScript(ContextScriptDTO contextScriptDTO)
        {
            var result = await _subjectServiceClient.CRUDContextScriptAsync(_mapper.Map<CRUDContextScriptReq>(contextScriptDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDAssignmentScript(AssignmentScriptDTO assignmentScriptDTO)
        {
            var result = await _subjectServiceClient.CRUDAssignmentScriptAsync(_mapper.Map<CRUDAssignmentScriptReq>(assignmentScriptDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDDocumentScript(DocumentScriptDTO documentScriptDTO)
        {
            var result = await _subjectServiceClient.CRUDDocumentScriptAsync(_mapper.Map<CRUDDocumentScriptReq>(documentScriptDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDExamScript(ExamScriptDTO examScriptDTO)
        {
            var result = await _subjectServiceClient.CRUDExamScriptAsync(_mapper.Map<CRUDExamScriptReq>(examScriptDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDVideoScript(VideoScriptDTO videoScriptDTO)
        {
            var result = await _subjectServiceClient.CRUDVideoScriptAsync(_mapper.Map<CRUDVideoScriptReq>(videoScriptDTO));
            return result.Result;
        }
        public async ValueTask<bool> CRUDSubject(CRUDSubject subject)
        {
            var result = await _subjectServiceClient.CRUDSubjectAsync(_mapper.Map<CRUDSubjectReq>(subject));
            return result.Result;
        }
        public async ValueTask<object> GetExam(Guid accountId)
        {
            var result = await _subjectServiceClient.GetExamAsync(new GetExamRequest
            {
                TeacherId = accountId.ToString()
            });
            return result;
        }
        public async ValueTask<object> GetClassStudent(int teacherSubjectId)
        {
            var result = await _subjectServiceClient.GetClassStudentAsync(new GetClassStudentReq
            {
                TeacherSubjectId = teacherSubjectId
            });
            return result;
        }
        public async ValueTask<object> GetStudent(Guid accountId)
        {
            return await _subjectServiceClient.GetStudentAsync(new GetStudentReq
            {
                AccountId = accountId.ToString()
            });
        }
        public async ValueTask<object> GetTeacher(Guid accountId)
        {
            return await _subjectServiceClient.GetTeacherAsync(new GetTeacherReq
            {
                AccountId = accountId.ToString()
            });
        }
        public async ValueTask<object> GetAssignmentResult(Guid studentId, int teacherSubjectId)
        {
            return await _subjectServiceClient.GetScriptAssignmentResultAsync(new GetAssignmentResultReq { StudentId = studentId.ToString(), TeacherSubjectId = teacherSubjectId });
        }
        public async ValueTask<bool> SubmitAssignment(int assignmentId, int action, Guid id, string filePath, string fileName, Guid studentId)
        {

            var result = await _subjectServiceClient.SubmitAssignmentAsync(new SubmitAssignmentReq
            {
                Action = action,
                AssignmentId = assignmentId,
                FileId = id.ToString(),
                FilePath = filePath,
                FileName = fileName,
                StudentId = studentId.ToString(),
                Id = Guid.Empty.ToString()
            });
            return result.Result;
        }
        public async ValueTask<bool> DeleteAssignment(int assignmentId, Guid submitId)
        {

            var result = await _subjectServiceClient.SubmitAssignmentAsync(new SubmitAssignmentReq
            {
                Action = 3,
                AssignmentId = assignmentId,
                FileId = Guid.Empty.ToString(),
                FilePath = string.Empty,
                FileName = string.Empty,
                StudentId = Guid.Empty.ToString(),
                Id = submitId.ToString()
            });
            return result.Result;
        }
        public async ValueTask<object> GetStudentAssignments(Guid sectionId)
        {
            return await _subjectServiceClient.GetStudentAssignmentsAsync(new GetStudentAssignmentsReq
            {
                SectionId = sectionId.ToString()
            });
        }
        public async ValueTask<object> GetAvailableTeachers(Guid studentId)
        {
            return await _subjectServiceClient.GetAvailableTeacherAsync(new GetAvailableTeacherReq
            {
                Id = studentId.ToString()
            });
        }
        public async ValueTask<object> GetEvent(int subjectId)
        {
            return await _subjectServiceClient.GetDeadlineEventAsync(new GetDeadlineEventReq
            {
                SubjectId = subjectId
            });
        }
    }
}
