using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace taanbus.domain.entities
{
    public partial class Sugerencia
    {
        public int Id { get; set; }
        public string NombreCiudadano { get; set; }
        public string ApellidosCiudadano { get; set; }
        public string CorreoCiudadano { get; set; }
        public string TelefonoCiudadano { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
