using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taanbus.domain.dtos.requests;
using taanbus.domain.dtos.responses;
using taanbus.Domain.Dtos.Responses;
using taanbus.Domain.Entities;
using taanbus.Domain.Interfaces;

namespace taanbus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugerenciaController : ControllerBase
    {
        private readonly ISugerenciaSqlRepository _repository;
        private readonly IHttpContextAccessor _httpContextAcessor;
        private readonly IMapper _mapper;

        public SugerenciaController(
            ISugerenciaSqlRepository repository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _repository = repository;
            _httpContextAcessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSugerencias()
        {
            var sugerencias = await _repository.GetSugerencias();
            var response = _mapper.Map<IEnumerable<Sugerencia>, IEnumerable<SugerenciaResponse>>(sugerencias);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id::int}")]
        public async Task<IActionResult> GetSugerenciaById(int id)
        {
            var sugerencia = await _repository.GetSugerenciaById(id);
            if (sugerencia == null)
                return NotFound("No se ha encontrado una sugrencia que corresponda con el ID proporcionado");
            var response = _mapper.Map<Sugerencia, SugerenciaResponse>(sugerencia);

            return Ok(response);
        }

        [HttpGet]
        [Route("user={id::int}")]
        public async Task<IActionResult> GetUserSugerencias(int id)
        {
            var sugerencias = await _repository.GetUserSugerencias(id);
            return Ok(sugerencias);
        }

        [HttpGet]
        [Route("aprobadas")]
        public async Task<IActionResult> GetSugerenciasAprobadas()
        {
            var sugerencias = await _repository.GetSugerenciasAprobadas();
            var response = _mapper.Map<IEnumerable<Sugerencia>, IEnumerable<SugerenciaAprobadaResponse>>(sugerencias);
            return Ok(response);
        }

        [HttpPut]
        [Route("update_status/{id::int}")]
        public async Task<IActionResult> UpdateSugerenciaStatus(int id, [FromBody] SugerenciaStatusUpdateRequest sugerencia)
        {

            if (id <= 0)
                return NotFound("No se encontro un registro que coincida con la informacion proporcionada");

            try
            {
                var result = await _repository.UpdateStatus(id, sugerencia.Status)
                ;
                if (!result)
                    return Conflict("No fue posible realizar la actualizacion, verifica tu informacion");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSugerencia([FromBody] SugerenciaCreateRequest sugerencia)
        {

            var obj = _mapper.Map<SugerenciaCreateRequest, Sugerencia>(sugerencia);
            int id;
            try
            {
                id = await _repository.CreateSugerencia(obj);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            if (id <= 0)
                return Conflict("El registro no puede ser realizado, verifica tu informacion");
            var host = _httpContextAcessor.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/Sugerencia/{id}";

            return Created(urlResult, id);
        }

        [HttpPut]
        [Route("{id::int}")]
        public async Task<IActionResult> UpdateSugerencia(int id, [FromBody] SugerenciaUpdateRequest sugerencia)
        {
            if (id <= 0)
                return NotFound("No se encontro un registo que coincida con la informacion proporcionada");
            if (sugerencia == null)
                return UnprocessableEntity("La actualizacion no puede ser realiaza a falta de informacion");

            var obj = _mapper.Map<SugerenciaUpdateRequest, Sugerencia>(sugerencia);
            obj.Id = id;

            try
            {
                var result = await _repository.UpdateSugerencia(id, obj);
                if (!result)
                    return Conflict("No fue posible realizar la actualizacion, verifica tu informacion");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id::int}")]
        public async Task<IActionResult> DeleteSugerencia([FromRoute] int id)
        {
            if (id <= 0)
                return NotFound("No se ha encontrado una sugerencia que corresponda con el ID proporcionado");
            try
            {
                await _repository.DeleteSugerencia(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
