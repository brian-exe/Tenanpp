using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class OpinionInmobiliariaCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpinionesInmobiliarias",
                columns: table => new
                {
                    OpinionInmobiliariaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InmobiliariaId = table.Column<long>(nullable: false),
                    Valoracion = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 500, nullable: true),
                    FechaOpinion = table.Column<DateTime>(nullable: false),
                    IpOrigen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpinionesInmobiliarias", x => x.OpinionInmobiliariaId);
                    table.ForeignKey(
                        name: "FK_OpinionesInmobiliarias_Inmobiliarias_InmobiliariaId",
                        column: x => x.InmobiliariaId,
                        principalTable: "Inmobiliarias",
                        principalColumn: "InmobiliariaId",
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
                name: "OpinionesInmobiliarias");
        }
    }
}
