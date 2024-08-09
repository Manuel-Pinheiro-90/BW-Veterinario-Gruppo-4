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


            //Popolamento ditte
            modelBuilder.Entity<Ditta>().HasData(
            new Ditta { IdDitta = 1, Nome = "Next", Indirizzo = "Via Roma, 123, 00100 Roma", Recapito = "+39 331 1234567" },
            new Ditta { IdDitta = 2, Nome = "Premiere", Indirizzo = "Corso Italia, 50, 20100 Milano", Recapito = "+39 332 2345678" },
            new Ditta { IdDitta = 3, Nome = "Royal Canin", Indirizzo = "Via della Salute, 15, 10100 Torino", Recapito = "+39 333 3456789" },
            new Ditta { IdDitta = 4, Nome = "Hills", Indirizzo = "Piazza Duomo, 1, 80100 Napoli", Recapito = "+39 334 4567890" },
            new Ditta { IdDitta = 5, Nome = "Perfect", Indirizzo = "Viale Mazzini, 20, 40100 Bologna", Recapito = "+39 335 5678901" },
            new Ditta { IdDitta = 6, Nome = "NBF Lanes", Indirizzo = "Via Garibaldi, 45, 70100 Bari", Recapito = "+39 336 6789012" },
            new Ditta { IdDitta = 7, Nome = "Candioli", Indirizzo = "Piazza della Libertà, 10, 50100 Firenze", Recapito = "+39 337 7890123" },
            new Ditta { IdDitta = 8, Nome = "Vetoquinol", Indirizzo = "Corso Vittorio Emanuele, 25, 35100 Padova", Recapito = "+39 338 8901234" },
            new Ditta { IdDitta = 9, Nome = "Bayer", Indirizzo = "Via Veneto, 2, 10100 Torino", Recapito = "+39 339 9012345" },
            new Ditta { IdDitta = 10, Nome = "Purina", Indirizzo = "Viale dei Mille, 30, 80100 Napoli", Recapito = "+39 330 0123456" },
            new Ditta { IdDitta = 11, Nome = "Frontline", Indirizzo = "Via Dante, 15, 90100 Palermo", Recapito = "+39 331 1234567" }
            );


            //Popolamento cassetti
            modelBuilder.Entity<Cassetto>().HasData(
            new Cassetto { IdCassetto = 1, NumeroArmadietto = 1, NumeroCassetto = 1 },
            new Cassetto { IdCassetto = 2, NumeroArmadietto = 1, NumeroCassetto = 2 },
            new Cassetto { IdCassetto = 3, NumeroArmadietto = 1, NumeroCassetto = 3 },
            new Cassetto { IdCassetto = 4, NumeroArmadietto = 1, NumeroCassetto = 4 },
            new Cassetto { IdCassetto = 5, NumeroArmadietto = 1, NumeroCassetto = 5 },
            new Cassetto { IdCassetto = 6, NumeroArmadietto = 2, NumeroCassetto = 1 },
            new Cassetto { IdCassetto = 7, NumeroArmadietto = 2, NumeroCassetto = 2 },
            new Cassetto { IdCassetto = 8, NumeroArmadietto = 2, NumeroCassetto = 3 },
            new Cassetto { IdCassetto = 9, NumeroArmadietto = 2, NumeroCassetto = 4 },
            new Cassetto { IdCassetto = 10, NumeroArmadietto = 2, NumeroCassetto = 5 },
            new Cassetto { IdCassetto = 11, NumeroArmadietto = 3, NumeroCassetto = 1 },
            new Cassetto { IdCassetto = 12, NumeroArmadietto = 3, NumeroCassetto = 2 },
            new Cassetto { IdCassetto = 13, NumeroArmadietto = 3, NumeroCassetto = 3 },
            new Cassetto { IdCassetto = 14, NumeroArmadietto = 3, NumeroCassetto = 4 },
            new Cassetto { IdCassetto = 15, NumeroArmadietto = 3, NumeroCassetto = 5 }
            );


            //Popolazione utilizzi
            modelBuilder.Entity<Utilizzo>().HasData(
            new Utilizzo { IdUtilizzo = 1, Descrizione = "Otite" },
            new Utilizzo { IdUtilizzo = 2, Descrizione = "Raffreddore" },
            new Utilizzo { IdUtilizzo = 3, Descrizione = "Dermatite" },
            new Utilizzo { IdUtilizzo = 4, Descrizione = "Intestinale" },
            new Utilizzo { IdUtilizzo = 5, Descrizione = "Supporto immunitario" },
            new Utilizzo { IdUtilizzo = 6, Descrizione = "Convalescenza" },
            new Utilizzo { IdUtilizzo = 7, Descrizione = "Gravidanza e allattamento" },
            new Utilizzo { IdUtilizzo = 8, Descrizione = "Boli di pelo" },
            new Utilizzo { IdUtilizzo = 9, Descrizione = "Vermi" },
            new Utilizzo { IdUtilizzo = 10, Descrizione = "Funghi" },
            new Utilizzo { IdUtilizzo = 11, Descrizione = "Antibiotico" },
            new Utilizzo { IdUtilizzo = 12, Descrizione = "Antivirale" },
            new Utilizzo { IdUtilizzo = 13, Descrizione = "Cura orale" },
            new Utilizzo { IdUtilizzo = 14, Descrizione = "Urinario" },
            new Utilizzo { IdUtilizzo = 15, Descrizione = "Cardiaco" },
            new Utilizzo { IdUtilizzo = 16, Descrizione = "Energetico" },
            new Utilizzo { IdUtilizzo = 17, Descrizione = "Mobilità" },
            new Utilizzo { IdUtilizzo = 18, Descrizione = "Vista" },
            new Utilizzo { IdUtilizzo = 19, Descrizione = "Neurologico" },
            new Utilizzo { IdUtilizzo = 20, Descrizione = "Calmante" },
            new Utilizzo { IdUtilizzo = 21, Descrizione = "Epatite" },
            new Utilizzo { IdUtilizzo = 22, Descrizione = "Controllo del peso" },
            new Utilizzo { IdUtilizzo = 23, Descrizione = "Cibo Secco" },
            new Utilizzo { IdUtilizzo = 24, Descrizione = "Cibo umido" },
            new Utilizzo { IdUtilizzo = 25, Descrizione = "Snack" },
            new Utilizzo { IdUtilizzo = 26, Descrizione = "Inappetenza" },
            new Utilizzo { IdUtilizzo = 27, Descrizione = "Kitten" },
            new Utilizzo { IdUtilizzo = 28, Descrizione = "Puppy" },
            new Utilizzo { IdUtilizzo = 29, Descrizione = "Reni" }
            );


            


    }

}
}
