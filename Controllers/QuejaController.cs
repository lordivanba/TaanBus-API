using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taanbus.domain.dtos.requests;
using taanbus.domain.dtos.responses;
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
        private readonly IMapper _mapper;

        public QuejaController(
            IQuejaSqlRepository repository, 
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuejas()
        {
            var quejas = await _repository.GetQuejas();
            var response = _mapper.Map<IEnumerable<Queja>, IEnumerable<QuejaResponse>>(quejas);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id::int}")]
        public async Task<IActionResult> GetQuejaById(int id){
            var queja = await _repository.GetQuejaById(id);
            if(queja == null)
                return NotFound("No se ha encontrado una queja que corresponda con el ID proporcionado");
            var response = _mapper.Map<Queja, QuejaResponse>(queja);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQueja([FromBody]QuejaCreateRequest queja){


            var obj = _mapper.Map<QuejaCreateRequest, Queja>(queja);
            int id;
            try{
                id = await _repository.CreateQueja(obj);
            } catch(Exception e){
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            if(id <=0)
                return Conflict("El registro no puede ser realizado, verifica tu informacion");
            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/Queja/{id}";

            return Created(urlResult, id);
        }

        [HttpPut]
        [Route("{id::int}")]
        public async Task<IActionResult> UpdateQueja(int id, [FromBody] QuejaUpdateRequest queja){

            var obj = _mapper.Map<QuejaUpdateRequest, Queja>(queja);

            if(id <= 0)
                return NotFound("No se encontro un registro que coincida con la informacion proporcionada");
            if(queja == null)
                return UnprocessableEntity("La actualizacion no puede ser realizada a falta de informacion");
            queja.Id = id;

            try{
                var result = await _repository.UpdateQueja(id, obj)
                ;
                if(!result)
                    return Conflict("No fue posible realizar la actualizacion, verifica tu informacion");
            } catch(Exception e){
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return NoContent();
        }
    }
}
