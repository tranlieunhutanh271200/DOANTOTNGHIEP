using API.Gateways.Models;
using AutoMapper;
using Course.gRPC.Protos;
using Service.Core.Models.CRM;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.LogWork;
using System;

namespace API.Gateways.Persistence
{
    public class GatewayMapper : Profile
    {
        public GatewayMapper()
        {
            CreateMap<MemberDTO, Member>();
            CreateMap<ProjectCreateDTO, Project>();

            CreateMap<Task, TaskDTO>();
            CreateMap<TeacherDTO, CRUDTeacherReq>()
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
                .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));

            CreateMap<StudentDTO, CRUDStudentReq>()
                 .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
                .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));

            CreateMap<SemesterDTO, CRUDSemesterReq>()
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));

            CreateMap<SectionDTO, CRUDSectionReq>()
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<ClassDTO, CRUDClassReq>().ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<ScriptDTO, AssignmentScriptDTO>()
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
                .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.AssignmentScriptDescription))
                .ForMember(X => X.Detail, opt => opt.MapFrom(src => src.Detail))
                .ForMember(x => x.OpenAt, opt => opt.MapFrom(src => DateTime.Parse(src.AssignmentScriptOpenAt)))
                .ForMember(x => x.DueTo, opt => opt.MapFrom(src => DateTime.Parse(src.AssignmentScriptDueTo)))
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));

            CreateMap<ScriptDTO, DocumentScriptDTO>()
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
                .ForMember(x => x.DocumentTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<ScriptDTO, VideoScriptDTO>()
                 .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
                  .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Title))
                  .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
                  .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<ScriptDTO, ExamScriptDTO>()
    .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
    .ForMember(x => x.OpenAt, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.OpenAt) ? DateTime.Parse(src.OpenAt) : DateTime.Now))
        .ForMember(x => x.DueTo, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.DueTo) ? DateTime.Parse(src.DueTo) : DateTime.Now.AddDays(1)))
    .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<ScriptDTO, ContextScriptDTO>()
    .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
    .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));

            CreateMap<ContextScriptDTO, CRUDContextScriptReq>().ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<AssignmentScriptDTO, CRUDAssignmentScriptReq>()
                .ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action))
                .ForMember(x => x.OpenAt, opt => opt.MapFrom(src => src.OpenAt.ToString()))
                  .ForMember(x => x.DueTo, opt => opt.MapFrom(src => src.DueTo.ToString()))
                .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<ExamScriptDTO, CRUDExamScriptReq>().ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<DocumentScriptDTO, CRUDDocumentScriptReq>().ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<VideoScriptDTO, CRUDVideoScriptReq>()
.ForMember(x => x.Action, opt => opt.MapFrom(src => (int)src.Action)).ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<CRUDSubject, CRUDSubjectReq>();


        }
    }
}