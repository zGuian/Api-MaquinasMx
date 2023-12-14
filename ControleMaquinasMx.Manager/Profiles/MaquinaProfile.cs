using AutoMapper;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Manager.Profiles
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
