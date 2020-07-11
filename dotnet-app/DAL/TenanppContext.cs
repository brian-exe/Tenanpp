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
        }

        public DbSet<Inmobiliaria> Inmobiliarias { get; set; }
        public DbSet<OpinionInmobiliaria> OpinionesInmobiliarias { get; set; }
        public DbSet<ValoracionInmobiliaria> ValoracionesInmobiliarias { get; set; }
        public DbSet<FotoPerfil> FotosPerfil { get; set; }
    }
}