﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Tenanpp.DAL;

namespace dotnet_app.Migrations
{
    [DbContext(typeof(TenanppContext))]
    [Migration("20200812041155_Lugares_Opiniones_Added")]
    partial class Lugares_Opiniones_Added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tenanpp.DAL.Models.EstadisticasInmobiliaria", b =>
                {
                    b.Property<long>("InmobiliariaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("PromedioAtencion")
                        .HasColumnType("float");

                    b.Property<double>("PromedioConductaEtica")
                        .HasColumnType("float");

                    b.Property<double>("PromedioResponsabilidad")
                        .HasColumnType("float");

                    b.Property<int>("VotosNoPagoElectronico")
                        .HasColumnType("int");

                    b.Property<int>("VotosPagoElectronico")
                        .HasColumnType("int");

                    b.HasKey("InmobiliariaId");

                    b.ToTable("EstadisticasInmobiliaria");
                });

            modelBuilder.Entity("Tenanpp.DAL.Models.FotoPerfil", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("InmobiliariaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FotosPerfil");
                });

            modelBuilder.Entity("Tenanpp.DAL.Models.Inmobiliaria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cuit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inmobiliarias");
                });

            modelBuilder.Entity("Tenanpp.DAL.Models.Lugar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Point>("Location")
                        .HasColumnType("geometry");

                    b.HasKey("Id");

                    b.ToTable("Lugares");
                });

            modelBuilder.Entity("Tenanpp.DAL.Models.OpinionInmobiliaria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AceptaPagoElectronico")
                        .HasColumnType("bit");

                    b.Property<string>("ComentarioNegativo")
                        .HasColumnType("nvarchar(1200)")
                        .HasMaxLength(1200);

                    b.Property<string>("ComentarioPositivo")
                        .HasColumnType("nvarchar(1200)")
                        .HasMaxLength(1200);

                    b.Property<DateTime>("FechaOpinion")
                        .HasColumnType("datetime2");

                    b.Property<long>("InmobiliariaId")
                        .HasColumnType("bigint");

                    b.Property<string>("IpOrigen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValoracionAtencion")
                        .HasColumnType("int");

                    b.Property<int>("ValoracionConductaEtica")
                        .HasColumnType("int");

                    b.Property<int>("ValoracionResponsabilidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InmobiliariaId");

                    b.ToTable("OpinionesInmobiliarias");
                });

            modelBuilder.Entity("Tenanpp.DAL.Models.OpinionLugar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LugarId")
                        .HasColumnType("bigint");

                    b.Property<string>("Pros")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecomiendaLugar")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("OpinionesLugares");
                });

            modelBuilder.Entity("Tenanpp.DAL.Models.OpinionInmobiliaria", b =>
                {
                    b.HasOne("Tenanpp.DAL.Models.Inmobiliaria", "Inmobiliaria")
                        .WithMany()
                        .HasForeignKey("InmobiliariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
