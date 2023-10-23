using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMaquinasMx.Core.Models
{
    public class Maquinas
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
