namespace Project.Domain
{
    public class FuncionarioDto
    {
        public int? Codigo { get; set; }

        public string CPF { get; set; }
        public string Nome { get; set; }

        public CargoFuncionario CargoDoFuncionario { get; set; }

        public double Salario { get; set; }
    }
}
