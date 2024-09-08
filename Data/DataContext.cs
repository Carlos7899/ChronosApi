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

        public DbSet<Egresso> TB_EGRESSO { get; set; }
        public DbSet<Corporacao> TB_CORPORACAO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Egresso>().HasData
            (
                new Egresso() { idEgresso = 1, nomeEgresso = "Pedro", email = "ops.gmail", numeroEgresso = "8922", cpfEgresso = "222", tipoPessoaEgresso = TipoPessoaEgresso.fisico }
            );

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
                    cnpjCorporacao = "12.345.678/0001-99"
                }
            );

        }
    }
}