using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FUNCIONARIUS_API.Domain;
using FUNCIONARIUS_API.Respository;

namespace FUNCIONARIUS_API.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectContext _context;
        public ProjectRepository(ProjectContext context)
        {
            _context = context;
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

        public async Task<Funcionario[]> GetAllFuncionarioAsync()
        {
            IQueryable<Funcionario> query = _context.Funcionario;
            query = query.AsNoTracking().OrderBy(c => c.Codigo);
            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionarioAsyncById(int codigo)
        {
            IQueryable<Funcionario> query = _context.Funcionario;
            query = query.AsNoTracking().OrderBy(c => c.Codigo)
            .Where(c => c.Codigo == codigo);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Funcionario[]> GetFuncionariosAsyncByCargo(CargoFuncionario cargo)
        {
            IQueryable<Funcionario> query = _context.Funcionario;
            query = query.AsNoTracking().OrderBy(c => c.Codigo)
            .Where(c => c.CargoDoFuncionario == cargo);
            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionariosAsyncByCpf(String cpf)
        {
            IQueryable<Funcionario> query = _context.Funcionario;
            query = query.AsNoTracking().OrderBy(c => c.Codigo)
            .Where(c => c.CPF == cpf);
            return await query.FirstOrDefaultAsync();
        }
    }
}