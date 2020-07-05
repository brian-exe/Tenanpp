using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class FotosPerfil_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathFoto",
                table: "Inmobiliarias");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotosPerfil");

            migrationBuilder.AddColumn<string>(
                name: "PathFoto",
                table: "Inmobiliarias",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
