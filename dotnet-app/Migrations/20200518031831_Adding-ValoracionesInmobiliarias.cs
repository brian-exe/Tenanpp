using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class AddingValoracionesInmobiliarias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValoracionesInmobiliarias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InmobiliariaId = table.Column<long>(nullable: false),
                    ValoracionResponsabilidad = table.Column<float>(nullable: false),
                    ValoracionAtencion = table.Column<float>(nullable: false),
                    ValoracionConductaEtica = table.Column<float>(nullable: false),
                    VotosAceptaPagoElectronico = table.Column<float>(nullable: false),
                    VotosNoAceptaPagoElectronico = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoracionesInmobiliarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValoracionesInmobiliarias_Inmobiliarias_InmobiliariaId",
                        column: x => x.InmobiliariaId,
                        principalTable: "Inmobiliarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValoracionesInmobiliarias_InmobiliariaId",
                table: "ValoracionesInmobiliarias",
                column: "InmobiliariaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValoracionesInmobiliarias");
        }
    }
}
