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
            CreateMap<CreateMaquinasDto, Maquinas>();
            CreateMap<UpdateMaquinasDto, Maquinas>();
            CreateMap<Maquinas, ReadMaquinasDto>()
                .ForMember(maquinaDto => maquinaDto.Pacotes, opt => opt.MapFrom(maquina => maquina.Pacotes));
            CreateMap<Maquinas, UpdateMaquinasDto>();
        }
    }
}
