using AutoMapper;
using DirectorioLocal.Core.DTOs;
using DirectorioLocal.Core.Entities;

namespace SocialMedia.infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PaisesEstadosCiudades, InfoDto>();
            CreateMap<InfoDto, PaisesEstadosCiudades>();
        }

    }
}
