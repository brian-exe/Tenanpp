﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tenanpp.Repository;

namespace dotnet_app.Migrations
{
    [DbContext(typeof(TenanppContext))]
    [Migration("20200518031831_Adding-ValoracionesInmobiliarias")]
    partial class AddingValoracionesInmobiliarias
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tenanpp.Repository.Models.Inmobiliaria", b =>
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

                    b.Property<string>("PathFoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inmobiliarias");
                });

            modelBuilder.Entity("Tenanpp.Repository.Models.OpinionInmobiliaria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AceptaPagoElectronico")
                        .HasColumnType("bit");

                    b.Property<string>("ComentarioNegativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComentarioPositivo")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

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

            modelBuilder.Entity("Tenanpp.Repository.Models.ValoracionInmobiliaria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("InmobiliariaId")
                        .HasColumnType("bigint");

                    b.Property<float>("ValoracionAtencion")
                        .HasColumnType("real");

                    b.Property<float>("ValoracionConductaEtica")
                        .HasColumnType("real");

                    b.Property<float>("ValoracionResponsabilidad")
                        .HasColumnType("real");

                    b.Property<float>("VotosAceptaPagoElectronico")
                        .HasColumnType("real");

                    b.Property<float>("VotosNoAceptaPagoElectronico")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("InmobiliariaId");

                    b.ToTable("ValoracionesInmobiliarias");
                });

            modelBuilder.Entity("Tenanpp.Repository.Models.OpinionInmobiliaria", b =>
                {
                    b.HasOne("Tenanpp.Repository.Models.Inmobiliaria", "Inmobiliaria")
                        .WithMany()
                        .HasForeignKey("InmobiliariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tenanpp.Repository.Models.ValoracionInmobiliaria", b =>
                {
                    b.HasOne("Tenanpp.Repository.Models.Inmobiliaria", "Inmobiliaria")
                        .WithMany()
                        .HasForeignKey("InmobiliariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
