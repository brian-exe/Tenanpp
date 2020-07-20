using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FotosPerfil",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InmobiliariaId = table.Column<long>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosPerfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inmobiliarias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    Cuit = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmobiliarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpinionesInmobiliarias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InmobiliariaId = table.Column<long>(nullable: false),
                    ValoracionAtencion = table.Column<int>(nullable: false),
                    ValoracionResponsabilidad = table.Column<int>(nullable: false),
                    ValoracionConductaEtica = table.Column<int>(nullable: false),
                    ComentarioPositivo = table.Column<string>(maxLength: 1200, nullable: true),
                    ComentarioNegativo = table.Column<string>(maxLength: 1200, nullable: true),
                    AceptaPagoElectronico = table.Column<bool>(nullable: false),
                    FechaOpinion = table.Column<DateTime>(nullable: false),
                    IpOrigen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpinionesInmobiliarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpinionesInmobiliarias_Inmobiliarias_InmobiliariaId",
                        column: x => x.InmobiliariaId,
                        principalTable: "Inmobiliarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpinionesInmobiliarias_InmobiliariaId",
                table: "OpinionesInmobiliarias",
                column: "InmobiliariaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotosPerfil");

            migrationBuilder.DropTable(
                name: "OpinionesInmobiliarias");

            migrationBuilder.DropTable(
                name: "Inmobiliarias");
        }
    }
}
