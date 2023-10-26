using AutoMapper;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Profiles
{
    public class PacotesProfile : Profile
    {
        public PacotesProfile()
        {
            CreateMap<CreatePacotesDto, Pacotes>();
            CreateMap<Pacotes, ReadPacotesDto>();
            CreateMap<UpdatePacotesDto, Pacotes>();
        }
    }
}
