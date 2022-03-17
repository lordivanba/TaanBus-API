using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace taanbus.Domain.Entities
{
    public partial class Sugerencia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Status { get; set; } = 0;
        public int? UserId { get; set; }

        public virtual Usuario User { get; set; }
    }
}
