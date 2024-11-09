using ChronosApi.Models;
using ChronosApi.Models.Curriculo;
using ChronosApi.Models.Enderecos;
using ChronosApi.Models.Enums;
using ChronosApi.Services.Utils;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {}

        #region DBSets
        public DbSet<EgressoModel> TB_EGRESSO { get; set; }
        public DbSet<CorporacaoModel> TB_CORPORACAO { get; set; }
        public DbSet<CandidaturaModel> TB_CANDIDATURA { get; set; }
        public DbSet<ComentarioModel> TB_COMENTARIOS { get; set; }
        public DbSet<CursoModel> TB_CURSO { get; set; }
        public DbSet<PublicacaoModel> TB_PUBLICACAO { get; set; }
        public DbSet<VagaModel> TB_VAGA { get; set; }

        #region Curriculo

        public DbSet<CurriculoModel> TB_CURRICULO { get; set; }
        public DbSet<ExperienciaModel> TB_EXPERIENCIA { get; set; }
        public DbSet<FormacaoModel> TB_FORMACAO { get; set; }

        #endregion

        #region Enderecos
        public DbSet<LogradouroModel> TB_LOGRADOURO { get; set; }
        public DbSet<CorporacaoEnderecoModel> TB_CORPORACAO_ENDERECO { get; set; }
        public DbSet<CursoEnderecoModel> TB_CURSO_ENDERECO { get; set; }
        public DbSet<EgressoEnderecoModel> TB_EGRESSO_ENDERECO { get; set; }
        public DbSet<VagaEnderecoModel> TB_VAGA_ENDERECO { get; set; }
        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            byte[] passwordHash, passwordSalt;

            Criptografia.CriarPasswordHash("123456", out passwordHash, out passwordSalt);

            var adminUser = new EgressoModel
            {
                idEgresso = 3,
                nomeEgresso = "Admin",
                emailEgresso = "admin@example.com",
                numeroEgresso = "40028922",
                cpfEgresso = "22222222222",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DataAcesso = DateTime.Now
            };
            modelBuilder.Entity<EgressoModel>().HasData(adminUser);

            #region Egresso
            modelBuilder.Entity<EgressoModel>().HasData
            (
                new EgressoModel() 
                { 
                    idEgresso = 1,
                    nomeEgresso = "Pedro",
                    emailEgresso = "ops.gmail",
                    numeroEgresso = "8922",
                    cpfEgresso = "222",
                    tipoEgresso = TipoEgresso.fisico,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    DataAcesso = DateTime.Now
                }
            );
            #endregion

            #region Corporacao
            modelBuilder.Entity<CorporacaoModel>().HasData
            (
                new CorporacaoModel() 
                { 
                    idCorporacao = 1, 
                    tipoCorporacao = TipoCorporacao.Empresa, 
                    nomeCorporacao = "Corporação Exemplo", 
                    emailCorporacao = "contato@exemplo.com", 
                    numeroCorporacao = "12345678", 
                    descricaoCorporacao = "Exemplo de corporação", 
                    cnpjCorporacao = "12.345.678/0001-99",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    DataAcesso = DateTime.Now
                }
            );
            #endregion

            #region Candidatura
            modelBuilder.Entity<CandidaturaModel>().HasData(
                new CandidaturaModel()
                {
                    idCandidatura = 1,
                    idEgresso = 1,
                    idVaga = 1,
                    dataIncricao = DateTime.Now,
                    Status = StatusCandidatura.EmAnalise, 
                    DataAtualizacao = null,
                    Notas = null,
                    Feedback = null
                });

            modelBuilder.Entity<CandidaturaModel>()
                .HasKey(c => c.idCandidatura);

            modelBuilder.Entity<CandidaturaModel>()
                .HasOne<EgressoModel>() 
                .WithMany() 
                .HasForeignKey(c => c.idEgresso)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CandidaturaModel>()
                .HasOne<VagaModel>() 
                .WithMany() 
                .HasForeignKey(c => c.idVaga)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Comentario
            modelBuilder.Entity<ComentarioModel>().HasData
            (
                new ComentarioModel()
                {
                    idComentario = 1,
                    idEgresso = 1,
                    idPublicacao = 1,
                    comentarioPublicacao = "Minha empresa esta contratando auxiliares na cozinha para trabalharem"
                }
            );

            modelBuilder.Entity<ComentarioModel>()
                .HasOne<EgressoModel>()
                .WithMany()
                .HasForeignKey(c => c.idEgresso)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComentarioModel>()
                .HasOne<PublicacaoModel>()
                .WithMany()
                .HasForeignKey(c => c.idPublicacao)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Curso
            modelBuilder.Entity<CursoModel>().HasData
            (
                new CursoModel()
                {
                    idCurso = 1,
                    idCorporacao = 1,
                    nomeCurso = "Desenvolvimento de Sistemas",
                    descricaoCurso = "Curso especializado no aprendizado de hardwares e códigos",
                    cargaHorariaCurso = 40,
                    dataInicioCurso = DateTime.Now,
                    dataFimCurso = DateTime.Now.AddMonths(3),

                }
            );
            modelBuilder.Entity<CursoModel>()
              .HasOne<CorporacaoModel>() 
              .WithMany(c => c.Cursos)   
              .HasForeignKey(c => c.idCorporacao) 
              .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Publicacao
            modelBuilder.Entity<PublicacaoModel>().HasData
            (
                new PublicacaoModel() 
                {
                    idPublicacao = 1, 
                    idCorporacao = 1, 
                    títuloPublicacao = "Publicacao", 
                    conteudoPublicacao = "Conteúdo top", 
                    avaliacaoPublicacao = 1
                }
            );
            #endregion

            #region Vaga
            modelBuilder.Entity<VagaModel>().HasData
            (
                new VagaModel() 
                { 
                    idVaga = 1, 
                    idCorporacao = 1,
                    nomeVaga = "Desenvolvedor Júnior", 
                    descricaoVaga = "Vaga júnior desenvolvedor",
                    DataCriacao = DateTime.UtcNow, 
                    DataVencimento = DateTime.UtcNow.AddDays(30)
                }
            );

            modelBuilder.Entity<VagaModel>()
              .HasOne(v => v.Corporacao)
              .WithMany(c => c.Vagas)
              .HasForeignKey(v => v.idCorporacao)
              .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Curriculo 

            #region Curriculo
            modelBuilder.Entity<CurriculoModel>().HasData
           (

             new CurriculoModel()
             {
                 idCurriculo = 1,
                 idEgresso = 1,
                 emailCurriculo = "curriculo1@example.com",
                 telefoneCurriculo = "11999999999",
                 habilidadesCurriculo = "C#, ASP.NET Core, SQL Server",
                 descricaoCurriculo = "Desenvolvedor de software com experiência em .NET."
             }
            );

            modelBuilder.Entity<CurriculoModel>()
               .HasOne(c => c.Egresso)
               .WithOne(e => e.Curriculo)
               .HasForeignKey<CurriculoModel>(c => c.idEgresso);

            modelBuilder.Entity<CurriculoModel>()
             .HasMany(c => c.ExperienciasProfissionais)
             .WithOne(e => e.Curriculo)
             .HasForeignKey(e => e.idCurriculo)
             .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<CurriculoModel>()
                .HasMany(c => c.FormacoesAcademicas)
                .WithOne(f => f.Curriculo)
                .HasForeignKey(f => f.idCurriculo)
                .OnDelete(DeleteBehavior.Cascade);



            #endregion

            #region Experiencia
                    modelBuilder.Entity<ExperienciaModel>().HasData
                    (
                        new ExperienciaModel
                        {
                            idExperiencia = 1,
                            idCurriculo = 1,
                            cargoExperiencia = "Desenvolvedor Júnior",
                            empresaExperiencia = "Empresa XYZ",
                            dataInicioExperiencia = new DateTime(2022, 01, 01),
                            dataFimExperiencia = new DateTime(2023, 01, 01),
                            Descricao = "Desenvolvimento de aplicações web."
                        }
                    );
                    modelBuilder.Entity<ExperienciaModel>()
                       .HasOne<CurriculoModel>()
                       .WithMany(c => c.ExperienciasProfissionais)
                       .HasForeignKey(e => e.idCurriculo);
                    #endregion

            #region Formacao
                    modelBuilder.Entity<FormacaoModel>().HasData
                    (
                        new FormacaoModel
                        {
                            idFormacao = 1,
                            idCurriculo = 1, 
                            cursoFormacao = "Análise e Desenvolvimento de Sistemas",
                            instituicaoFormacao = "Universidade ABC",
                            dataConclusaoFormacao = new DateTime(2021, 12, 01)
                        }
                    );
                    modelBuilder.Entity<FormacaoModel>()
                     .HasOne<CurriculoModel>()
                     .WithMany(c => c.FormacoesAcademicas)
                     .HasForeignKey(e => e.idCurriculo);
                    #endregion 

            #endregion

            #region Endereços

            #region Logradouro
            modelBuilder.Entity<LogradouroModel>().HasData
            (
               new LogradouroModel()
               {
                   idLogradouro = 1,
                   bairroLogradouro = "Pimentas",
                   cepLogradouro = "332432",
                   cidadeLogradouro = "Guarulhos",
                   tipoLogradouro = TipoLogradouro.Publico,
                   ufLogradouro = "34"
               },
               new LogradouroModel()
               {
                   idLogradouro = 2,
                   bairroLogradouro = "Vila Maria",
                   cepLogradouro = "33244232",
                   cidadeLogradouro = "Sao Paulo",
                   tipoLogradouro = TipoLogradouro.Publico,
                   ufLogradouro = "44"
               },
               new LogradouroModel()
               {
                   idLogradouro = 3,
                   bairroLogradouro = "Pimentas",
                   cepLogradouro = "332432",
                   cidadeLogradouro = "Guarulhos",
                   tipoLogradouro = TipoLogradouro.Publico,
                   ufLogradouro = "34"
               },
               new LogradouroModel()
               {
                   idLogradouro = 4,
                   bairroLogradouro = "Pimentas",
                   cepLogradouro = "332432",
                   cidadeLogradouro = "Guarulhos",
                   tipoLogradouro = TipoLogradouro.Publico,
                   ufLogradouro = "364"
               }

            );
            #endregion

            #region CorporacaoEndereco
            modelBuilder.Entity<CorporacaoEnderecoModel>().HasData
            (
               new CorporacaoEnderecoModel() 
               { 
                   idCorporacaoEndereco = 1,
                   idCorporacao = 1,
                   idLogradouro = 1,
                   complementoCorporacaoEndereco = "bloco",
                   numeroCorporacaoEndereco = "443"
               }
            );

            modelBuilder.Entity<CorporacaoEnderecoModel>()
            .HasOne(cc => cc.corporacao)
            .WithOne()
            .HasForeignKey<CorporacaoEnderecoModel>(ee => ee.idCorporacao);

            modelBuilder.Entity<CorporacaoEnderecoModel>()
             .HasOne(cc => cc.logradouro)
             .WithOne()
             .HasForeignKey<CorporacaoEnderecoModel>(cc => cc.idLogradouro);
            #endregion

            #region CursoEndereco
            modelBuilder.Entity<CursoEnderecoModel>().HasData
            (
                new CursoEnderecoModel() 
                {
                    idCursoEndereco = 1 , 
                    idLogradouro = 2, 
                    idCurso = 1,
                    complementoCursoEndereco = "", 
                    numeroCursoEndereco = "221"
                }
            );

            modelBuilder.Entity<CursoEnderecoModel>()
                 .HasOne(cc => cc.curso)
                 .WithOne()
                 .HasForeignKey<CursoEnderecoModel>(ee => ee.idCurso);

            modelBuilder.Entity<CursoEnderecoModel>()
                   .HasOne(cc => cc.logradouro)
                   .WithOne()
                   .HasForeignKey<CursoEnderecoModel>(cc => cc.idLogradouro);
            #endregion

            #region VagaEndereco
            modelBuilder.Entity<VagaEnderecoModel>().HasData
            (
                new VagaEnderecoModel() 
                {
                    idVagaEndereco = 1, 
                    idLogradouro = 3,
                    idVaga = 1,
                    complementoVagaEndereco = "", 
                    numeroVagaEndereco = "899" 
                }
            );
            modelBuilder.Entity<VagaEnderecoModel>()
             .HasOne(ve => ve.vaga)
             .WithOne()
             .HasForeignKey<VagaEnderecoModel>(ve => ve.idVaga)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VagaEnderecoModel>()
             .HasOne(ve => ve.logradouro)
             .WithOne()
             .HasForeignKey<VagaEnderecoModel>(ve => ve.idLogradouro);


            #endregion

            #region EgressoEndereco
            modelBuilder.Entity<EgressoEnderecoModel>().HasData
            (
                new EgressoEnderecoModel() 
                {
                    idEgressoEndereco = 1, 
                    idEgresso = 1,
                    idLogradouro = 4, 
                    complementoEgressoEndereco = "",
                    numeroEgressoEndereco = "787"
                }
            );

            modelBuilder.Entity<EgressoEnderecoModel>()
             .HasOne(ee => ee.Egresso) // Um endereço pertence a um egresso
             .WithOne() // Um egresso tem um endereço
             .HasForeignKey<EgressoEnderecoModel>(ee => ee.idEgresso);

            modelBuilder.Entity<EgressoEnderecoModel>()
             .HasOne(ee => ee.Logradouro) // Um endereço pertence a um logradouro
             .WithOne() // Um logradouro pode ter um endereços
             .HasForeignKey<EgressoEnderecoModel>(ee => ee.idLogradouro);
            #endregion

            #endregion

        }
    }
}