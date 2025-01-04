using DirectorioLocal.Core.Interfaces;
using DirectorioLocal.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioLocal.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosRepository _estadoRepository;

        public EstadosController(IEstadosRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaises(string nombreEstado)
{
            var infos = await _estadoRepository.GetEstados(nombreEstado);

            return Ok(infos);
        }

        [HttpGet("{idEstado}")]
        public async Task<IActionResult> GetEstados(int idEstado)
        {
            var info = await _estadoRepository.GetCiudades(idEstado);
            return Ok(info);
        }
    }
}
