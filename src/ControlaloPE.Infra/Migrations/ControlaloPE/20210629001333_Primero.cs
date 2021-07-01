using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlaloPE.Infra.Migrations.ControlaloPE
{
    public partial class Primero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(50)", nullable: true),
                    ApellidoPaterno = table.Column<string>(type: "Varchar(50)", nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "Varchar(50)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id_Persona);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id_Empresa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Persona = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "Varchar(50)", nullable: true),
                    Logo = table.Column<string>(type: "NVarchar(250)", nullable: true),
                    Ruc = table.Column<string>(type: "NVarchar(20)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id_Empresa);
                    table.ForeignKey(
                        name: "FK_Empresas_Personas_Id_Persona",
                        column: x => x.Id_Persona,
                        principalTable: "Personas",
                        principalColumn: "Id_Persona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Id_Persona",
                table: "Empresas",
                column: "Id_Persona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
