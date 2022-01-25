using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace taanbus.domain.entities
{
    public partial class Queja
    {
        public int Id { get; set; }
        public string MotivoQueja { get; set; }
        public DateTime? FechaHechos { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
