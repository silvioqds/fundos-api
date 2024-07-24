using Fundos.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.Api.Domain.Entity
{
    public class TipoFundo : Base
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        public ICollection<Fundo> Fundos { get; set; }
    }
}
