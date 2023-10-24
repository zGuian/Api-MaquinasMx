using AutoMapper;
using ControleMaquinasMx.Core.Models;
using ControleMaquinasMx_CoreShared.Dtos;
using ControleMaquinasMx_CoreShared.MaquinasDtos;

namespace ControleMaquinasMx_Manager.Profiles
{
    internal class MaquinaProfile : Profile
    {
        public MaquinaProfile()
        {
            CreateMap<CreateMaquinasDto, Maquinas>();
            CreateMap<Maquinas, ReadMaquinasDto>();
            CreateMap<UpdateMaquinasDto, Maquinas>();
        }
    }
}
