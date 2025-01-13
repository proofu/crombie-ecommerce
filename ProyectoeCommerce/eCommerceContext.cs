using Microsoft.EntityFrameworkCore;
using ProyectoeCommerce.Models.Entity;
using System;

namespace ProyectoeCommerce
{
    public class eCommerceContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistProducto> WishlistProductos { get; set; }

        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(p =>
            {
                p.HasKey(p => p.Id);
                p.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                p.Property(p => p.Descripcion).HasMaxLength(500);
                p.Property(p => p.Precio).IsRequired();
            });

            modelBuilder.Entity<Usuario>(u =>
            {
                u.HasKey(u => u.Id);
                u.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
                u.Property(u => u.Email).HasMaxLength(100);
                u.Property(u => u.NumeroTelefono).HasMaxLength(20);
                u.Property(u => u.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<Wishlist>(w =>
            {
                w.HasKey(w => w.Id);
                w.Property(w => w.Nombre).IsRequired().HasMaxLength(100);

                w.HasOne(w => w.Usuario)
                 .WithMany(u => u.Wishlists)
                 .HasForeignKey(w => w.UsuarioId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<WishlistProducto>(wp =>
            {
                wp.HasKey(wp => new { wp.ProductoId, wp.WishlistId });

                wp.HasOne(wp => wp.Producto)
                  .WithMany()
                  .HasForeignKey(wp => wp.ProductoId)
                  .OnDelete(DeleteBehavior.Cascade);

                wp.HasOne(wp => wp.Wishlist)
                  .WithMany(w => w.WishlistProductos)
                  .HasForeignKey(wp => wp.WishlistId)
                  .OnDelete(DeleteBehavior.Cascade);

                wp.Property(wp => wp.Nombre).IsRequired().HasMaxLength(100);
                wp.Property(wp => wp.FechaCreacion).IsRequired().HasDefaultValueSql("GETDATE()");
                wp.Property(wp => wp.FechaProductoAgregado).IsRequired();
            });


            // Datos Iniciales
            modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Nombre = "John Doe",
                Email = "john.doe@example.com",
                NumeroTelefono = "1234567890",
                Password = "hashed_password_1", // Replace with hashed values if using hashing        Role = "Admin"
            },
            new Usuario
            {
                Id = 2,
                Nombre = "Jane Smith",
                Email = "jane.smith@example.com",
                NumeroTelefono = "9876543210",
                Password = "hashed_password_2", // Replace with hashed values        Role = "User"
            },
            new Usuario
            {
                Id = 3,
                Nombre = "Alice Johnson",
                Email = "alice.johnson@example.com",
                NumeroTelefono = "4567891230",
                Password = "hashed_password_3", // Replace with hashed values        Role = "User"
            },
            new Usuario
            {
                Id = 4,
                Nombre = "Bob Brown",
                Email = "bob.brown@example.com",
                NumeroTelefono = "3216549870",
                Password = "hashed_password_4", // Replace with hashed values        Role = "Moderator"
            },
            new Usuario
            {
                Id = 5,
                Nombre = "Charlie Davis",
                Email = "charlie.davis@example.com",
                NumeroTelefono = "6549873210",
                Password = "hashed_password_5", // Replace with hashed values        Role = "User"
            }
);


            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Nombre = "Laptop", Descripcion = "Laptop moderna y rápida", Precio = 800.99 },
                new Producto { Id = 2, Nombre = "Smartphone", Descripcion = "Teléfono inteligente con gran cámara", Precio = 600.49 },
                new Producto { Id = 3, Nombre = "Audífonos", Descripcion = "Audífonos inalámbricos", Precio = 150.00 },
                new Producto { Id = 4, Nombre = "Monitor", Descripcion = "Monitor 4K UHD", Precio = 300.75 },
                new Producto { Id = 5, Nombre = "Teclado Mecánico", Descripcion = "Teclado para gamers", Precio = 120.50 }
            );

            modelBuilder.Entity<Wishlist>().HasData(
                new Wishlist { Id = 1, Nombre = "Regalos de Navidad", UsuarioId = 1 },
                new Wishlist { Id = 2, Nombre = "Compras de Tecnología", UsuarioId = 2 },
                new Wishlist { Id = 3, Nombre = "Hogar", UsuarioId = 3 },
                new Wishlist { Id = 4, Nombre = "Libros Favoritos", UsuarioId = 4 },
                new Wishlist { Id = 5, Nombre = "Deportes", UsuarioId = 5 }
            );

            modelBuilder.Entity<WishlistProducto>().HasData(
                new WishlistProducto
                {
                    WishlistId = 1,
                    ProductoId = 1,
                    Nombre = "Laptop para Regalo",
                    FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0),
                    FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0)
                },
                new WishlistProducto
                {
                    WishlistId = 1,
                    ProductoId = 3,
                    Nombre = "Audífonos para Juan",
                    FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0),
                    FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0)
                },
                new WishlistProducto
                {
                    WishlistId = 2,
                    ProductoId = 2,
                    Nombre = "Smartphone Moderno",
                    FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0),
                    FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0)
                },
                new WishlistProducto
                {
                    WishlistId = 3,
                    ProductoId = 4,
                    Nombre = "Monitor para Hogar",
                    FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0),
                    FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0)
                },
                new WishlistProducto
                {
                    WishlistId = 4,
                    ProductoId = 5,
                    Nombre = "Teclado Mecánico para Gaming",
                    FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0),
                    FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0)
                }
            );
        }
    }
}
