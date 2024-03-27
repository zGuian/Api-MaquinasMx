using ControleMaquinasMx_Domain.Entities;

namespace ControleMaquinasMx_Application.Interfaces
{
    public interface IJWTService
    {
        string GerarToken(Usuario user);
    }
}
