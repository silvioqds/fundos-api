using AutoMapper;
using Fundos.Api.Domain.Entity;
using Fundos.API.App.DTO;
using Fundos.API.Domain.Entity;

namespace Fundos.API.Infra.IOC
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
           
            CreateMap<FundoDTO, Fundo>()
                .ForMember(dest => dest.Codigo_Tipo, opt => opt.MapFrom(src => src.Codigo_Tipo));

            CreateMap<Fundo, FundoDTO>();           

            CreateMap<Fundo, FundoDTOView>()
                .ForMember(dest => dest.TipoFundo, opt => opt.MapFrom(src => src.TipoFundo.Nome))
                .ForMember(dest => dest.CodigoTipo, opt => opt.MapFrom(src => src.Codigo_Tipo)); ;
            CreateMap<FundoDTOView, Fundo>();

            CreateMap<TipoFundoDTO, TipoFundo>();
            CreateMap<TipoFundo, TipoFundoDTO>();
        }
    }
}
