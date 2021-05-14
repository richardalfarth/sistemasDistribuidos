using Project.Domain;

namespace Project.WebAPI.Dtos
{
    public class EmpresaDto
    {
        public int? Id { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public UnidadeFederacaoSigla UF { get; set; }
    }
}
