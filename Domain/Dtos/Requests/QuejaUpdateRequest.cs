using System;

namespace taanbus.domain.dtos.requests
{
    public class QuejaUpdateRequest
    {
        public int Id { get; set; }
        public string MotivoQueja { get; set; }
        public DateTime FechaHechos { get; set; }
        public string Descripcion { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
    }
}