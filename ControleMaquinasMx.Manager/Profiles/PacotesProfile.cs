using AutoMapper;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Profiles
{
    public class PacotesProfile : Profile
    {
        public PacotesProfile()
        {
            CreateMap<Pacote, NovoPacoteDto>().ReverseMap();
            CreateMap<Pacote, PacoteViewDto>().ReverseMap();
            CreateMap<Pacote, AlteraPacoteDto>().ReverseMap();
            CreateMap<PacoteViewDto, AlteraPacoteDto>().ReverseMap();
        }
    }
}
