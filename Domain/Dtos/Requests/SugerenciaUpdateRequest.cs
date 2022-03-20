
namespace taanbus.domain.dtos.requests
{
    public class SugerenciaUpdateRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }

    }
}