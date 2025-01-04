using AutoMapper;
using DirectorioLocal.Core.DTOs;
using DirectorioLocal.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SocialMedia.Api.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorioLocal.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoRepository _infoRepository;
        private readonly IMapper _mapper;

        public InfoController(IInfoRepository InfoRepository, IMapper mapper)
        {
            _infoRepository = InfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetInformacion(string nombrePais, string nombreEstado, string nombreCiudad)
        {
            var infos = await _infoRepository.GetInformacion(nombrePais, nombreEstado, nombreCiudad);
            var infoDto = _mapper.Map<IEnumerable<InfoDto>>(infos);
            var response = new ApiResponse<IEnumerable<InfoDto>>(infoDto);

            return Ok(infos);
        }

        //[HttpGet("{nombrePais}")]
        //public async Task<IActionResult> GetEstados(string nombrePais)
        //{
        //    var info = await _infoRepository.GetEstados(nombrePais);
        //    return Ok(info);
        //}

        //[HttpGet("{nombrePais}")]
        //public async Task<IActionResult> GetCiudades(string nombrePais, string nombreEstado)
        //{
        //    var info = await _infoRepository.GetCiudades(nombreEstado);
        //    return Ok(info);
        //}
    }
}
