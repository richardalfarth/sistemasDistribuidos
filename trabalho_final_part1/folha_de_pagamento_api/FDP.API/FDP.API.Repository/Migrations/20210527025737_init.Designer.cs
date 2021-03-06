// <auto-generated />
using System;
using FDP.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FDP.API.Repository.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20210527025737_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FDP.API.Domain.FolhaSalarial", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoDoFuncionario")
                        .HasColumnType("int");

                    b.Property<DateTime>("Competencia")
                        .HasColumnType("datetime2");

                    b.Property<int>("FuncionarioID")
                        .HasColumnType("int");

                    b.Property<int>("HorasTrabalhadas")
                        .HasColumnType("int");

                    b.Property<decimal>("INSS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IRRF")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SalarioBruto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalarioLiquido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Codigo");

                    b.ToTable("FolhaSalarial");
                });
#pragma warning restore 612, 618
        }
    }
}
