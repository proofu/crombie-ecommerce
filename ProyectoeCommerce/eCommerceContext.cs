using Microsoft.EntityFrameworkCore;
using ProyectoeCommerce.Models.Entity;

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
            });

            modelBuilder.Entity<Wishlist>(w =>
            {
                w.HasKey(w => w.Id);
                w.Property(w => w.Nombre).IsRequired().HasMaxLength(100);

                w.HasOne(w => w.Usuario)
                 .WithMany()
                 .HasForeignKey(w => w.UsuarioId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<WishlistProducto>(wp =>
            {
                wp.HasKey(wp => new { wp.ProductoId, wp.WishlistId });

                wp.HasOne(wp => wp.Producto)
                  .WithMany()
                  .HasForeignKey(wp => wp.ProductoId)
                  .OnDelete(DeleteBehavior.Restrict);

                wp.HasOne(wp => wp.Wishlist)
                  .WithMany(w => w.WishlistProductos)
                  .HasForeignKey(wp => wp.WishlistId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
