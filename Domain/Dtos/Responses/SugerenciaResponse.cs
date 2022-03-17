using System;

namespace taanbus.domain.dtos.responses
{
    public class SugerenciaResponse
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? Status { get; set; } = 0;
        public int? UserId { get; set; }
        public string Ciudadano { get; set; }
    }
}