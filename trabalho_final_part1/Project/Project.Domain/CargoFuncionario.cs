
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
   public class CargoFuncionario
    {
        [Required]
        [Key]
        public int Cargo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome da é obrigatório.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O salário da é obrigatório.")]
        public string Salario { get; set; }


    }
}
