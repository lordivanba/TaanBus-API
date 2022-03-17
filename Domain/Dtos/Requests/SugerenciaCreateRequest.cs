
namespace taanbus.domain.dtos.requests
{
    public class SugerenciaCreateRequest
    {
        public string Descripcion { get; set; }
        public int? Status { get; set; } = 0;
        public int? UserId { get; set; }

    }
}