using Microsoft.EntityFrameworkCore;
using Tenanpp.DAL.Models;
namespace Tenanpp.DAL
{
    public class TenanppContext : DbContext
    {
        public TenanppContext (DbContextOptions<TenanppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RankingGeneral>(rg => {
                rg.HasNoKey(); 
                rg.ToView("RankingGeneral");
            });

            modelBuilder.Entity<RankingConductaEtica>(rg => {
                rg.HasNoKey(); 
                rg.ToView("RankingConductaEtica");
            });

            modelBuilder.Entity<RankingResponsabilidad>(rg => {
                rg.HasNoKey(); 
                rg.ToView("RankingResponsabilidad");
            });

            modelBuilder.Entity<RankingAtencion>(rg => {
                rg.HasNoKey(); 
                rg.ToView("RankingAtencion");
            });
        }

        public DbSet<Inmobiliaria> Inmobiliarias { get; set; }
        public DbSet<OpinionInmobiliaria> OpinionesInmobiliarias { get; set; }
        public DbSet<FotoPerfil> FotosPerfil { get; set; }
        public DbSet<EstadisticasInmobiliaria> EstadisticasInmobiliaria { get; set; }
        public DbSet<RankingGeneral> RankingGeneral{get;set;}
        public DbSet<RankingConductaEtica> RankingConductaEtica{get;set;}
        public DbSet<RankingResponsabilidad> RankingResponsabilidad{get;set;}
        public DbSet<RankingAtencion> RankingAtencion{get;set;}
        public DbSet<Lugar> Lugares{get;set;}
        public DbSet<OpinionLugar> OpinionesLugares { get; set; }
    }
}