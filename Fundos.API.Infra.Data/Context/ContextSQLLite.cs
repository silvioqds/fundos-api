using Fundos.Api.Domain.Entity;
using Fundos.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fundos.API.Infra.Data.Context
{
    public class ContextSQLLite : DbContext
    {
        public ContextSQLLite(DbContextOptions<ContextSQLLite> options) : base(options)
        {
        }   
        public DbSet<Fundo> Fundo { get; set; } 
        public DbSet<TipoFundo> TIPO_FUNDO { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Fundo>()
               .HasOne(f => f.TipoFundo)
               .WithMany(tf => tf.Fundos)
               .HasForeignKey(f => f.Codigo_Tipo)
               .IsRequired(); 

            modelBuilder.Entity<Fundo>()
                .HasKey(f => f.Codigo);

            modelBuilder.Entity<TipoFundo>()
            .HasKey(f => f.Codigo);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Habilitar o sensitive data logging
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}

