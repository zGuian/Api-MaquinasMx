namespace ControleMaquinasMx_DomainShared.PacotesDtos
{
    public class AlteraPacoteDto
    {
        public int Id { get; set; }
        public string? NomeKb { get; set; }
        public DateTime? DataAtualização => DateTime.Now;
    }
}
