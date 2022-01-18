using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Week8.RepositoryEntityFramework.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corso",
                columns: table => new
                {
                    CodiceCorso = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corso", x => x.CodiceCorso);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDiTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceCorso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorsoCodiceCorso = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Docente_Corso_CorsoCodiceCorso",
                        column: x => x.CorsoCodiceCorso,
                        principalTable: "Corso",
                        principalColumn: "CodiceCorso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDiNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TitoloDiStudio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceCorso = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Codice Corso",
                        column: x => x.CodiceCorso,
                        principalTable: "Corso",
                        principalColumn: "CodiceCorso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lezione",
                columns: table => new
                {
                    LezioneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Aula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    CodiceCorso = table.Column<int>(type: "int", nullable: false),
                    CorsoCodiceCorso = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezione", x => x.LezioneID);
                    table.ForeignKey(
                        name: "FK_Docente ID",
                        column: x => x.DocenteId,
                        principalTable: "Docente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lezione_Corso_CorsoCodiceCorso",
                        column: x => x.CorsoCodiceCorso,
                        principalTable: "Corso",
                        principalColumn: "CodiceCorso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docente_CorsoCodiceCorso",
                table: "Docente",
                column: "CorsoCodiceCorso");

            migrationBuilder.CreateIndex(
                name: "IX_Lezione_CorsoCodiceCorso",
                table: "Lezione",
                column: "CorsoCodiceCorso");

            migrationBuilder.CreateIndex(
                name: "IX_Lezione_DocenteId",
                table: "Lezione",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Studente_CodiceCorso",
                table: "Studente",
                column: "CodiceCorso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezione");

            migrationBuilder.DropTable(
                name: "Studente");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Corso");
        }
    }
}
