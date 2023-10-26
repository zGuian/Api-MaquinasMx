using AutoMapper;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Manager.Profiles
{
    public class MaquinaProfile : Profile
    {
        public MaquinaProfile()
        {
            CreateMap<CreateMaquinasDto, Maquinas>()
                .ForMember(dest => dest.Pacotes, opts => opts
                .MapFrom(src => src.Pacotes));

            CreateMap<Maquinas, ReadMaquinasDto>();
            CreateMap<UpdateMaquinasDto, Maquinas>();
        }
    }
}
