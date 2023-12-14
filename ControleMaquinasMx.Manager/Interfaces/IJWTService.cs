using ControleMaquinasMx_Core.Models;

namespace ControleMaquinasMx_Manager.Interfaces
{
    public interface IJWTService
    {
        string GerarToken(Usuario user);
    }
}
