﻿using System.ComponentModel.DataAnnotations;

namespace ControleMaquinasMx_CoreShared.MaquinasDtos
{
    public class UpdateMaquinasDto
    {
        [Required]
        public string? Inventario { get; set; }

        [Required]
        public string? Hostname { get; set; }

        [Required]
        public bool Ondeso { get; set; }

        [Required]
        public byte Criticidade { get; set; }

        public DateTime? DataCadastro { get; }
        public DateTime? UltimaAtualizacao => DateTime.Now.Date;
    }
}
