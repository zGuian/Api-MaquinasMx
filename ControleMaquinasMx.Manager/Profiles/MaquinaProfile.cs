using AutoMapper;
using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.MaquinasDtos;

namespace ControleMaquinasMx_Application.Profiles
{
    public class MaquinaProfile : Profile
    {
        public MaquinaProfile()
        {
            CreateMap<NovaMaquinaDto, Maquina>();
            CreateMap<AlteraMaquinaDto, Maquina>();
            CreateMap<Maquina, AlteraMaquinaDto>();
            CreateMap<Maquina, MaquinaViewDto>()
                .ForMember(maquinaDto => maquinaDto.Pacotes, opt => opt.MapFrom(maquina => maquina.Pacotes))
                .ReverseMap();
            //CreateMap<Maquina, ReadMaquinasDto>()
            //    .ForMember(maquinaDto => maquinaDto.Pacotes, opt => opt.MapFrom(maquina => maquina.Pacotes));
        }
    }
}
