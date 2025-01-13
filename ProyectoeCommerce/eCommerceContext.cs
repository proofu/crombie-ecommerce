using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProyectoeCommerce.Models.Entity;
using System;

namespace ProyectoeCommerce
{
    public class eCommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
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
                u.Property(u => u.Password).HasMaxLength(255);
                u.Property(u => u.Role).IsRequired().HasMaxLength(50);
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

            var passwordHasher = new PasswordHasher<Usuario>();
            modelBuilder.Entity<Usuario>().HasData(
                 new Usuario
                 {
                     Id = 1,
                     Nombre = "Admin User 1",
                     Email = "admin1@example.com",
                     NumeroTelefono = "1234567890",
                     Role = "Admin",
                     Password = passwordHasher.HashPassword(null, "AdminPass1!")
                 },
        new Usuario
        {
            Id = 2,
            Nombre = "Admin User 2",
            Email = "admin2@example.com",
            NumeroTelefono = "1234567891",
            Role = "Admin",
            Password = passwordHasher.HashPassword(null, "AdminPass2!")
        },
        new Usuario
        {
            Id = 3,
            Nombre = "Test User 1",
            Email = "testuser1@example.com",
            NumeroTelefono = "1234567892",
            Role = "User",
            Password = passwordHasher.HashPassword(null, "UserPass1!")
        },
        new Usuario
        {
            Id = 4,
            Nombre = "Test User 2",
            Email = "testuser2@example.com",
            NumeroTelefono = "1234567893",
            Role = "User",
            Password = passwordHasher.HashPassword(null, "UserPass2!")
        },
        new Usuario
        {
            Id = 5,
            Nombre = "Test User 3",
            Email = "testuser3@example.com",
            NumeroTelefono = "1234567894",
            Role = "User",
            Password = passwordHasher.HashPassword(null, "UserPass3!")
        },
        new Usuario
        {
            Id = 6,
            Nombre = "Test User 4",
            Email = "testuser4@example.com",
            NumeroTelefono = "1234567895",
            Role = "User",
            Password = passwordHasher.HashPassword(null, "UserPass4!")
        },
        new Usuario
        {
            Id = 7,
            Nombre = "Admin User 3",
            Email = "admin3@example.com",
            NumeroTelefono = "1234567896",
            Role = "Admin",
            Password = passwordHasher.HashPassword(null, "AdminPass3!")
        },
        new Usuario
        {
            Id = 8,
            Nombre = "Test User 5",
            Email = "testuser5@example.com",
            NumeroTelefono = "1234567897",
            Role = "User",
            Password = passwordHasher.HashPassword(null, "UserPass5!")
        },
        new Usuario
        {
            Id = 9,
            Nombre = "Test User 6",
            Email = "testuser6@example.com",
            NumeroTelefono = "1234567898",
            Role = "User",
            Password = passwordHasher.HashPassword(null, "UserPass6!")
        },
        new Usuario
        {
            Id = 10,
            Nombre = "Test User 7",
            Email = "testuser7@example.com",
            NumeroTelefono = "1234567899",
            Role = "User",
            Password = passwordHasher.HashPassword(null, "UserPass7!")
        });
            /*
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
             */


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
