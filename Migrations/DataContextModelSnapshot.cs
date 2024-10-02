﻿// <auto-generated />
using System;
using ChronosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChronosApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChronosApi.Models.CandidaturaModel", b =>
                {
                    b.Property<int>("idCandidatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCandidatura"));

                    b.Property<DateTime>("dataIncricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("idEgresso")
                        .HasColumnType("int");

                    b.Property<int>("idVaga")
                        .HasColumnType("int");

                    b.HasKey("idCandidatura");

                    b.ToTable("TB_CANDIDATURA");

                    b.HasData(
                        new
                        {
                            idCandidatura = 1,
                            dataIncricao = new DateTime(2024, 10, 2, 15, 0, 1, 196, DateTimeKind.Local).AddTicks(8201),
                            idEgresso = 1,
                            idVaga = 1
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.ComentarioModel", b =>
                {
                    b.Property<int>("idComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idComentario"));

                    b.Property<string>("comentarioPublicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEgresso")
                        .HasColumnType("int");

                    b.Property<int>("idPublicacao")
                        .HasColumnType("int");

                    b.HasKey("idComentario");

                    b.ToTable("TB_COMENTARIOS");

                    b.HasData(
                        new
                        {
                            idComentario = 1,
                            comentarioPublicacao = "Minha empresa esta contratando PCD para trabalharem",
                            idEgresso = 1,
                            idPublicacao = 1
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.CorporacaoModel", b =>
                {
                    b.Property<int>("idCorporacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCorporacao"));

                    b.Property<string>("cnpjCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricaoCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCorporacaoEndereco")
                        .HasColumnType("int");

                    b.Property<string>("nomeCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoCorporacao")
                        .HasColumnType("int");

                    b.HasKey("idCorporacao");

                    b.ToTable("TB_CORPORACAO");

                    b.HasData(
                        new
                        {
                            idCorporacao = 1,
                            cnpjCorporacao = "12.345.678/0001-99",
                            descricaoCorporacao = "Exemplo de corporação",
                            emailCorporacao = "contato@exemplo.com",
                            idCorporacaoEndereco = 1,
                            nomeCorporacao = "Corporação Exemplo",
                            numeroCorporacao = "12345678",
                            tipoCorporacao = 0
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.CursoModel", b =>
                {
                    b.Property<int>("idCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCurso"));

                    b.Property<string>("descricaoCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCorporacao")
                        .HasColumnType("int");

                    b.Property<int>("idCorporacaoEndereco")
                        .HasColumnType("int");

                    b.Property<string>("nomeCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCurso");

                    b.ToTable("TB_CURSO");

                    b.HasData(
                        new
                        {
                            idCurso = 1,
                            descricaoCurso = "Curso especializado no aprendizado de hardwares e códigos",
                            idCorporacao = 1,
                            idCorporacaoEndereco = 1,
                            nomeCurso = "Desenvolvimento de Sistemas"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.EgressoModel", b =>
                {
                    b.Property<int>("idEgresso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEgresso"));

                    b.Property<string>("cpfEgresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomeEgresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroEgresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoPessoaEgresso")
                        .HasColumnType("int");

                    b.HasKey("idEgresso");

                    b.ToTable("TB_EGRESSO");

                    b.HasData(
                        new
                        {
                            idEgresso = 1,
                            cpfEgresso = "222",
                            email = "ops.gmail",
                            nomeEgresso = "Pedro",
                            numeroEgresso = "8922",
                            tipoPessoaEgresso = 1
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.CorporacaoEnderecoModel", b =>
                {
                    b.Property<int>("idCorporacaoEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCorporacaoEndereco"));

                    b.Property<string>("complementoCorporacaoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idLogradouro")
                        .HasColumnType("int");

                    b.Property<string>("numeroCorporacaoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCorporacaoEndereco");

                    b.ToTable("TB_CORPORACAO_ENDERECO");

                    b.HasData(
                        new
                        {
                            idCorporacaoEndereco = 1,
                            complementoCorporacaoEndereco = "",
                            idLogradouro = 1,
                            numeroCorporacaoEndereco = "443"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.CursoEndereco", b =>
                {
                    b.Property<int>("idCursoEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCursoEndereco"));

                    b.Property<string>("complementoCursoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idLogradouro")
                        .HasColumnType("int");

                    b.Property<string>("numeroCursoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCursoEndereco");

                    b.ToTable("TB_CURSO_ENDERECO");

                    b.HasData(
                        new
                        {
                            idCursoEndereco = 1,
                            complementoCursoEndereco = "",
                            idLogradouro = 2,
                            numeroCursoEndereco = "221"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.EgressoEnderecoModel", b =>
                {
                    b.Property<int>("idEgressoEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEgressoEndereco"));

                    b.Property<int?>("EgressoidEgresso")
                        .HasColumnType("int");

                    b.Property<string>("complementoEgressoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEgresso")
                        .HasColumnType("int");

                    b.Property<int>("idLogradouro")
                        .HasColumnType("int");

                    b.Property<string>("numeroEgressoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEgressoEndereco");

                    b.HasIndex("EgressoidEgresso");

                    b.ToTable("TB_EGRESSO_ENDERECO");

                    b.HasData(
                        new
                        {
                            idEgressoEndereco = 1,
                            complementoEgressoEndereco = "",
                            idEgresso = 0,
                            idLogradouro = 4,
                            numeroEgressoEndereco = "787"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.LogradouroModel", b =>
                {
                    b.Property<int>("idLogradouro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idLogradouro"));

                    b.Property<string>("bairroLogradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cepLogradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cidadeLogradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoLogradouro")
                        .HasColumnType("int");

                    b.Property<string>("ufLogradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idLogradouro");

                    b.ToTable("TB_LOGRADOURO");

                    b.HasData(
                        new
                        {
                            idLogradouro = 1,
                            bairroLogradouro = "Pimentas",
                            cepLogradouro = "332432",
                            cidadeLogradouro = "Guarulhos",
                            tipoLogradouro = 0,
                            ufLogradouro = "34"
                        },
                        new
                        {
                            idLogradouro = 2,
                            bairroLogradouro = "Vila Maria",
                            cepLogradouro = "33244232",
                            cidadeLogradouro = "Sao Paulo",
                            tipoLogradouro = 0,
                            ufLogradouro = "44"
                        },
                        new
                        {
                            idLogradouro = 3,
                            bairroLogradouro = "Pimentas",
                            cepLogradouro = "332432",
                            cidadeLogradouro = "Guarulhos",
                            tipoLogradouro = 0,
                            ufLogradouro = "34"
                        },
                        new
                        {
                            idLogradouro = 4,
                            bairroLogradouro = "Pimentas",
                            cepLogradouro = "332432",
                            cidadeLogradouro = "Guarulhos",
                            tipoLogradouro = 0,
                            ufLogradouro = "364"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.VagaEndereco", b =>
                {
                    b.Property<int>("idVagaEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVagaEndereco"));

                    b.Property<string>("complementoVagaEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idLogradouro")
                        .HasColumnType("int");

                    b.Property<string>("numeroVagaEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idVagaEndereco");

                    b.ToTable("TB_VAGA_ENDERECO");

                    b.HasData(
                        new
                        {
                            idVagaEndereco = 1,
                            complementoVagaEndereco = "",
                            idLogradouro = 3,
                            numeroVagaEndereco = "899"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.PublicacaoModel", b =>
                {
                    b.Property<int>("idPublicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPublicacao"));

                    b.Property<int>("avaliacaoPublicacao")
                        .HasColumnType("int");

                    b.Property<string>("conteudoPublicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCorporacao")
                        .HasColumnType("int");

                    b.Property<string>("títuloPublicacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPublicacao");

                    b.ToTable("TB_PUBLICACAO");

                    b.HasData(
                        new
                        {
                            idPublicacao = 1,
                            avaliacaoPublicacao = 1,
                            conteudoPublicacao = "Conteúdo top",
                            idCorporacao = 1,
                            títuloPublicacao = "Publicacao"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.VagaModel", b =>
                {
                    b.Property<int>("idVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVaga"));

                    b.Property<string>("descricaoVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCorporacao")
                        .HasColumnType("int");

                    b.Property<int>("idVagaEndereco")
                        .HasColumnType("int");

                    b.Property<string>("nomeVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoVaga")
                        .HasColumnType("int");

                    b.HasKey("idVaga");

                    b.ToTable("TB_VAGA");

                    b.HasData(
                        new
                        {
                            idVaga = 1,
                            descricaoVaga = "Vaga júnior desenvolvedor",
                            idCorporacao = 1,
                            idVagaEndereco = 1,
                            nomeVaga = "Desenvolvedor Júnior",
                            tipoVaga = 1
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.EgressoEnderecoModel", b =>
                {
                    b.HasOne("ChronosApi.Models.EgressoModel", "Egresso")
                        .WithMany()
                        .HasForeignKey("EgressoidEgresso");

                    b.Navigation("Egresso");
                });
#pragma warning restore 612, 618
        }
    }
}
