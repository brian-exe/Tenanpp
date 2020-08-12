using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace dotnet_app.Migrations
{
    public partial class Lugares_Opiniones_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lugares",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(nullable: true),
                    Location = table.Column<Point>(type: "geometry", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpinionesLugares",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LugarId = table.Column<long>(nullable: false),
                    RecomiendaLugar = table.Column<bool>(nullable: false),
                    Pros = table.Column<string>(nullable: true),
                    Contras = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpinionesLugares", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lugares");

            migrationBuilder.DropTable(
                name: "OpinionesLugares");
        }
    }
}
