using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain;
using Project.Respository;

namespace Project.Repository
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
    }
}