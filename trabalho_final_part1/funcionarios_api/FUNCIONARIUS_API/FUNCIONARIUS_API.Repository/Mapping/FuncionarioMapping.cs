using FUNCIONARIUS_API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FUNCIONARIUS_API.Repository.Mapping
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(prop => prop.Codigo);

            builder.Property(prop => prop.CargoDoFuncionario).IsRequired();

            builder.Property(prop => prop.CPF).IsRequired().HasMaxLength(11);

            builder.Property(prop => prop.Nome).IsRequired();

            builder.Property(prop => prop.Salario).IsRequired().HasColumnType("money)");
        }
    }
}
