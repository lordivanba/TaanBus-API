
namespace taanbus.domain.dtos.responses
{
    public class SugerenciaUpdateRequest
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }

    }
}