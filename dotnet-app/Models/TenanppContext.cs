using Microsoft.EntityFrameworkCore;

namespace Tenanpp.Models
{
    public class TenanppContext : DbContext
    {
        public TenanppContext (DbContextOptions<TenanppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inmobiliaria>().HasData(new Inmobiliaria
            {
                InmobiliariaId= 1,
                Nombre = "Lepore",
                Direccion = "Directorio 3456",
                Telefono = "011 44339820",
                Localidad = "Capital Federal",
                Cuit = "30-5212367-12",
                Url="https://www.lepore.com.ar"
 
            }, new Inmobiliaria
            {
                InmobiliariaId= 2,
                Nombre = "Juan Propiedades",
                Direccion = "Rivadavia 9876",
                Telefono = "011 4468 9320",
                Localidad = "Capital Federal",
                Cuit = "30-278901500-33",
                Url=""
            });
        }

        public DbSet<Inmobiliaria> Inmobiliarias { get; set; }
    }
}