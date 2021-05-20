using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class Funcionario
    {
        [Required]
        [Key]
        public int Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O Nome  é obrigatório.")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O CPF  é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o Cargo do Funcionário")]
        [MinLength(1)]
        public CargoFuncionario CargoDoFuncionario { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o Salário")]
        public double Salario { get; set; }
    }

    #region
    public enum CargoFuncionario
    {
        Diretor = 1,
        Gerente,
        Coordernador,
        Analista,
        Desenvolvedor,
        Suporte,
        Auxiliar,
        Estagiario,
        Cozinheira,
        Seguranca
    }
    #endregion
    }
