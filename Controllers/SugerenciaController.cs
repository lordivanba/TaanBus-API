using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taanbus.domain.entities;
using taanbus.Domain.Interfaces;

namespace taanbus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugerenciaController : ControllerBase
    {
        private readonly ISugerenciaSqlRepository _repository;
        
        public SugerenciaController(ISugerenciaSqlRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSugerencias(){
            var query = await _repository.GetSugerencias();
            return Ok(query);
        }
    }
}
