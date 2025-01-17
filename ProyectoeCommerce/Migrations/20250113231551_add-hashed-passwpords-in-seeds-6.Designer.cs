﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoeCommerce;

#nullable disable

namespace ProyectoeCommerce.Migrations
{
    [DbContext(typeof(eCommerceContext))]
    [Migration("20250113231551_add-hashed-passwpords-in-seeds-6")]
    partial class addhashedpasswpordsinseeds6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Laptop moderna y rápida",
                            Nombre = "Laptop",
                            Precio = 800.99000000000001
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Teléfono inteligente con gran cámara",
                            Nombre = "Smartphone",
                            Precio = 600.49000000000001
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Audífonos inalámbricos",
                            Nombre = "Audífonos",
                            Precio = 150.0
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Monitor 4K UHD",
                            Nombre = "Monitor",
                            Precio = 300.75
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Teclado para gamers",
                            Nombre = "Teclado Mecánico",
                            Precio = 120.5
                        });
                });

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin1@example.com",
                            Nombre = "Admin User 1",
                            NumeroTelefono = "1234567890",
                            Password = "AQAAAAIAAYagAAAAEIis2HPrIf1ogcY2tlJsnQSrnCbCQD6TZrPhQFkmNnx2ASsq9EUjvneL8AYAfuq3lQ==",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "admin2@example.com",
                            Nombre = "Admin User 2",
                            NumeroTelefono = "1234567891",
                            Password = "AQAAAAIAAYagAAAAEFFs2wqrhofMR06eQLtW9LQwY8hSbJYdywBcd1DLGkCaLNLbT96Ox4Se9TscWImQuQ==",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Email = "testuser1@example.com",
                            Nombre = "Test User 1",
                            NumeroTelefono = "1234567892",
                            Password = "AQAAAAIAAYagAAAAELssIdRkJP2hYMnY2e0sjl1HqQ5fDxuI1rPj6AG1arTwG6gusZS1cN+Bf4VLbDjm0Q==",
                            Role = "User"
                        },
                        new
                        {
                            Id = 4,
                            Email = "testuser2@example.com",
                            Nombre = "Test User 2",
                            NumeroTelefono = "1234567893",
                            Password = "AQAAAAIAAYagAAAAEC0dSQbdpLxq+7qVLCeDuBB3OCQRD4d7RCDWGvddbAwIrSEVHvuT6VrCdegrEjsJOw==",
                            Role = "User"
                        },
                        new
                        {
                            Id = 5,
                            Email = "testuser3@example.com",
                            Nombre = "Test User 3",
                            NumeroTelefono = "1234567894",
                            Password = "AQAAAAIAAYagAAAAEIH9xchuSwXxNv5+ynf90RZgZNW6FKS29IewAJHS28Pbrw2Aq4yClX3PoE1/hpaSSA==",
                            Role = "User"
                        },
                        new
                        {
                            Id = 6,
                            Email = "testuser4@example.com",
                            Nombre = "Test User 4",
                            NumeroTelefono = "1234567895",
                            Password = "AQAAAAIAAYagAAAAEGVfBtBMebxW0qzTfXjRrkuAKtMokZjS4Y1W5+4zIO69M7Zd14ff3e7e8eJ3G60dnQ==",
                            Role = "User"
                        },
                        new
                        {
                            Id = 7,
                            Email = "admin3@example.com",
                            Nombre = "Admin User 3",
                            NumeroTelefono = "1234567896",
                            Password = "AQAAAAIAAYagAAAAEAzjl3OFAh/l60+95B510w5uyjE0rZ4vzJR3OWleosVu2K8cYax5AtYM7unXmQQHrA==",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 8,
                            Email = "testuser5@example.com",
                            Nombre = "Test User 5",
                            NumeroTelefono = "1234567897",
                            Password = "AQAAAAIAAYagAAAAEMK7wIV3RHKSrcn/y2YGhbGT7FJ2GUwB1/xnc6ewyy0+LrC61QneBcG9PMgnsFE6Fg==",
                            Role = "User"
                        },
                        new
                        {
                            Id = 9,
                            Email = "testuser6@example.com",
                            Nombre = "Test User 6",
                            NumeroTelefono = "1234567898",
                            Password = "AQAAAAIAAYagAAAAECeQpmh7OqczmYDVGCAW8pR2/e31bkoIwjgrC2+1M2ZrfLy0YBy2mAgbzt+sD7G2nA==",
                            Role = "User"
                        },
                        new
                        {
                            Id = 10,
                            Email = "testuser7@example.com",
                            Nombre = "Test User 7",
                            NumeroTelefono = "1234567899",
                            Password = "AQAAAAIAAYagAAAAEOTvwUqRPCmSBZa9NQSto4usaHBF6UZ1bnohDX38veEK0oOCynT64kGAjnikfYFf1g==",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Wishlists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Regalos de Navidad",
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Compras de Tecnología",
                            UsuarioId = 2
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Hogar",
                            UsuarioId = 3
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Libros Favoritos",
                            UsuarioId = 4
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Deportes",
                            UsuarioId = 5
                        });
                });

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.WishlistProducto", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("WishlistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("FechaProductoAgregado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductoId", "WishlistId");

                    b.HasIndex("WishlistId");

                    b.ToTable("WishlistProductos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            WishlistId = 1,
                            FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Laptop para Regalo"
                        },
                        new
                        {
                            ProductoId = 3,
                            WishlistId = 1,
                            FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Audífonos para Juan"
                        },
                        new
                        {
                            ProductoId = 2,
                            WishlistId = 2,
                            FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Smartphone Moderno"
                        },
                        new
                        {
                            ProductoId = 4,
                            WishlistId = 3,
                            FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Monitor para Hogar"
                        },
                        new
                        {
                            ProductoId = 5,
                            WishlistId = 4,
                            FechaCreacion = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaProductoAgregado = new DateTime(2024, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Teclado Mecánico para Gaming"
                        });
                });

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.Wishlist", b =>
                {
                    b.HasOne("ProyectoeCommerce.Models.Entity.Usuario", "Usuario")
                        .WithMany("Wishlists")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.WishlistProducto", b =>
                {
                    b.HasOne("ProyectoeCommerce.Models.Entity.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoeCommerce.Models.Entity.Wishlist", "Wishlist")
                        .WithMany("WishlistProductos")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.Usuario", b =>
                {
                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("ProyectoeCommerce.Models.Entity.Wishlist", b =>
                {
                    b.Navigation("WishlistProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
