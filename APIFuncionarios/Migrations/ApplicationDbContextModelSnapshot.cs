﻿// <auto-generated />
using System;
using APIFuncionarios.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIFuncionarios.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIFuncionarios.Model.ChamadoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeFinalização")
                        .HasColumnType("datetime2");

                    b.Property<int>("Departamento")
                        .HasColumnType("int");

                    b.Property<string>("Detalhes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<int>("IdFuncionarioPedinte")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionarioRecebedor")
                        .HasColumnType("int");

                    b.Property<string>("NomeFuncionarioPedinte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFuncionarioRecebedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Título")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("APIFuncionarios.Model.FuncionarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("ChamadosId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDeAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeCriacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Departamento")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Turno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChamadosId");

                    b.HasIndex("PagamentoId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("APIFuncionarios.Model.PagamentosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDeAlteracaoSalario")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<string>("NomeFuncionario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salario")
                        .HasColumnType("float");

                    b.Property<string>("SobrenomeFuncionario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValeAlimentacao")
                        .HasColumnType("float");

                    b.Property<double>("ValeTransporte")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("APIFuncionarios.Model.FuncionarioModel", b =>
                {
                    b.HasOne("APIFuncionarios.Model.ChamadoModel", "Chamados")
                        .WithMany()
                        .HasForeignKey("ChamadosId");

                    b.HasOne("APIFuncionarios.Model.PagamentosModel", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId");

                    b.Navigation("Chamados");

                    b.Navigation("Pagamento");
                });
#pragma warning restore 612, 618
        }
    }
}
