using AutoMapper;
using Service.Core.Models.Courses;
using Service.Core.Models.Customization;
using Service.Core.Models.DTOs.Courses;
using Service.Core.Models.DTOs.CRM;
using Service.Core.Models.DTOs.Customizations;
using Service.Core.Models.DTOs.Identities;
using Service.Core.Models.Identities;
using Service.Core.Models.LogWork;
using Service.Core.Models.Tickets;

namespace Service.Core.Persistence
{
    public class MapperProfile : Profile
    {
        public MapperProfile() //Register global mapping here
        {
            CreateMap<ComponentCreateDTO, Component>();
            CreateMap<Component, DomainComponentDTO>();
            CreateMap<Domain, DomainDTO>();
            CreateMap<DomainCreateDTO, Domain>();
            CreateMap<DomainUpdateDTO, Domain>();
            CreateMap<Account, AccountLoginDTO>();
            CreateMap<Account, AccountDTO>()
                .ForMember(x => x.Role, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<Menu, AccountCustomizationDTO>();
            CreateMap<DefaultRoute, AccountCustomizationDTO>();
            CreateMap<Color, AccountCustomizationDTO>();
            CreateMap<Background, AccountCustomizationDTO>();

            CreateMap<Task, TaskDTO>();
            CreateMap<TaskCreateDTO, Task>();
            CreateMap<TaskUpdateDTO, Task>();

            CreateMap<LogworkDTO, LogTask>();
            CreateMap<TicketCreateDTO, Ticket>();
            CreateMap<TicketUpdateDTO, Ticket>();

            CreateMap<SectionCreateDTO, SubjectSection>();
        }
    }
}
