using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taanbus.Domain.Entities;
using taanbus.Domain.Interfaces;
using taanbus.Infrastructure.Repositories;

namespace taanbus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioSqlRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IUsuarioSqlRepository repository,  IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Usuario usuario){
            TokenClass tokenClass = new TokenClass();

            var user = await _repository.GetUser(usuario.Username);
            if(user == null){
                tokenClass.TokenOrMessage = "Usuario no autorizado";
                return Ok(tokenClass);
            }

            bool credentials = usuario.Password.Equals(user.Password);
            if(!credentials){
                tokenClass.TokenOrMessage = "Password incorrecto";
                return Ok(tokenClass);
            }

            tokenClass.TokenOrMessage =  TokenManager.GenerateToken(user.Username);
            tokenClass.Success = 1;
            return Ok(tokenClass);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(){
            var users = await _repository.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(Usuario usuario)
        {
            
            int id;
            try{
                id = await _repository.CreateUser(usuario);
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