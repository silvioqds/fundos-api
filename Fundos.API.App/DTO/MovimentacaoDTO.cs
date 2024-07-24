using Fundos.API.App.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.App.DTO
{
    public class MovimentacaoDTO
    {
        public decimal? Valor { get; set; }
        public int Acao { get; set; }
    }
}
