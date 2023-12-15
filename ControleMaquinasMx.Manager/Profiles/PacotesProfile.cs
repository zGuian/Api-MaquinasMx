using AutoMapper;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PacotesDtos;

namespace ControleMaquinasMx_Manager.Profiles
{
    public class PacotesProfile : Profile
    {
        public PacotesProfile()
        {
<<<<<<< HEAD
            CreateMap<Pacote, NovoPacoteDto>().ReverseMap();
            CreateMap<Pacote, PacoteViewDto>().ReverseMap();
            CreateMap<Pacote, AlteraPacoteDto>().ReverseMap();
            CreateMap<PacoteViewDto, AlteraPacoteDto>().ReverseMap();
=======
            CreateMap<NovoPacoteDto, Pacote>();
            CreateMap<Pacote, PacoteViewDto>();
            CreateMap<UpdatePacotesDto, Pacote>();
            CreateMap<Pacote, UpdatePacotesDto>();
>>>>>>> 794a33a3b7cfbc18145de5b9a53a2f8c0ec6efad
        }
    }
}
