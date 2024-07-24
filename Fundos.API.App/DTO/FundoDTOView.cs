using Fundos.API.App.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fundos.API.App.DTO
{
    public class FundoDTOView
    {       
        public string Codigo { get; set; }
        public string Nome { get; set; }      
        public string Cnpj { get; set; }   
        public int CodigoTipo { get; set; }
        public string TipoFundo { get; set; }
        public decimal? Patrimonio { get; set; }
    }
}
