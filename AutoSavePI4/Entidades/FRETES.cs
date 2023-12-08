using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSavePI4.Entidades
{
    public class Fretes
    {
        [Key]
        public int Codigo { get; set; }
        public string? TipoCarga { get; set; }
        public string? PesoCarga { get; set; }
        public string? Produto { get; set; }
        public string? LocalColeta { get; set; }
        public string? LocalEntrega { get; set; }
        public string? tipoCarroceria { get; set; }
        public string? FormaPagamento { get; set; }
        public string? OBS { get; set; }
        public decimal? ValorPagamento { get; set; }
        public int? SeqEmpresa { get; set; }
        public int? SeqUsuario { get; set; }

    }
}
