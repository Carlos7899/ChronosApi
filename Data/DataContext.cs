using ChronosApi.Models;
using ChronosApi.Models.Enderecos;
using ChronosApi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {}

        #region DbSet's 12
        public DbSet<Egresso> TB_EGRESSO { get; set; }
        public DbSet<Corporacao> TB_CORPORACAO { get; set; }
        public DbSet<Candidatura> TB_CANDIDATURA { get; set; }
        public DbSet<Comentario> TB_COMENTARIOS { get; set; }
        public DbSet<Curso> TB_CURSO { get; set; }
        public DbSet<Publicacao> TB_PUBLICACAO { get; set; }
        public DbSet<Vaga> TB_VAGA { get; set; }
        public DbSet<Logradouro> TB_LOGRADOURO { get; set; }
        public DbSet<CorporacaoEndereco> TB_CORPORACAO_ENDERECO { get; set; }
        public DbSet<CursoEndereco> TB_CURSO_ENDERECO { get; set; }
        public DbSet<EgressoEndereco> TB_EGRESSO_ENDERECO { get; set; }
        public DbSet<VagaEndereco> TB_VAGA_ENDERECO { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Egresso
            modelBuilder.Entity<Egresso>().HasData
            (
                new Egresso() 
                { 
                    idEgresso = 1,
                    nomeEgresso = "Pedro",
                    email = "ops.gmail",
                    numeroEgresso = "8922",
                    cpfEgresso = "222",
                    tipoPessoaEgresso = TipoPessoaEgresso.fisico ,
                    senha = "123456"
                }
            );
            #endregion

            #region Corporacao
            modelBuilder.Entity<Corporacao>().HasData
            (
                new Corporacao() 
                { 
                    idCorporacao = 1, 
                    idCorporacaoEndereco = 1, 
                    tipoCorporacao = TipoCorporacao.Empresa, 
                    nomeCorporacao = "Corporação Exemplo", 
                    emailCorporacao = "contato@exemplo.com", 
                    numeroCorporacao = "12345678", 
                    descricaoCorporacao = "Exemplo de corporação", 
                    cnpjCorporacao = "12.345.678/0001-99" ,
                    senha = "123456"                   
                }
            );
            #endregion

            #region Candidatura
            modelBuilder.Entity<Candidatura>().HasData
            (
                new Candidatura() 
                {
                    idCandidatura = 1, 
                    idEgresso = 1, 
                    idVaga = 1, 
                    dataIncricao = DateTime.Now 
                }
            );
            #endregion

            #region Comentario
            modelBuilder.Entity<Comentario>().HasData
            (
                new Comentario() { 
                    idComentario = 1, 
                    idEgresso = 1, 
                    idPublicacao = 1, 
                    comentarioPublicacao = "Minha empresa esta contratando PCD para trabalharem"
                }
            );
            #endregion

            #region Curso
            modelBuilder.Entity<Curso>().HasData
            (
                new Curso() 
                { 
                    idCurso = 1, 
                    idCorporacao = 1, 
                    idCorporacaoEndereco = 1, 
                    nomeCurso = "Desenvolvimento de Sistemas", 
                    descricaoCurso = "Curso especializado no aprendizado de hardwares e códigos"
                }
            );
            #endregion

            #region Publicacao
            modelBuilder.Entity<Publicacao>().HasData
            (
                new Publicacao() 
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
            modelBuilder.Entity<Vaga>().HasData
            (
                new Vaga() 
                { 
                    idVaga = 1, 
                    idCorporacao = 1, 
                    idVagaEndereco = 1,
                    nomeVaga = "Desenvolvedor Júnior", 
                    tipoVaga = 1, 
                    descricaoVaga = "Vaga júnior desenvolvedor"
                }
            );
            #endregion

            #region Logradouro
            modelBuilder.Entity<Logradouro>().HasData
            (
               new Logradouro()
               {
                   idLogradouro = 1,
                   bairroLogradouro = "Pimentas",
                   cepLogradouro = "332432",
                   cidadeLogradouro = "Guarulhos",
                   tipoLogradouro = TipoLogradouro.Publico,
                   ufLogradouro = "34"
               },
               new Logradouro()
               {
                   idLogradouro = 2,
                   bairroLogradouro = "Vila Maria",
                   cepLogradouro = "33244232",
                   cidadeLogradouro = "Sao Paulo",
                   tipoLogradouro = TipoLogradouro.Publico,
                   ufLogradouro = "44"
               },
               new Logradouro()
               {
                   idLogradouro = 3,
                   bairroLogradouro = "Pimentas",
                   cepLogradouro = "332432",
                   cidadeLogradouro = "Guarulhos",
                   tipoLogradouro = TipoLogradouro.Publico,
                   ufLogradouro = "34"
               },
               new Logradouro()
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
            modelBuilder.Entity<CorporacaoEndereco>().HasData
            (
               new CorporacaoEndereco() 
               { 
                   idCorporacaoEndereco = 1,
                   idLogradouro = 1,
                   complementoCorporacaoEndereco = "",
                   numeroCorporacaoEndereco = "443"
               }
            );
            #endregion

            #region CursoEndereco
            modelBuilder.Entity<CursoEndereco>().HasData
            (
                new CursoEndereco() 
                {
                    idCursoEndereco = 1 , 
                    idLogradouro = 2, 
                    complementoCursoEndereco = "", 
                    numeroCursoEndereco = "221"
                }
            );
            #endregion

            #region VagaEndereco
            modelBuilder.Entity<VagaEndereco>().HasData
            (
                new VagaEndereco() 
                {
                    idVagaEndereco = 1, 
                    idLogradouro = 3, 
                    complementoVagaEndereco = "", 
                    numeroVagaEndereco = "899" 
                }
            );
            #endregion

            #region EgressoEndereco
            modelBuilder.Entity<EgressoEndereco>().HasData
            (
                new EgressoEndereco() 
                {
                    idEgressoEndereco = 1, 
                    idLogradouro = 4, 
                    complementoEgressoEndereco = "",
                    numeroEgressoEndereco = "787"
                }
            );
            #endregion
        }
    }
}