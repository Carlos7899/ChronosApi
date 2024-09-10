using ChronosApi.Models;
using ChronosApi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChronosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        { 
        
        }

        #region DbSet's
        public DbSet<Egresso> TB_EGRESSO { get; set; }
        public DbSet<Corporacao> TB_CORPORACAO { get; set; }
        public DbSet<Candidatura> TB_CANDIDATURA { get; set; }
        public DbSet<Comentario> TB_COMENTARIOS { get; set; }
        public DbSet<Curso> TB_CURSO { get; set; }
        public DbSet<Publicacao> TB_PUBLICACAO { get; set; }
        public DbSet<Vaga> TB_VAGA { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Egresso>().HasData
            (
                new Egresso() { idEgresso = 1, nomeEgresso = "Pedro", email = "ops.gmail", numeroEgresso = "8922", cpfEgresso = "222", tipoPessoaEgresso = TipoPessoaEgresso.fisico }
            );

            modelBuilder.Entity<Corporacao>().HasData
            (
                new Corporacao() { idCorporacao = 1, idCorporacaoEndereco = 1, tipoCorporacao = TipoCorporacao.Empresa, nomeCorporacao = "Corporação Exemplo", emailCorporacao = "contato@exemplo.com", numeroCorporacao = "12345678", descricaoCorporacao = "Exemplo de corporação", cnpjCorporacao = "12.345.678/0001-99" }
            );

            modelBuilder.Entity<Candidatura>().HasData
            (
                new Candidatura() { idCandidatura = 1, idEgresso = 1, idVaga = 1, dataIncricao = DateTime.Now }
            );

            modelBuilder.Entity<Comentario>().HasData
            (
                new Comentario() { idComentario = 1, idEgresso = 1, idPublicacao = 1, comentarioPublicacao = "Minha empresa esta contratando PCD para trabalharem"}
            );

            modelBuilder.Entity<Curso>().HasData
            (
                new Curso() { idCurso = 1, idCorporacao = 1, idCorporacaoEndereco = 1, nomeCurso = "Desenvolvimento de Sistemas", descricaoCurso = "Curso especializado no aprendizado de hardwares e códigos"}
            );

            modelBuilder.Entity<Publicacao>().HasData
            (
                new Publicacao() { idPublicacao = 1, idCorporacao = 1, títuloPublicacao = "Teste top", conteudoPublicacao = "Conteúdo top", avaliacaoPublicacao = 1}
            );

            modelBuilder.Entity<Vaga>().HasData
            (
                new Vaga() { idVaga = 1, idCorporacao = 1, idVagaEndereco = 1, nomeVaga = "Desenvolvedor Júnior", tipoVaga = 1, descricaoVaga = "Vaga júnior desenvolvedor"}
            );
        }
    }
}