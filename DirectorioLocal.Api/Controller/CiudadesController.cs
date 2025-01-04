using DirectorioLocal.Core.Interfaces;
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
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudadesRepository _ciudadesRepository;

        public CiudadesController(ICiudadesRepository ciudadesRepository)
        {
            _ciudadesRepository = ciudadesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaises()
        {
            var infos = await _ciudadesRepository.GetCiudades();

            return Ok(infos);
        }

    }
}
