using AutoMapper;
using CRM.API.Models;
using Service.Core.Models.CRM;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.LogWork;
using Service.Core.Models.Tickets;
using System.Linq;

namespace CRM.API.Persistences
{
    public class CRMMapperProfile : Profile
    {
        public CRMMapperProfile()
        {
            CreateMap<Project, ProjectDTO>()
                .ForMember(x => x.Start, opt => opt.MapFrom(src => src.Start.ToString("yyyy-MM-dd")))
                .ForMember(x => x.End, opt => opt.MapFrom(src => src.End.ToString("yyyy-MM-dd")));
            CreateMap<Task, TaskDTO>()
            .ForMember(x => x.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
            .ForMember(x => x.TotalSpent, opt => opt.MapFrom(src => src.LogTasks.Sum(x => x.Duration)));
            CreateMap<TaskCreateDTO, Task>();
            CreateMap<TaskUpdateDTO, Task>()
            .ForAllMembers(x => x.Condition((src, dest, prop) => prop != null));
            CreateMap<LogworkDTO, LogTask>();
            CreateMap<Ticket, TicketDTO>()
                .ForMember(x => x.FromDate, opt => opt.MapFrom(src => src.FromDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.ToDate, opt => opt.MapFrom(src => src.ToDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.CreateDate, opt => opt.MapFrom(src => src.CreatedDate.ToString("yyyy-MM-dd")));
            CreateMap<TicketCreateDTO, Ticket>();
            CreateMap<TicketUpdateDTO, Ticket>();
            CreateMap<MemberDTO, Member>();
            CreateMap<ProjectCreateDTO, Project>();

            CreateMap<Message, MessageDTO>()
            .ForMember(x => x.SentAt, opt => opt.MapFrom(src => src.SentAt.ToString("dd-MM-yyyy hh:mm:ss")));
            CreateMap<Conversation, ConversationDTO>();

            CreateMap<SendMessageDTO, Message>();
            CreateMap<Member, MemberDTO>();
            CreateMap<Project, Project>();

            CreateMap<LogTask, LogworkDTO>();
            CreateMap<AttendeeDTO, MeetingAttendee>()
            .ForMember(x => x.AttendeeId, opt => opt.MapFrom(src => src.AccountId));
            CreateMap<MeetingDTO, OnlineMeeting>();
        }
    }
}