using Microsoft.EntityFrameworkCore;
using Tenanpp.Repository.Models;
namespace Tenanpp.Repository
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
    }
}