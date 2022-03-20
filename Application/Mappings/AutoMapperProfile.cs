using AutoMapper;
using taanbus.domain.dtos.requests;
using taanbus.domain.dtos.responses;
using taanbus.Domain.Dtos.Responses;
using taanbus.Domain.Entities;

namespace taanbus.Application.Mappings
{
    public class AutoMapperProfile : Profile{
        public AutoMapperProfile(){
            //Quejas
            CreateMap<Queja, QuejaResponse>()
                .ForMember(dest => dest.Ciudadano, opt => opt.MapFrom(src => $"{src.User.Nombre} {src.User.Apellidos}"));
            CreateMap<Queja, QuejaAprobadaResponse>();
            CreateMap<QuejaCreateRequest, Queja>();
            CreateMap<QuejaUpdateRequest, Queja>();

            //Sugerencias
            CreateMap<Sugerencia, SugerenciaResponse>()
                .ForMember(dest => dest.Ciudadano, opt => opt.MapFrom(src => $"{src.User.Nombre} {src.User.Apellidos}"));
            CreateMap<Sugerencia, SugerenciaAprobadaResponse>();
            CreateMap<SugerenciaCreateRequest, Sugerencia>();
            CreateMap<SugerenciaUpdateRequest, Sugerencia>();
        }
    }
}