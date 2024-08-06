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


            //Popolazione prodotti
            modelBuilder.Entity<Prodotto>().HasData(
            new Prodotto { IdProdotto = 1, Nome = "Next Dry Food Adult Dog", IdDitta = 1, Tipo = "Alimentare", IdCassetto = 3 },
            new Prodotto { IdProdotto = 2, Nome = "Next Wet Food Kitten", IdDitta = 1, Tipo = "Alimentare", IdCassetto = 5 },
            new Prodotto { IdProdotto = 3, Nome = "Next Treats Dental", IdDitta = 1, Tipo = "Alimentare", IdCassetto = 8 },
            new Prodotto { IdProdotto = 4, Nome = "Next Senior Cat Food", IdDitta = 1, Tipo = "Alimentare", IdCassetto = 12 },
            new Prodotto { IdProdotto = 5, Nome = "Next Puppy Food", IdDitta = 1, Tipo = "Alimentare", IdCassetto = 10 },
            new Prodotto { IdProdotto = 6, Nome = "Premiere Adult Dog Food", IdDitta = 2, Tipo = "Alimentare", IdCassetto = 4 },
            new Prodotto { IdProdotto = 7, Nome = "Premiere Kitten Food", IdDitta = 2, Tipo = "Alimentare", IdCassetto = 1 },
            new Prodotto { IdProdotto = 8, Nome = "Premiere Pet Shampoo", IdDitta = 2, Tipo = "Farmaceutico", IdCassetto = 7 },
            new Prodotto { IdProdotto = 9, Nome = "Premiere Senior Dog Food", IdDitta = 2, Tipo = "Alimentare", IdCassetto = 9 },
            new Prodotto { IdProdotto = 10, Nome = "Premiere Puppy Food", IdDitta = 2, Tipo = "Alimentare", IdCassetto = 14 },
            new Prodotto { IdProdotto = 11, Nome = "Royal Canin Gastrointestinal Dog", IdDitta = 3, Tipo = "Alimentare", IdCassetto = 2 },
            new Prodotto { IdProdotto = 12, Nome = "Royal Canin Urinary Cat", IdDitta = 3, Tipo = "Alimentare", IdCassetto = 11 },
            new Prodotto { IdProdotto = 13, Nome = "Royal Canin Hypoallergenic Dog", IdDitta = 3, Tipo = "Alimentare", IdCassetto = 6 },
            new Prodotto { IdProdotto = 14, Nome = "Royal Canin Satiety Cat", IdDitta = 3, Tipo = "Alimentare", IdCassetto = 13 },
            new Prodotto { IdProdotto = 15, Nome = "Royal Canin Renal Dog", IdDitta = 3, Tipo = "Alimentare", IdCassetto = 15 },
            new Prodotto { IdProdotto = 16, Nome = "Hills Science Diet Adult Dog", IdDitta = 4, Tipo = "Alimentare", IdCassetto = 5 },
            new Prodotto { IdProdotto = 17, Nome = "Hills Prescription Diet c/d", IdDitta = 4, Tipo = "Alimentare", IdCassetto = 10 },
            new Prodotto { IdProdotto = 18, Nome = "Hills Ideal Balance Cat", IdDitta = 4, Tipo = "Alimentare", IdCassetto = 3 },
            new Prodotto { IdProdotto = 19, Nome = "Hills Science Diet Kitten", IdDitta = 4, Tipo = "Alimentare", IdCassetto = 7 },
            new Prodotto { IdProdotto = 20, Nome = "Hills Prescription Diet i/d", IdDitta = 4, Tipo = "Alimentare", IdCassetto = 11 },
            new Prodotto { IdProdotto = 21, Nome = "Perfect Fit Adult Cat", IdDitta = 5, Tipo = "Alimentare", IdCassetto = 1 },
            new Prodotto { IdProdotto = 22, Nome = "Perfect Fit Puppy", IdDitta = 5, Tipo = "Alimentare", IdCassetto = 4 },
            new Prodotto { IdProdotto = 23, Nome = "Perfect Fit Senior Dog", IdDitta = 5, Tipo = "Alimentare", IdCassetto = 8 },
            new Prodotto { IdProdotto = 24, Nome = "Perfect Fit In-Home Cat", IdDitta = 5, Tipo = "Alimentare", IdCassetto = 6 },
            new Prodotto { IdProdotto = 25, Nome = "Perfect Fit Sensitive Digestion", IdDitta = 5, Tipo = "Alimentare", IdCassetto = 12 },
            new Prodotto { IdProdotto = 26, Nome = "NBF Lanes Renal N", IdDitta = 6, Tipo = "Farmaceutico", IdCassetto = 2 },
            new Prodotto { IdProdotto = 27, Nome = "NBF Lanes Omega Pet", IdDitta = 6, Tipo = "Farmaceutico", IdCassetto = 9 },
            new Prodotto { IdProdotto = 28, Nome = "NBF Lanes Artikrill", IdDitta = 6, Tipo = "Farmaceutico", IdCassetto = 14 },
            new Prodotto { IdProdotto = 29, Nome = "NBF Lanes Condrostress", IdDitta = 6, Tipo = "Farmaceutico", IdCassetto = 3 },
            new Prodotto { IdProdotto = 30, Nome = "NBF Lanes Epato Plus", IdDitta = 6, Tipo = "Farmaceutico", IdCassetto = 7 },
            new Prodotto { IdProdotto = 31, Nome = "Candioli Florentero", IdDitta = 7, Tipo = "Farmaceutico", IdCassetto = 1 },
            new Prodotto { IdProdotto = 32, Nome = "Candioli Artrovet", IdDitta = 7, Tipo = "Farmaceutico", IdCassetto = 8 },
            new Prodotto { IdProdotto = 33, Nome = "Candioli Stomodine", IdDitta = 7, Tipo = "Farmaceutico", IdCassetto = 13 },
            new Prodotto { IdProdotto = 34, Nome = "Candioli Epato Liquid", IdDitta = 7, Tipo = "Farmaceutico", IdCassetto = 4 },
            new Prodotto { IdProdotto = 35, Nome = "Candioli Calcio Dog", IdDitta = 7, Tipo = "Farmaceutico", IdCassetto = 6 },
            new Prodotto { IdProdotto = 36, Nome = "Vetoquinol Flexadin", IdDitta = 8, Tipo = "Farmaceutico", IdCassetto = 2 },
            new Prodotto { IdProdotto = 37, Nome = "Vetoquinol Zylkene", IdDitta = 8, Tipo = "Farmaceutico", IdCassetto = 11 },
            new Prodotto { IdProdotto = 38, Nome = "Vetoquinol Orozyme", IdDitta = 8, Tipo = "Farmaceutico", IdCassetto = 14 },
            new Prodotto { IdProdotto = 39, Nome = "Vetoquinol Care Senior Dog", IdDitta = 8, Tipo = "Farmaceutico", IdCassetto = 5 },
            new Prodotto { IdProdotto = 40, Nome = "Vetoquinol Samylin", IdDitta = 8, Tipo = "Farmaceutico", IdCassetto = 10 },
            new Prodotto { IdProdotto = 41, Nome = "Bayer Advantix", IdDitta = 9, Tipo = "Farmaceutico", IdCassetto = 3 },
            new Prodotto { IdProdotto = 42, Nome = "Bayer Seresto", IdDitta = 9, Tipo = "Farmaceutico", IdCassetto = 7 },
            new Prodotto { IdProdotto = 43, Nome = "Bayer Drontal", IdDitta = 9, Tipo = "Farmaceutico", IdCassetto = 12 },
            new Prodotto { IdProdotto = 44, Nome = "Bayer Advantage", IdDitta = 9, Tipo = "Farmaceutico", IdCassetto = 15 },
            new Prodotto { IdProdotto = 45, Nome = "Bayer Baytril", IdDitta = 9, Tipo = "Farmaceutico", IdCassetto = 9 },
            new Prodotto { IdProdotto = 46, Nome = "Purina Pro Plan Adult Dog", IdDitta = 10, Tipo = "Alimentare", IdCassetto = 2 },
            new Prodotto { IdProdotto = 47, Nome = "Purina ONE Kitten", IdDitta = 10, Tipo = "Alimentare", IdCassetto = 11 },
            new Prodotto { IdProdotto = 48, Nome = "Purina Dentalife", IdDitta = 10, Tipo = "Alimentare", IdCassetto = 5 },
            new Prodotto { IdProdotto = 49, Nome = "Purina Pro Plan Veterinary Diets EN", IdDitta = 10, Tipo = "Alimentare", IdCassetto = 7 },
            new Prodotto { IdProdotto = 50, Nome = "Purina ONE Senior Cat", IdDitta = 10, Tipo = "Alimentare", IdCassetto = 14 },
            new Prodotto { IdProdotto = 51, Nome = "Frontline Combo", IdDitta = 11, Tipo = "Farmaceutico", IdCassetto = 4 },
            new Prodotto { IdProdotto = 52, Nome = "Frontline Tri-Act", IdDitta = 11, Tipo = "Farmaceutico", IdCassetto = 8 },
            new Prodotto { IdProdotto = 53, Nome = "Frontline Spray", IdDitta = 11, Tipo = "Farmaceutico", IdCassetto = 13 },
            new Prodotto { IdProdotto = 54, Nome = "Frontline Spot On Cat", IdDitta = 11, Tipo = "Farmaceutico", IdCassetto = 10 },
            new Prodotto { IdProdotto = 55, Nome = "Frontline Spot On Dog", IdDitta = 11, Tipo = "Farmaceutico", IdCassetto = 3 }
        );


    }

}
}
