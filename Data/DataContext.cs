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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Egresso>().HasData
            (
                  new Egresso() { idEgresso = 1, nomeEgresso = "Pedro", email = "ops.gmail", numeroEgresso = "8922", cpfEgresso = "222", tipoPessoaEgresso = TipoPessoaEgresso.fisico }
            );
        }




    }
}
