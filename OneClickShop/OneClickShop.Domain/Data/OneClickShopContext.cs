using Microsoft.EntityFrameworkCore;
using OneClickShop.Domain.Entities;

namespace OneClickShop.Domain.Data
{
    public class OneClickSContext : DbContext
    {
        public OneClickSContext(DbContextOptions<OneClickSContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos iniciales
            modelBuilder.Entity<Producto>().HasData(
                new Producto 
                { Id = 1, Nombre = "Iphone 12 Pro Max", Descripcion = "Teléfono inteligente de gama alta lanzado por Apple en octubre de 2020. Destaca por su pantalla Super Retina XDR de 6.7 pulgadas y el chip A14 Bionic", Precio = 32000, Stock = 40 },

                new Producto 
                { Id = 2, Nombre = "MacBook Air 2020", Descripcion = " portátil ligero y eficiente con pantalla Retina, teclado Magic Keyboard y procesadores Intel de 10ª generación, ideal para productividad y uso diario.", Precio = 40000, Stock = 12 },

                new Producto
                { Id = 3, Nombre = "iMac Pro 2019", Descripcion = " potente estación de trabajo todo en uno diseñada para profesionales, con hardware de alto rendimiento y una pantalla Retina 5K.", Precio = 300000, Stock = 7},

                new Producto
                { Id = 4, Nombre = "MacBook Pro 16", Descripcion = "Laptop premium con pantalla Retina, procesador M1 Pro/Max y diseño compacto para creativos y profesionales.", Precio = 55000, Stock = 21 },

                new Producto
                { Id = 5, Nombre = "iPhone 13 Pro", Descripcion = "Smartphone avanzado con pantalla Super Retina XDR, cámara triple y rendimiento optimizado con el chip A15 Bionic.", Precio = 30000, Stock = 200 },

                new Producto
                { Id = 6, Nombre = "iPad Air 2022", Descripcion = "Tablet versátil con pantalla Liquid Retina, chip M1 y compatibilidad con Apple Pencil y Magic Keyboard.", Precio = 80000, Stock = 12 },

                new Producto
                { Id = 7, Nombre = "Apple Watch Series 8", Descripcion = "Reloj inteligente con monitorización avanzada de salud, pantalla Always-On y resistencia al agua.", Precio = 50000, Stock = 55}

            );
        }
    }
}
