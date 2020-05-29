using AutoMapper;
using Eventos.Domain.Entities.Entities;
using Eventos.Services.Api.ViewModels;
using System.Linq;

namespace Eventos.Services.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoViewModel>()
                .ForMember(dest => dest.Palestrantes, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
                })
                .ReverseMap();

            CreateMap<Palestrante, PalestranteViewModel>()
                .ForMember(dest => dest.Eventos, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
                })
                .ReverseMap();

            CreateMap<Lote, LoteViewModel>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialViewModel>().ReverseMap();

            //CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
