using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_app.Migrations
{
    public partial class SeedInmobiliarias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inmobiliarias",
                columns: new[] { "InmobiliariaId", "Cuit", "Direccion", "Localidad", "Nombre", "Telefono", "Url" },
                values: new object[] { 1L, "30-5212367-12", "Directorio 3456", "Capital Federal", "Lepore", "011 44339820", "https://www.lepore.com.ar" });

            migrationBuilder.InsertData(
                table: "Inmobiliarias",
                columns: new[] { "InmobiliariaId", "Cuit", "Direccion", "Localidad", "Nombre", "Telefono", "Url" },
                values: new object[] { 2L, "30-278901500-33", "Rivadavia 9876", "Capital Federal", "Juan Propiedades", "011 4468 9320", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inmobiliarias",
                keyColumn: "InmobiliariaId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Inmobiliarias",
                keyColumn: "InmobiliariaId",
                keyValue: 2L);
        }
    }
}
