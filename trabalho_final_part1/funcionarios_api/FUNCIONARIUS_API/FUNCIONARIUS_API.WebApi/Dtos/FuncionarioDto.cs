using FUNCIONARIUS_API.Domain;

namespace FUNCIONARIUS_API.WebAPI.Dtos
{
    public class FuncionarioDto
    {
        public int? Codigo { get; set; }

        public string CPF { get; set; }
        public string Nome { get; set; }

        public CargoFuncionario CargoDoFuncionario { get; set; }

        public decimal Salario { get; set; }
    }
}
