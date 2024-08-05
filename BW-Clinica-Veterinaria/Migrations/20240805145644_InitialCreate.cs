using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BW_Clinica_Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cassetti",
                columns: table => new
                {
                    IdCassetto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCassetto = table.Column<int>(type: "int", nullable: false),
                    NumeroArmadietto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassetti", x => x.IdCassetto);
                });

            migrationBuilder.CreateTable(
                name: "Ditte",
                columns: table => new
                {
                    IdDitta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recapito = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ditte", x => x.IdDitta);
                });

            migrationBuilder.CreateTable(
                name: "Proprietari",
                columns: table => new
                {
                    CodiceFiscale = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietari", x => x.CodiceFiscale);
                });

            migrationBuilder.CreateTable(
                name: "Ruoli",
                columns: table => new
                {
                    IdRuolo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruoli", x => x.IdRuolo);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    IdUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.IdUtente);
                });

            migrationBuilder.CreateTable(
                name: "Utilizzi",
                columns: table => new
                {
                    IdUtilizzo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizzi", x => x.IdUtilizzo);
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    IdProdotto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDitta = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCassetto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.IdProdotto);
                    table.ForeignKey(
                        name: "FK_Prodotti_Cassetti_IdCassetto",
                        column: x => x.IdCassetto,
                        principalTable: "Cassetti",
                        principalColumn: "IdCassetto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prodotti_Ditte_IdDitta",
                        column: x => x.IdDitta,
                        principalTable: "Ditte",
                        principalColumn: "IdDitta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animali",
                columns: table => new
                {
                    IdAnimale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipologia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MicroChipCodice = table.Column<string>(type: "varchar(15)", nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRegistrazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodiceFiscaleProprietario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animali", x => x.IdAnimale);
                    table.ForeignKey(
                        name: "FK_Animali_Proprietari_CodiceFiscaleProprietario",
                        column: x => x.CodiceFiscaleProprietario,
                        principalTable: "Proprietari",
                        principalColumn: "CodiceFiscale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtenteRuolo",
                columns: table => new
                {
                    RuoliIdRuolo = table.Column<int>(type: "int", nullable: false),
                    UtentiIdUtente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtenteRuolo", x => new { x.RuoliIdRuolo, x.UtentiIdUtente });
                    table.ForeignKey(
                        name: "FK_UtenteRuolo_Ruoli_RuoliIdRuolo",
                        column: x => x.RuoliIdRuolo,
                        principalTable: "Ruoli",
                        principalColumn: "IdRuolo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtenteRuolo_Utenti_UtentiIdUtente",
                        column: x => x.UtentiIdUtente,
                        principalTable: "Utenti",
                        principalColumn: "IdUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdottoUtilizzo",
                columns: table => new
                {
                    ProdottiIdProdotto = table.Column<int>(type: "int", nullable: false),
                    UtilizziIdUtilizzo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdottoUtilizzo", x => new { x.ProdottiIdProdotto, x.UtilizziIdUtilizzo });
                    table.ForeignKey(
                        name: "FK_ProdottoUtilizzo_Prodotti_ProdottiIdProdotto",
                        column: x => x.ProdottiIdProdotto,
                        principalTable: "Prodotti",
                        principalColumn: "IdProdotto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdottoUtilizzo_Utilizzi_UtilizziIdUtilizzo",
                        column: x => x.UtilizziIdUtilizzo,
                        principalTable: "Utilizzi",
                        principalColumn: "IdUtilizzo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendite",
                columns: table => new
                {
                    IdVendita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceFiscaleCliente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdProdotto = table.Column<int>(type: "int", nullable: false),
                    Ricetta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendite", x => x.IdVendita);
                    table.ForeignKey(
                        name: "FK_Vendite_Prodotti_IdProdotto",
                        column: x => x.IdProdotto,
                        principalTable: "Prodotti",
                        principalColumn: "IdProdotto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendite_Proprietari_CodiceFiscaleCliente",
                        column: x => x.CodiceFiscaleCliente,
                        principalTable: "Proprietari",
                        principalColumn: "CodiceFiscale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ricoveri",
                columns: table => new
                {
                    IdRicovero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRicovero = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAnimale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ricoveri", x => x.IdRicovero);
                    table.ForeignKey(
                        name: "FK_Ricoveri_Animali_IdAnimale",
                        column: x => x.IdAnimale,
                        principalTable: "Animali",
                        principalColumn: "IdAnimale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visite",
                columns: table => new
                {
                    IdVista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnimale = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Esame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuraPrescritta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visite", x => x.IdVista);
                    table.ForeignKey(
                        name: "FK_Visite_Animali_IdAnimale",
                        column: x => x.IdAnimale,
                        principalTable: "Animali",
                        principalColumn: "IdAnimale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animali_CodiceFiscaleProprietario",
                table: "Animali",
                column: "CodiceFiscaleProprietario");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_IdCassetto",
                table: "Prodotti",
                column: "IdCassetto");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_IdDitta",
                table: "Prodotti",
                column: "IdDitta");

            migrationBuilder.CreateIndex(
                name: "IX_ProdottoUtilizzo_UtilizziIdUtilizzo",
                table: "ProdottoUtilizzo",
                column: "UtilizziIdUtilizzo");

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_IdAnimale",
                table: "Ricoveri",
                column: "IdAnimale");

            migrationBuilder.CreateIndex(
                name: "IX_UtenteRuolo_UtentiIdUtente",
                table: "UtenteRuolo",
                column: "UtentiIdUtente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_CodiceFiscaleCliente",
                table: "Vendite",
                column: "CodiceFiscaleCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_IdProdotto",
                table: "Vendite",
                column: "IdProdotto");

            migrationBuilder.CreateIndex(
                name: "IX_Visite_IdAnimale",
                table: "Visite",
                column: "IdAnimale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdottoUtilizzo");

            migrationBuilder.DropTable(
                name: "Ricoveri");

            migrationBuilder.DropTable(
                name: "UtenteRuolo");

            migrationBuilder.DropTable(
                name: "Vendite");

            migrationBuilder.DropTable(
                name: "Visite");

            migrationBuilder.DropTable(
                name: "Utilizzi");

            migrationBuilder.DropTable(
                name: "Ruoli");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Animali");

            migrationBuilder.DropTable(
                name: "Cassetti");

            migrationBuilder.DropTable(
                name: "Ditte");

            migrationBuilder.DropTable(
                name: "Proprietari");
        }
    }
}
