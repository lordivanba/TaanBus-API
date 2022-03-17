using System;

namespace taanbus.domain.dtos.requests
{
    public class QuejaCreateRequest
    {
        public string MotivoQueja { get; set; }
        public DateTime FechaHechos { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Status { get; set; } = 0;
        public int UserId { get; set; }
    }
}