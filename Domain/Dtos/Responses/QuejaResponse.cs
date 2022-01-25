using System;

namespace taanbus.domain.dtos.responses{
    public class QuejaResponse{
        public int Id { get; set; }
        public string MotivoQueja { get; set; }
        public DateTime FechaHechos { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}