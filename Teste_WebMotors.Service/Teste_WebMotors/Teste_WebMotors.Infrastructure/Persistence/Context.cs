using Microsoft.EntityFrameworkCore;
using Teste_WebMotors.Core.Entities;

namespace Teste_WebMotors.Infrastructure
{
    public class Context: DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Anuncio> Anuncios { get; set; }

        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>().ToTable("tb_AnuncioWebmotors");
            modelBuilder.Entity<Anuncio>().Property(p => p.Marca)
                .HasColumnType("varchar(45)")
                .IsRequired();
            modelBuilder.Entity<Anuncio>().Property(p => p.Modelo)
                .HasColumnType("varchar(45)")
                .IsRequired();
            modelBuilder.Entity<Anuncio>().Property(p => p.Versao)
                .HasColumnType("varchar(45)")
                .IsRequired();
            modelBuilder.Entity<Anuncio>().Property(p => p.Ano)
                .HasColumnType("int")
                .IsRequired();
            modelBuilder.Entity<Anuncio>().Property(p => p.Quilometragem)
                .HasColumnType("int")
                .IsRequired();
            modelBuilder.Entity<Anuncio>().Property(p => p.Observacao)
                .HasColumnType("text")
                .IsRequired();
        }
    }
}
