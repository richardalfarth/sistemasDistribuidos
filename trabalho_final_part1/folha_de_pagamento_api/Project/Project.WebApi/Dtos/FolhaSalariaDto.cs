using Project.Domain;
using System;

namespace Project.WebAPI.Dtos
{
    public class FolhaSalariaDto
    {
        public int? Codigo { get; set; }

        public int FuncionarioID { get; set; }

        public int HorasTrabalhadas { get; set; }
        public DateTime Competencia { get; set; }
        public string NomeFuncionario { get; set; }
        public CargoFuncionario CargoDoFuncionario { get; set; }
        public double SalarioBruto { get; set; }
        public double SalarioLiquido { get; set; }
        public double INSS { get; set; }

        public double IRRF { get; set; }
    }
}
