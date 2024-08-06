using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BW_Clinica_Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class PopolazioneTabelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cassetti",
                columns: new[] { "IdCassetto", "NumeroArmadietto", "NumeroCassetto" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 2, 1 },
                    { 7, 2, 2 },
                    { 8, 2, 3 },
                    { 9, 2, 4 },
                    { 10, 2, 5 },
                    { 11, 3, 1 },
                    { 12, 3, 2 },
                    { 13, 3, 3 },
                    { 14, 3, 4 },
                    { 15, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Ditte",
                columns: new[] { "IdDitta", "Indirizzo", "Nome", "Recapito" },
                values: new object[,]
                {
                    { 1, "Via Roma, 123, 00100 Roma", "Next", "+39 331 1234567" },
                    { 2, "Corso Italia, 50, 20100 Milano", "Premiere", "+39 332 2345678" },
                    { 3, "Via della Salute, 15, 10100 Torino", "Royal Canin", "+39 333 3456789" },
                    { 4, "Piazza Duomo, 1, 80100 Napoli", "Hills", "+39 334 4567890" },
                    { 5, "Viale Mazzini, 20, 40100 Bologna", "Perfect", "+39 335 5678901" },
                    { 6, "Via Garibaldi, 45, 70100 Bari", "NBF Lanes", "+39 336 6789012" },
                    { 7, "Piazza della Libertà, 10, 50100 Firenze", "Candioli", "+39 337 7890123" },
                    { 8, "Corso Vittorio Emanuele, 25, 35100 Padova", "Vetoquinol", "+39 338 8901234" },
                    { 9, "Via Veneto, 2, 10100 Torino", "Bayer", "+39 339 9012345" },
                    { 10, "Viale dei Mille, 30, 80100 Napoli", "Purina", "+39 330 0123456" },
                    { 11, "Via Dante, 15, 90100 Palermo", "Frontline", "+39 331 1234567" }
                });

            migrationBuilder.InsertData(
                table: "Utilizzi",
                columns: new[] { "IdUtilizzo", "Descrizione" },
                values: new object[,]
                {
                    { 1, "Otite" },
                    { 2, "Raffreddore" },
                    { 3, "Dermatite" },
                    { 4, "Intestinale" },
                    { 5, "Supporto immunitario" },
                    { 6, "Convalescenza" },
                    { 7, "Gravidanza e allattamento" },
                    { 8, "Boli di pelo" },
                    { 9, "Vermi" },
                    { 10, "Funghi" },
                    { 11, "Antibiotico" },
                    { 12, "Antivirale" },
                    { 13, "Cura orale" },
                    { 14, "Urinario" },
                    { 15, "Cardiaco" },
                    { 16, "Energetico" },
                    { 17, "Mobilità" },
                    { 18, "Vista" },
                    { 19, "Neurologico" },
                    { 20, "Calmante" },
                    { 21, "Epatite" },
                    { 22, "Controllo del peso" },
                    { 23, "Cibo Secco" },
                    { 24, "Cibo umido" },
                    { 25, "Snack" },
                    { 26, "Inappetenza" },
                    { 27, "Kitten" },
                    { 28, "Puppy" },
                    { 29, "Reni" }
                });

            migrationBuilder.InsertData(
                table: "Prodotti",
                columns: new[] { "IdProdotto", "IdCassetto", "IdDitta", "Nome", "Tipo" },
                values: new object[,]
                {
                    { 1, 3, 1, "Next Dry Food Adult Dog", "Alimentare" },
                    { 2, 5, 1, "Next Wet Food Kitten", "Alimentare" },
                    { 3, 8, 1, "Next Treats Dental", "Alimentare" },
                    { 4, 12, 1, "Next Senior Cat Food", "Alimentare" },
                    { 5, 10, 1, "Next Puppy Food", "Alimentare" },
                    { 6, 4, 2, "Premiere Adult Dog Food", "Alimentare" },
                    { 7, 1, 2, "Premiere Kitten Food", "Alimentare" },
                    { 8, 7, 2, "Premiere Pet Shampoo", "Farmaceutico" },
                    { 9, 9, 2, "Premiere Senior Dog Food", "Alimentare" },
                    { 10, 14, 2, "Premiere Puppy Food", "Alimentare" },
                    { 11, 2, 3, "Royal Canin Gastrointestinal Dog", "Alimentare" },
                    { 12, 11, 3, "Royal Canin Urinary Cat", "Alimentare" },
                    { 13, 6, 3, "Royal Canin Hypoallergenic Dog", "Alimentare" },
                    { 14, 13, 3, "Royal Canin Satiety Cat", "Alimentare" },
                    { 15, 15, 3, "Royal Canin Renal Dog", "Alimentare" },
                    { 16, 5, 4, "Hills Science Diet Adult Dog", "Alimentare" },
                    { 17, 10, 4, "Hills Prescription Diet c/d", "Alimentare" },
                    { 18, 3, 4, "Hills Ideal Balance Cat", "Alimentare" },
                    { 19, 7, 4, "Hills Science Diet Kitten", "Alimentare" },
                    { 20, 11, 4, "Hills Prescription Diet i/d", "Alimentare" },
                    { 21, 1, 5, "Perfect Fit Adult Cat", "Alimentare" },
                    { 22, 4, 5, "Perfect Fit Puppy", "Alimentare" },
                    { 23, 8, 5, "Perfect Fit Senior Dog", "Alimentare" },
                    { 24, 6, 5, "Perfect Fit In-Home Cat", "Alimentare" },
                    { 25, 12, 5, "Perfect Fit Sensitive Digestion", "Alimentare" },
                    { 26, 2, 6, "NBF Lanes Renal N", "Farmaceutico" },
                    { 27, 9, 6, "NBF Lanes Omega Pet", "Farmaceutico" },
                    { 28, 14, 6, "NBF Lanes Artikrill", "Farmaceutico" },
                    { 29, 3, 6, "NBF Lanes Condrostress", "Farmaceutico" },
                    { 30, 7, 6, "NBF Lanes Epato Plus", "Farmaceutico" },
                    { 31, 1, 7, "Candioli Florentero", "Farmaceutico" },
                    { 32, 8, 7, "Candioli Artrovet", "Farmaceutico" },
                    { 33, 13, 7, "Candioli Stomodine", "Farmaceutico" },
                    { 34, 4, 7, "Candioli Epato Liquid", "Farmaceutico" },
                    { 35, 6, 7, "Candioli Calcio Dog", "Farmaceutico" },
                    { 36, 2, 8, "Vetoquinol Flexadin", "Farmaceutico" },
                    { 37, 11, 8, "Vetoquinol Zylkene", "Farmaceutico" },
                    { 38, 14, 8, "Vetoquinol Orozyme", "Farmaceutico" },
                    { 39, 5, 8, "Vetoquinol Care Senior Dog", "Farmaceutico" },
                    { 40, 10, 8, "Vetoquinol Samylin", "Farmaceutico" },
                    { 41, 3, 9, "Bayer Advantix", "Farmaceutico" },
                    { 42, 7, 9, "Bayer Seresto", "Farmaceutico" },
                    { 43, 12, 9, "Bayer Drontal", "Farmaceutico" },
                    { 44, 15, 9, "Bayer Advantage", "Farmaceutico" },
                    { 45, 9, 9, "Bayer Baytril", "Farmaceutico" },
                    { 46, 2, 10, "Purina Pro Plan Adult Dog", "Alimentare" },
                    { 47, 11, 10, "Purina ONE Kitten", "Alimentare" },
                    { 48, 5, 10, "Purina Dentalife", "Alimentare" },
                    { 49, 7, 10, "Purina Pro Plan Veterinary Diets EN", "Alimentare" },
                    { 50, 14, 10, "Purina ONE Senior Cat", "Alimentare" },
                    { 51, 4, 11, "Frontline Combo", "Farmaceutico" },
                    { 52, 8, 11, "Frontline Tri-Act", "Farmaceutico" },
                    { 53, 13, 11, "Frontline Spray", "Farmaceutico" },
                    { 54, 10, 11, "Frontline Spot On Cat", "Farmaceutico" },
                    { 55, 3, 11, "Frontline Spot On Dog", "Farmaceutico" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Prodotti",
                keyColumn: "IdProdotto",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Utilizzi",
                keyColumn: "IdUtilizzo",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cassetti",
                keyColumn: "IdCassetto",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ditte",
                keyColumn: "IdDitta",
                keyValue: 11);
        }
    }
}
