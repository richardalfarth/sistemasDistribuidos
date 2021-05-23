using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class FolhaSalarial
    {
        [Required]
        [Key]
        public int Codigo { get; set; }

        [Required]
        public int FuncionarioID { get; set; }

        [Required]
        public DateTime Competencia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome da é obrigatório.")]
        public string NomeFuncionario { get; set; }

        [Required]
        public int HorasTrabalhadas { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o Cargo do Funcionário")]
        [MinLength(1)]
        public CargoFuncionario CargoDoFuncionario { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o Salário Bruto")]
        public double SalarioBruto { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o Salário Liquido")]
        public double SalarioLiquido { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o INSS")]
        public double INSS { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o IRRF")]
        public double IRRF { get; set; }
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
