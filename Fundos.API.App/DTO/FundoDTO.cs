using Fundos.API.App.Validations;
using System.ComponentModel.DataAnnotations;

namespace Fundos.API.App.DTO
{
    public class FundoDTO
    {        

        [Required(ErrorMessage = "Codigo is required")]
        [MaxLength(20,ErrorMessage = "Codigo pode haver no máximo 20 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Nome is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome deve ter no mínimo 3 e no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Cnpj is required")]
        [CNPJ]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "CodigoTipo is required")]
        public int Codigo_Tipo { get; set; }   

        [Required(ErrorMessage = "Patrimonio is required")]
        public decimal? Patrimonio { get; set; }
    }
}
