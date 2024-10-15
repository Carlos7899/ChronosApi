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

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataIncricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("idEgresso")
                        .HasColumnType("int");

                    b.Property<int>("idVaga")
                        .HasColumnType("int");

                    b.HasKey("idCandidatura");

                    b.HasIndex("idEgresso");

                    b.HasIndex("idVaga");

                    b.ToTable("TB_CANDIDATURA");

                    b.HasData(
                        new
                        {
                            idCandidatura = 1,
                            Status = 3,
                            dataIncricao = new DateTime(2024, 10, 15, 11, 32, 57, 46, DateTimeKind.Local).AddTicks(8357),
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

                    b.HasIndex("idEgresso");

                    b.HasIndex("idPublicacao");

                    b.ToTable("TB_COMENTARIOS");

                    b.HasData(
                        new
                        {
                            idComentario = 1,
                            comentarioPublicacao = "Minha empresa esta contratando auxiliares na cozinha para trabalharem",
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

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("cnpjCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricaoCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailCorporacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            DataAcesso = new DateTime(2024, 10, 15, 11, 32, 57, 46, DateTimeKind.Local).AddTicks(8342),
                            PasswordHash = new byte[] { 207, 100, 242, 240, 234, 66, 106, 243, 217, 15, 51, 149, 140, 96, 252, 154, 136, 59, 154, 74, 3, 37, 76, 191, 250, 2, 62, 143, 8, 228, 96, 255, 194, 33, 50, 151, 109, 13, 214, 126, 55, 157, 229, 253, 19, 122, 173, 152, 211, 111, 173, 200, 112, 220, 130, 189, 78, 0, 50, 57, 43, 56, 183, 180 },
                            PasswordSalt = new byte[] { 171, 15, 129, 205, 147, 46, 166, 94, 71, 174, 146, 212, 126, 185, 114, 42, 189, 169, 101, 49, 60, 121, 190, 124, 126, 183, 114, 46, 30, 153, 136, 200, 198, 240, 183, 56, 127, 205, 128, 0, 242, 164, 241, 171, 36, 183, 12, 238, 88, 116, 40, 3, 22, 203, 121, 244, 73, 5, 144, 119, 139, 13, 75, 85, 117, 69, 60, 158, 17, 171, 60, 22, 163, 55, 76, 61, 169, 64, 231, 240, 209, 102, 167, 71, 95, 199, 200, 247, 32, 197, 1, 2, 126, 74, 224, 203, 7, 216, 120, 163, 250, 50, 20, 230, 136, 187, 113, 51, 71, 213, 60, 101, 205, 236, 205, 222, 46, 155, 122, 154, 58, 16, 121, 152, 20, 95, 245, 5 },
                            cnpjCorporacao = "12.345.678/0001-99",
                            descricaoCorporacao = "Exemplo de corporação",
                            emailCorporacao = "contato@exemplo.com",
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

                    b.Property<int>("cargaHorariaCurso")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataFimCurso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataInicioCurso")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricaoCurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCorporacao")
                        .HasColumnType("int");

                    b.Property<int?>("limiteVagas")
                        .HasColumnType("int");

                    b.Property<string>("nomeCurso")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idCurso");

                    b.HasIndex("idCorporacao");

                    b.ToTable("TB_CURSO");

                    b.HasData(
                        new
                        {
                            idCurso = 1,
                            cargaHorariaCurso = 40,
                            dataFimCurso = new DateTime(2025, 1, 15, 11, 32, 57, 47, DateTimeKind.Local).AddTicks(9640),
                            dataInicioCurso = new DateTime(2024, 10, 15, 11, 32, 57, 47, DateTimeKind.Local).AddTicks(9634),
                            descricaoCurso = "Curso especializado no aprendizado de hardwares e códigos",
                            idCorporacao = 1,
                            nomeCurso = "Desenvolvimento de Sistemas"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.EgressoModel", b =>
                {
                    b.Property<int>("idEgresso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idEgresso"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("cpfEgresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailEgresso")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("nomeEgresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroEgresso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoEgresso")
                        .HasColumnType("int");

                    b.HasKey("idEgresso");

                    b.ToTable("TB_EGRESSO");

                    b.HasData(
                        new
                        {
                            idEgresso = 3,
                            DataAcesso = new DateTime(2024, 10, 15, 11, 32, 57, 46, DateTimeKind.Local).AddTicks(8200),
                            PasswordHash = new byte[] { 207, 100, 242, 240, 234, 66, 106, 243, 217, 15, 51, 149, 140, 96, 252, 154, 136, 59, 154, 74, 3, 37, 76, 191, 250, 2, 62, 143, 8, 228, 96, 255, 194, 33, 50, 151, 109, 13, 214, 126, 55, 157, 229, 253, 19, 122, 173, 152, 211, 111, 173, 200, 112, 220, 130, 189, 78, 0, 50, 57, 43, 56, 183, 180 },
                            PasswordSalt = new byte[] { 171, 15, 129, 205, 147, 46, 166, 94, 71, 174, 146, 212, 126, 185, 114, 42, 189, 169, 101, 49, 60, 121, 190, 124, 126, 183, 114, 46, 30, 153, 136, 200, 198, 240, 183, 56, 127, 205, 128, 0, 242, 164, 241, 171, 36, 183, 12, 238, 88, 116, 40, 3, 22, 203, 121, 244, 73, 5, 144, 119, 139, 13, 75, 85, 117, 69, 60, 158, 17, 171, 60, 22, 163, 55, 76, 61, 169, 64, 231, 240, 209, 102, 167, 71, 95, 199, 200, 247, 32, 197, 1, 2, 126, 74, 224, 203, 7, 216, 120, 163, 250, 50, 20, 230, 136, 187, 113, 51, 71, 213, 60, 101, 205, 236, 205, 222, 46, 155, 122, 154, 58, 16, 121, 152, 20, 95, 245, 5 },
                            cpfEgresso = "22222222222",
                            emailEgresso = "admin@example.com",
                            nomeEgresso = "Admin",
                            numeroEgresso = "40028922",
                            tipoEgresso = 0
                        },
                        new
                        {
                            idEgresso = 1,
                            DataAcesso = new DateTime(2024, 10, 15, 11, 32, 57, 46, DateTimeKind.Local).AddTicks(8323),
                            PasswordHash = new byte[] { 207, 100, 242, 240, 234, 66, 106, 243, 217, 15, 51, 149, 140, 96, 252, 154, 136, 59, 154, 74, 3, 37, 76, 191, 250, 2, 62, 143, 8, 228, 96, 255, 194, 33, 50, 151, 109, 13, 214, 126, 55, 157, 229, 253, 19, 122, 173, 152, 211, 111, 173, 200, 112, 220, 130, 189, 78, 0, 50, 57, 43, 56, 183, 180 },
                            PasswordSalt = new byte[] { 171, 15, 129, 205, 147, 46, 166, 94, 71, 174, 146, 212, 126, 185, 114, 42, 189, 169, 101, 49, 60, 121, 190, 124, 126, 183, 114, 46, 30, 153, 136, 200, 198, 240, 183, 56, 127, 205, 128, 0, 242, 164, 241, 171, 36, 183, 12, 238, 88, 116, 40, 3, 22, 203, 121, 244, 73, 5, 144, 119, 139, 13, 75, 85, 117, 69, 60, 158, 17, 171, 60, 22, 163, 55, 76, 61, 169, 64, 231, 240, 209, 102, 167, 71, 95, 199, 200, 247, 32, 197, 1, 2, 126, 74, 224, 203, 7, 216, 120, 163, 250, 50, 20, 230, 136, 187, 113, 51, 71, 213, 60, 101, 205, 236, 205, 222, 46, 155, 122, 154, 58, 16, 121, 152, 20, 95, 245, 5 },
                            cpfEgresso = "222",
                            emailEgresso = "ops.gmail",
                            nomeEgresso = "Pedro",
                            numeroEgresso = "8922",
                            tipoEgresso = 1
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

                    b.Property<int>("idCorporacao")
                        .HasColumnType("int");

                    b.Property<int>("idLogradouro")
                        .HasColumnType("int");

                    b.Property<string>("numeroCorporacaoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCorporacaoEndereco");

                    b.HasIndex("idCorporacao")
                        .IsUnique();

                    b.HasIndex("idLogradouro")
                        .IsUnique();

                    b.ToTable("TB_CORPORACAO_ENDERECO");

                    b.HasData(
                        new
                        {
                            idCorporacaoEndereco = 1,
                            complementoCorporacaoEndereco = "bloco",
                            idCorporacao = 1,
                            idLogradouro = 1,
                            numeroCorporacaoEndereco = "443"
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.CursoEnderecoModel", b =>
                {
                    b.Property<int>("idCursoEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCursoEndereco"));

                    b.Property<string>("complementoCursoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCurso")
                        .HasColumnType("int");

                    b.Property<int>("idLogradouro")
                        .HasColumnType("int");

                    b.Property<string>("numeroCursoEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCursoEndereco");

                    b.HasIndex("idCurso")
                        .IsUnique();

                    b.HasIndex("idLogradouro")
                        .IsUnique();

                    b.ToTable("TB_CURSO_ENDERECO");

                    b.HasData(
                        new
                        {
                            idCursoEndereco = 1,
                            complementoCursoEndereco = "",
                            idCurso = 1,
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

                    b.HasIndex("idEgresso")
                        .IsUnique();

                    b.HasIndex("idLogradouro")
                        .IsUnique();

                    b.ToTable("TB_EGRESSO_ENDERECO");

                    b.HasData(
                        new
                        {
                            idEgressoEndereco = 1,
                            complementoEgressoEndereco = "",
                            idEgresso = 1,
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

            modelBuilder.Entity("ChronosApi.Models.Enderecos.VagaEnderecoModel", b =>
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

                    b.Property<int>("idVaga")
                        .HasColumnType("int");

                    b.Property<string>("numeroVagaEndereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idVagaEndereco");

                    b.HasIndex("idLogradouro")
                        .IsUnique();

                    b.HasIndex("idVaga")
                        .IsUnique();

                    b.ToTable("TB_VAGA_ENDERECO");

                    b.HasData(
                        new
                        {
                            idVagaEndereco = 1,
                            complementoVagaEndereco = "",
                            idLogradouro = 3,
                            idVaga = 1,
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

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricaoVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCorporacao")
                        .HasColumnType("int");

                    b.Property<string>("nomeVaga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoVaga")
                        .HasColumnType("int");

                    b.HasKey("idVaga");

                    b.HasIndex("idCorporacao");

                    b.ToTable("TB_VAGA");

                    b.HasData(
                        new
                        {
                            idVaga = 1,
                            DataCriacao = new DateTime(2024, 10, 15, 14, 32, 57, 48, DateTimeKind.Utc).AddTicks(3699),
                            DataVencimento = new DateTime(2024, 11, 14, 14, 32, 57, 48, DateTimeKind.Utc).AddTicks(3700),
                            descricaoVaga = "Vaga júnior desenvolvedor",
                            idCorporacao = 1,
                            nomeVaga = "Desenvolvedor Júnior",
                            tipoVaga = 1
                        });
                });

            modelBuilder.Entity("ChronosApi.Models.CandidaturaModel", b =>
                {
                    b.HasOne("ChronosApi.Models.EgressoModel", null)
                        .WithMany()
                        .HasForeignKey("idEgresso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChronosApi.Models.VagaModel", null)
                        .WithMany()
                        .HasForeignKey("idVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChronosApi.Models.ComentarioModel", b =>
                {
                    b.HasOne("ChronosApi.Models.EgressoModel", null)
                        .WithMany()
                        .HasForeignKey("idEgresso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChronosApi.Models.PublicacaoModel", null)
                        .WithMany()
                        .HasForeignKey("idPublicacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChronosApi.Models.CursoModel", b =>
                {
                    b.HasOne("ChronosApi.Models.CorporacaoModel", null)
                        .WithMany("Cursos")
                        .HasForeignKey("idCorporacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.CorporacaoEnderecoModel", b =>
                {
                    b.HasOne("ChronosApi.Models.CorporacaoModel", "corporacao")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.CorporacaoEnderecoModel", "idCorporacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChronosApi.Models.Enderecos.LogradouroModel", "logradouro")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.CorporacaoEnderecoModel", "idLogradouro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("corporacao");

                    b.Navigation("logradouro");
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.CursoEnderecoModel", b =>
                {
                    b.HasOne("ChronosApi.Models.CursoModel", "curso")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.CursoEnderecoModel", "idCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChronosApi.Models.Enderecos.LogradouroModel", "logradouro")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.CursoEnderecoModel", "idLogradouro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("curso");

                    b.Navigation("logradouro");
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.EgressoEnderecoModel", b =>
                {
                    b.HasOne("ChronosApi.Models.EgressoModel", "Egresso")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.EgressoEnderecoModel", "idEgresso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChronosApi.Models.Enderecos.LogradouroModel", "Logradouro")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.EgressoEnderecoModel", "idLogradouro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Egresso");

                    b.Navigation("Logradouro");
                });

            modelBuilder.Entity("ChronosApi.Models.Enderecos.VagaEnderecoModel", b =>
                {
                    b.HasOne("ChronosApi.Models.Enderecos.LogradouroModel", "logradouro")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.VagaEnderecoModel", "idLogradouro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChronosApi.Models.VagaModel", "vaga")
                        .WithOne()
                        .HasForeignKey("ChronosApi.Models.Enderecos.VagaEnderecoModel", "idVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("logradouro");

                    b.Navigation("vaga");
                });

            modelBuilder.Entity("ChronosApi.Models.VagaModel", b =>
                {
                    b.HasOne("ChronosApi.Models.CorporacaoModel", "Corporacao")
                        .WithMany("Vagas")
                        .HasForeignKey("idCorporacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corporacao");
                });

            modelBuilder.Entity("ChronosApi.Models.CorporacaoModel", b =>
                {
                    b.Navigation("Cursos");

                    b.Navigation("Vagas");
                });
#pragma warning restore 612, 618
        }
    }
}
