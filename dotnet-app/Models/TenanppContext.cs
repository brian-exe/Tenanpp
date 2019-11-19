using Microsoft.EntityFrameworkCore;

namespace Tenanpp.Models
{
    public class TenanppContext : DbContext
    {
        public TenanppContext (DbContextOptions<TenanppContext> options)
            : base(options)
        {
        }

        public DbSet<Inmobiliaria> Inmobiliarias { get; set; }
    }
}