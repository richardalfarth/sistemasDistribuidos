using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain
{
    public class Empresa
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome da empresa é obrigatório.")]
        public string NomeFantasia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(maximumLength: 14, ErrorMessage = "O CNPJ incorreto")]
        public string CNPJ { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " O Estado é obrigatório.")]
        [Range(minimum: 0, maximum: 26, ErrorMessage = "O Estádo está inválido inválido.")]
        public UnidadeFederacaoSigla UF { get; set; }

    }

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
