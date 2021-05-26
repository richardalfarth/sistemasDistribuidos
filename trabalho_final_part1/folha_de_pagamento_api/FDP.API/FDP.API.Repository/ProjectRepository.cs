using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using FDP.API.Domain;
using FDP.API.Repository;
using FDP.API.Service.Services;

namespace Project.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectContext _context;
        private readonly IHttpClientFactory _httpClient;
        private readonly HttpClient _client;
        public ProjectRepository(ProjectContext context, IHttpClientFactory httpClient)
        {
            _context = context;
            _httpClient = httpClient;
            _client = httpClient.CreateClient("funcionarioApi");
        }

        //Gerais
        public void Add<T>(T entity) where T : class
        {
             _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<FolhaSalarial[]> GetAllFolhaSalarialAsync()
        {
            IQueryable<FolhaSalarial> query = _context.FolhaSalarial;
            query = query.AsNoTracking().OrderBy(c => c.Codigo);
            return await query.ToArrayAsync();
        }
        public async Task<FolhaSalarial> GetFolhaSalarialAsyncById(int codigo)
        {
            IQueryable<FolhaSalarial> query = _context.FolhaSalarial;
            query = query.AsNoTracking().OrderBy(c => c.Codigo)
            .Where(c => c.Codigo == codigo);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<FolhaSalarial> CalcularFolhaSalarial(string cpf, int horasTrabalhadas)
        {
            FolhaSalarialService folha = new FolhaSalarialService(_httpClient);
            var funcionario = await folha.CalcularFolhaSalarialFuncionario(cpf,horasTrabalhadas);
            return funcionario;
        }
       
    }
}