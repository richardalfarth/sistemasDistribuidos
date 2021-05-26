using Microsoft.EntityFrameworkCore;
using FDP.API.Domain;


namespace FDP.API.Repository
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<FolhaSalarial> FolhaSalarial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}