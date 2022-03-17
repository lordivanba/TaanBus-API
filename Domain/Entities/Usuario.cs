using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace taanbus.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Queja = new HashSet<Queja>();
            Sugerencia = new HashSet<Sugerencia>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Usertype { get; set; } = 0;

        public virtual ICollection<Queja> Queja { get; set; }
        public virtual ICollection<Sugerencia> Sugerencia { get; set; }
    }
}
