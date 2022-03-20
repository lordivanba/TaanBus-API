using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taanbus.Domain.Dtos.Responses
{
    public class QuejaAprobadaResponse
    {
        public string MotivoQueja { get; set; }
        public DateTime FechaHechos { get; set; }
        public string Descripcion { get; set; }
    }
}