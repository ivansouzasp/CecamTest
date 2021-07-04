using AutoMapper;
using CECAM.Domain.Dtos;
using CECAM.Entities;

namespace CECAM.IOC.Mappings
{
    public class DtoToEntity: Profile
    {
        public DtoToEntity()
        {
            CreateMap<ClienteDto, Cliente>();
        }
    }
}
