using DirectorioLocal.Core.DTOs;
using DirectorioLocal.Core.Interfaces;
using DirectorioLocal.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialMedia.Api.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace DirectorioLocal.Api.Controller
{
    //[EnableCors(origins: "https://localhost:44328", headers: "*", methods: "*")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisesRepository _paisesRepository;

        public PaisesController(IPaisesRepository paisesRepository)
        {
            _paisesRepository = paisesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaises(string nombrePais)
        {
            var infos = await _paisesRepository.GetPaises(nombrePais);
            return Ok(infos);
        }

        [HttpGet("{idPais}")]
        public async Task<IActionResult> GetEstados(int idPais)
{
            var info = await _paisesRepository.GetEstados(idPais);
            return Ok(info);
        }
    }
}
