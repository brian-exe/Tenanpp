﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace dotnet_app.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadisticasInmobiliaria",
                columns: table => new
                {
                    InmobiliariaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromedioAtencion = table.Column<double>(nullable: false),
                    PromedioResponsabilidad = table.Column<double>(nullable: false),
                    PromedioConductaEtica = table.Column<double>(nullable: false),
                    VotosPagoElectronico = table.Column<int>(nullable: false),
                    VotosNoPagoElectronico = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadisticasInmobiliaria", x => x.InmobiliariaId);
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
                    table.ForeignKey(
                        name: "FK_FotosPerfil_Inmobiliarias_InmobiliariaId",
                        column: x => x.InmobiliariaId,
                        principalTable: "Inmobiliarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_OpinionesLugares_Lugares_LugarId",
                        column: x => x.LugarId,
                        principalTable: "Lugares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotosPerfil_InmobiliariaId",
                table: "FotosPerfil",
                column: "InmobiliariaId");

            migrationBuilder.CreateIndex(
                name: "IX_OpinionesInmobiliarias_InmobiliariaId",
                table: "OpinionesInmobiliarias",
                column: "InmobiliariaId");

            migrationBuilder.CreateIndex(
                name: "IX_OpinionesLugares_LugarId",
                table: "OpinionesLugares",
                column: "LugarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstadisticasInmobiliaria");

            migrationBuilder.DropTable(
                name: "FotosPerfil");

            migrationBuilder.DropTable(
                name: "OpinionesInmobiliarias");

            migrationBuilder.DropTable(
                name: "OpinionesLugares");

            migrationBuilder.DropTable(
                name: "Inmobiliarias");

            migrationBuilder.DropTable(
                name: "Lugares");
        }
    }
}
