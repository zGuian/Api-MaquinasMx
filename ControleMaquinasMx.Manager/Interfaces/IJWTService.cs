using ControleMaquinasMx_Domain.Entities;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IJWTService
    {
        string GerarToken(Usuario user);
    }
}
