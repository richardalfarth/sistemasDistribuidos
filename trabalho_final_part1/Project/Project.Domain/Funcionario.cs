using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class Funcionario
    {
        [Required]
        [Key]
        public int Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome da é obrigatório.")]
        public string Nome { get; set; }

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
    #region
    public enum UnidadeFederacaoSigla
    {
        [Description("Acre")]
        AC = 1,
        [Description("Alagoas")]
        AL,
        [Description("Amapá")]
        AP,
        [Description("Amazonas")]
        AM,
        [Description("Bahia")]
        BA,
        [Description("Ceará")]
        CE,
        [Description("Distrito Federal")]
        DF,
        [Description("Espirito Santo")]
        ES,
        [Description("Goiás")]
        GO,
        [Description("Maranhão")]
        MA,
        [Description("Mato Grosso")]
        MT,
        [Description("Mato Grosso do Sul")]
        MS,
        [Description("Minas Gerais")]
        MG,
        [Description("Pará")]
        PA,
        [Description("Paraiba")]
        PB,
        [Description("Paraná")]
        PR,
        [Description("Pernambuco")]
        PE,
        [Description("Piauí")]
        PI,
        [Description("Rio de Janeiro")]
        RJ,
        [Description("Rio Grande do Norte")]
        RN,
        [Description("Rio Grande do Sul")]
        RS,
        [Description("Rondônia")]
        RO,
        [Description("Roraima")]
        RR,
        [Description("Santa Catarina")]
        SC,
        [Description("São Paulo")]
        SP,
        [Description("Sergipe")]
        SE,
        [Description("Tocantis")]
        TO,
        [Description("Estrangeiro")]
        EX
    }
    #endregion
}
