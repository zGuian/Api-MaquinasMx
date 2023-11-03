namespace ControleMaquinasMx_CoreShared.PacotesDtos
{
    public class UpdatePacotesDto
    {
        public string? NomeKb { get; set; }
        public DateTime? DataAtualização => DateTime.Now;
        public int MaquinaId { get; set; }
    }
}
