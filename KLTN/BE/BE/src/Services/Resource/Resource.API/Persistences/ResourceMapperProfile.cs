using AutoMapper;
using Resource.API.Models;
using Service.Core.Models.Resources;

namespace Resource.API.Persistences
{
    public class ResourceMapperProfile : Profile
    {
        public ResourceMapperProfile()
        {
            CreateMap<DomainDirectory, DomainDirectoryDTO>();
        }
    }
}