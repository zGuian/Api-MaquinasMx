using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMaquinasMx_CoreShared.PacotesDtos
{
    public class UpdatePacotesDto
    {
        public string? NomeKb { get; set; }
        public DateTime? DataAtualização => DateTime.Now;
    }
}
