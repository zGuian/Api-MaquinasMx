using AutoMapper;
using ControleMaquinasMx_Domain.Entities;
using ControleMaquinasMx_DomainShared.PermissaoDtos;
using ControleMaquinasMx_DomainShared.UsuarioDtos;

namespace ControleMaquinasMx_Application.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioViewDto>().ReverseMap();
            CreateMap<Usuario, NovoUsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioLogadoDto>().ReverseMap();
            CreateMap<Usuario, AtualizaUsuarioDto>().ReverseMap();
            CreateMap<Permissao, PermissaoViewDto>().ReverseMap();
            CreateMap<Permissao, ReferenciaPermissaoDto>().ReverseMap();
        }
    }
}
