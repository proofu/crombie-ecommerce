﻿namespace ProyectoeCommerce.Models.Entity
{
    //[Table("Usuario")]
    public class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string NumeroTelefono { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }

        enum Role
        {
            Admin,
            UsuarioRegistrado,
            Invitado
        }

    }
}