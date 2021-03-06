using System;
using System.Threading.Tasks;
using FUNCIONARIUS_API.Domain;

namespace FUNCIONARIUS_API.Repository
{
    public interface IProjectRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Funcionario[]> GetAllFuncionarioAsync();
        Task<Funcionario> GetFuncionarioAsyncById(int codigo);
        Task<Funcionario[]> GetFuncionariosAsyncByCargo(CargoFuncionario cargo);
        Task<Funcionario> GetFuncionariosAsyncByCpf(String cpf);
    }
}