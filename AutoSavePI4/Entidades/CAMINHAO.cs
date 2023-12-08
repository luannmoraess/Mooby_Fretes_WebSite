using System.ComponentModel.DataAnnotations;

namespace AutoSavePI4.Entidades
{
    public class Caminhao
    {
        [Key]
        public int Codigo { get; set; }
        public string? Placa { get; set; }
        public bool Bitrem { get; set; }
        public string? Caroceria { get; set; }
        public string? Veiculo { get; set; }
        public string? TipoRNTRC { get; set; }
        public string? NumRNTRC { get; set; }
        public bool Rastreador { get; set; }
        public string? NomeRastreador { get; set; }
    }
}
