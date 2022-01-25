using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taanbus.domain.entities;
using taanbus.Domain.Interfaces;

namespace taanbus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuejaController : ControllerBase
    {
        private readonly IQuejaSqlRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuejaController(IQuejaSqlRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuejas()
        {
            var quejas = await _repository.GetQuejas();
            return Ok(quejas);
        }

        [HttpGet]
        [Route("{id::int}")]
        public async Task<IActionResult> GetQuejaById(int id){
            var queja = await _repository.GetQuejaById(id);
            if(queja == null)
                return NotFound("No se ha encontrado una sugerencia que corresponda con el ID proporcionado");
            return Ok(queja);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQueja(Queja queja){
            int id;
            try{
                id = await _repository.CreateQueja(queja);
            } catch(Exception e){
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            if(id <=0)
                return Conflict("El registro no puede ser realizado, verifica tu informacion");
            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/Queja/{id}";

            return Created(urlResult, id);
        }
    }
}
