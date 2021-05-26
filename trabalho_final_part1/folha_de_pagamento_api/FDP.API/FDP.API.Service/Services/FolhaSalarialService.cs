using Newtonsoft.Json;
using FDP.API.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FDP.API.Service.Services
{
    public class FolhaSalarialService
    {
        private readonly HttpClient _client;

        public FolhaSalarialService(IHttpClientFactory httpClient)
        {
            _client = httpClient.CreateClient("funcionarioApi");
        }

        public async Task<FolhaSalarial> CalcularFolhaSalarialFuncionario(string cpf, int horasTrabalhadas)
        {
            var funcionario = await GetFuncionarioByCpf(cpf);
            var calculaFolhaComDescontos = CalcularDescontosFolha(funcionario, horasTrabalhadas);
            return calculaFolhaComDescontos;
        }
        protected async Task<Funcionario> GetFuncionarioByCpf(string cpf)
        {
            string montaUrl = $"/funcionarios/GetFuncionarioByCPF?cpf={cpf}";
            var result = _client.GetStringAsync(montaUrl);
            result.Wait();
            return JsonConvert.DeserializeObject<Funcionario>(result.Result);
        }

        protected FolhaSalarial CalcularDescontosFolha(Funcionario funcionario, int horasTrabalhadas)
        {
            var calculaSalarioBruto = CalculaSalarioBrutoHorasTrabalhadas(funcionario.Salario,horasTrabalhadas);
            var salarioLiquidoINSS = CalculaPercentualDescontoINSS(calculaSalarioBruto);
            var salarioLiquidoIRRF = CalculaDescontoIRRF(salarioLiquidoINSS);
            var descontoINSS = calculaSalarioBruto - salarioLiquidoINSS;
            var descontoIRRF = salarioLiquidoINSS - salarioLiquidoIRRF;
            var salarioLiquido = (calculaSalarioBruto - descontoINSS - descontoIRRF);
            return PreencheFolha(funcionario,horasTrabalhadas,calculaSalarioBruto, descontoINSS, descontoIRRF, salarioLiquido);
        }

        protected FolhaSalarial PreencheFolha(Funcionario funcionario,int horasTrabalhadas,double salarioBruto,double descontoINSS,double descontoIRRF,double salarioLiquido) 
        {
            FolhaSalarial folha = new FolhaSalarial();
            folha.CargoDoFuncionario = funcionario.CargoDoFuncionario;
            folha.Competencia = DateTime.Now;
            folha.FuncionarioID = funcionario.Codigo;
            folha.HorasTrabalhadas = horasTrabalhadas;
            folha.INSS = descontoINSS;
            folha.IRRF = descontoIRRF;
            folha.NomeFuncionario = funcionario.Nome;
            folha.SalarioBruto = salarioBruto;
            folha.SalarioLiquido = salarioLiquido;
            return folha;
        }

        protected double CalculaSalarioBrutoHorasTrabalhadas(double salarioBruto, int horasTrabalhadas)
        {
            var valorHora = (salarioBruto / 220);
            return valorHora * horasTrabalhadas;
        }

        protected double CalculaDescontoIRRF(double salario)
        {
            if (salario < 1.903)
                return salario;
            else if (salario > 1.903 && salario < 2.826)
                return (salario % 7.5) - 0.142;
            else if (salario > 2.827 && salario < 3.751)
                return (salario % 15) - 0.354;
            else if (salario > 3.752 && salario < 4.664)
                return (salario % 22.5) - 0.636;
            else
                return (salario % 27.5) - 0.869;
        }

        protected double CalculaPercentualDescontoINSS(double salario)
        {
            if (salario < 1.751)
                return (salario % 8) - 0.189;
            else if (salario > 1.752 && salario < 2.919)
                return (salario % 9) - 0.189;
            else if (salario > 2.920 && salario < 5.839)
                return (salario % 11) - 0.189;
            else
                return (salario - 642);
        }

    }
}
