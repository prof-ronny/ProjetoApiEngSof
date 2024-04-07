﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoApiEngSof.Data;

#nullable disable

namespace ProjetoApiEngSof.Migrations
{
    [DbContext(typeof(EngSofContext))]
    [Migration("20240406232607_v7")]
    partial class v7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoApiEngSof.Model.Administrador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autenticacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Atualizacoes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FormularioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OngId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PessoaFisicaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FormularioId");

                    b.HasIndex("OngId");

                    b.HasIndex("PessoaFisicaId");

                    b.ToTable("Atualizacoes");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Formulario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<Guid?>("OngId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PessoaFisicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoOcorrencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("localizacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OngId");

                    b.HasIndex("PessoaFisicaId");

                    b.ToTable("Formulario");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Foto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FormularioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FormularioId");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Ong", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autenticacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ong");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.PessoaFisica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autenticacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.TipoOcorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoOcorrencia");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Atualizacoes", b =>
                {
                    b.HasOne("ProjetoApiEngSof.Model.Formulario", "Formulario")
                        .WithMany("Atualizacoes")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoApiEngSof.Model.Ong", "Ong")
                        .WithMany()
                        .HasForeignKey("OngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoApiEngSof.Model.PessoaFisica", "PessoaFisica")
                        .WithMany()
                        .HasForeignKey("PessoaFisicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");

                    b.Navigation("Ong");

                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Formulario", b =>
                {
                    b.HasOne("ProjetoApiEngSof.Model.Ong", "Ong")
                        .WithMany()
                        .HasForeignKey("OngId");

                    b.HasOne("ProjetoApiEngSof.Model.PessoaFisica", "PessoaFisica")
                        .WithMany()
                        .HasForeignKey("PessoaFisicaId");

                    b.Navigation("Ong");

                    b.Navigation("PessoaFisica");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Foto", b =>
                {
                    b.HasOne("ProjetoApiEngSof.Model.Formulario", "Formulario")
                        .WithMany("Fotos")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formulario");
                });

            modelBuilder.Entity("ProjetoApiEngSof.Model.Formulario", b =>
                {
                    b.Navigation("Atualizacoes");

                    b.Navigation("Fotos");
                });
#pragma warning restore 612, 618
        }
    }
}
