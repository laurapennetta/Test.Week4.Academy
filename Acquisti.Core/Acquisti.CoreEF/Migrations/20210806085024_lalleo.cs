using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acquisti.CoreEF.Migrations
{
    public partial class lalleo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceCliente = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOrdine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodiceOrdine = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CodiceProdotto = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Importo = table.Column<double>(type: "float", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ordini_Clienti_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clienti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_ClienteID",
                table: "Ordini",
                column: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
