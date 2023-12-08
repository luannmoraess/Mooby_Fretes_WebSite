using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoSavePI4.Entidades
{
    public class Empresa
    {
        [Key]
        public int Codigo { get; set; }
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Email { get; set; }
        public string? Contato { get; set; }
        public string? Senha { get; set; }
    }
}
