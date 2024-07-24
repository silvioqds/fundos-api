using Fundos.Api.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fundos.API.Domain.Entity
{
    public class Fundo : Base
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int Codigo_Tipo { get; set; }        
        public decimal? Patrimonio { get; set; }

        public TipoFundo TipoFundo { get; set; } 
    }
}
