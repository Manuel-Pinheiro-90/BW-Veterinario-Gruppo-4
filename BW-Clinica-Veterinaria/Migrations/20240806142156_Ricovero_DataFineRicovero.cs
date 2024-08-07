using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BW_Clinica_Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class Ricovero_DataFineRicovero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFineRicovero",
                table: "Ricoveri",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFineRicovero",
                table: "Ricoveri");
        }
    }
}
