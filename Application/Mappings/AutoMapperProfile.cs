using AutoMapper;
using taanbus.domain.dtos.requests;
using taanbus.domain.dtos.responses;
using taanbus.domain.entities;

namespace taanbus.Application.Mappings{
    public class AutoMapperProfile : Profile{
        public AutoMapperProfile(){
            //Quejas
            CreateMap<Queja, QuejaResponse>();
            CreateMap<QuejaCreateRequest, Queja>();
            CreateMap<QuejaUpdateRequest, Queja>();

            //Sugerencias
            CreateMap<Sugerencia, SugerenciaResponse>();
            CreateMap<SugerenciaCreateRequest, Sugerencia>();
            CreateMap<SugerenciaUpdateRequest, Sugerencia>();
        }
    }
}