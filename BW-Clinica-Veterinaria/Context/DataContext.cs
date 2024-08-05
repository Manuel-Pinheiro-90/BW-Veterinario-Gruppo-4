using BW_Clinica_Veterinaria.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BW_Clinica_Veterinaria.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Animale> Animali { get; set; }
        public virtual DbSet<Cassetto> Cassetti { get; set; }
        public virtual DbSet<Ditta>Ditte { get; set; }
        public virtual DbSet<Prodotto> Prodotti { get; set; }
        public virtual DbSet<Proprietario> Proprietari { get; set; }
        public virtual DbSet<Ricovero> Ricoveri { get; set; }
        public virtual DbSet<Ruolo> Ruoli { get; set; }
        public virtual DbSet<Utente> Utenti { get; set; }
        public virtual DbSet<Utilizzo> Utilizzi { get; set; }
        public virtual DbSet<Vendita> Vendite { get; set; }
        public virtual DbSet<Visita> Visite { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prodotto>()
            .HasMany(p => p.Utilizzi)
            .WithMany(u => u.Prodotti)
            .UsingEntity(j => j.ToTable("ProdottoUtilizzo"));



            modelBuilder.Entity<Utente>()
            .HasMany(u => u.Ruoli)
            .WithMany(r => r.Utenti)
            .UsingEntity(j => j.ToTable("UtenteRuolo"));


        }






    }
}
