using DirectorioLocal.Core.Entities;
using DirectorioLocal.Core.Interfaces;
using DirectorioLocal.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using System.Data;
using System.Threading.Tasks;

namespace DirectorioLocal.Api.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuarioRepository;
        private readonly IPasswordService _passwordService;

        public UsuariosController(IUsuariosRepository usuarioRepository, IPasswordService passwordService)
        {
            _usuarioRepository = usuarioRepository;
            _passwordService=passwordService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
{
            var usuarios = await _usuarioRepository.GetUsuarios();
            return Ok(usuarios);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetUsuario(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Usuario(Usuarios usuario)
        {            
            usuario.Password = _passwordService.Hash(usuario.Password);
            await _usuarioRepository.InsertUsuario(usuario);
            return Ok(usuario);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(int id, Usuarios usuario)
        {
            usuario.Id = id;

            var result = await _usuarioRepository.UpdateUsuario(usuario);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usuarioRepository.DeleteUsuario(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
