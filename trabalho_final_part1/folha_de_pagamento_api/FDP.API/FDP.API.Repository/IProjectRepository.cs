using System.Threading.Tasks;
using FDP.API.Domain;

namespace Project.Repository
{
    public interface IProjectRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<FolhaSalarial[]> GetAllFolhaSalarialAsync();
        Task<FolhaSalarial> GetFolhaSalarialAsyncById(int codigo);
        Task<FolhaSalarial> CalcularFolhaSalarial(string cpf, int horasTrabalhadas);
    }
}