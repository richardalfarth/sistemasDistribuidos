using Microsoft.EntityFrameworkCore;
using FUNCIONARIUS_API.Domain;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FUNCIONARIUS_API.Respository
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly currentAssembly = typeof(ProjectContext).Assembly;

            IEnumerable<Type> efMappingTypes = currentAssembly.GetTypes().Where(tp =>
                tp.FullName.StartsWith("FUNCIONARIUS_API.Infrastructure.Mapping.") &&
                tp.FullName.EndsWith("Mapping"));

            foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)map);
            }
        }
    }
}