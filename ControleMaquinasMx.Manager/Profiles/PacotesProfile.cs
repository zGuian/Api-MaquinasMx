using AutoMapper;
using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.PacotesDtos;

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
