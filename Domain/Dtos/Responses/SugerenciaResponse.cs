using System;

namespace taanbus.domain.dtos.responses
{
    public class SugerenciaResponse
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