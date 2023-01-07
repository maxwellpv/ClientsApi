using AutoMapper;
using WebApplication2.DomainClients.Domain.Models;
using WebApplication2.DomainClients.Resources;

namespace WebApplication2.Shared.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Client, ClientResource>();
        }
    }
}