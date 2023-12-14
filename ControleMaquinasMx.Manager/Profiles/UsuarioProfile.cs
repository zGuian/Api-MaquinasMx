using AutoMapper;
using ControleMaquinasMx_Core.Models;
using ControleMaquinasMx_CoreShared.PermissaoDtos;
using ControleMaquinasMx_CoreShared.UsuarioDtos;

namespace ControleMaquinasMx_Manager.Profiles
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
