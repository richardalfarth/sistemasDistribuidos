using System;

namespace FDP.API.Domain
{
    public class FolhaSalariaDto
    {
        public int? Codigo { get; set; }
        public int FuncionarioID { get; set; }
        public DateTime Competencia { get; set; }
        public int HorasTrabalhadas { get; set; }

    }
}
