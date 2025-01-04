using DirectorioLocal.Core.Entities;
using DirectorioLocal.Core.Interfaces;
using DirectorioLocal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioLocal.Infrastructure.Repository
{
    public class InfoRepository : IInfoRepository
    {
        private readonly PaisesEstadosCiudadesContext _context;
        public InfoRepository(PaisesEstadosCiudadesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PaisesEstadosCiudades>> GetInformacion(string nombrePais, string nombreEstado, string nombreCiudad)
        {
            if (nombrePais != null)
            {
                if (nombreEstado != null)
                {
                    if (nombreCiudad != null)
                    {
                        var infoValidacion = await (from e in _context.Estados
                                                    join c in _context.Ciudades on e.Id equals c.IdEstado
                                                    join p in _context.Paises on e.IdPais equals p.Id
                                                    select new PaisesEstadosCiudades
                                                    {
                                                        IdPais = p.Id,
                                                        Estado = e.Name,
                                                        Pais = p.Name,
                                                        IdEstado = e.Id,
                                                        Ciudad = c.Name,
                                                        IdCiudad = c.Id

                                                    }).Where(x => x.Pais == nombrePais).Where(x => x.Estado == nombreEstado).Where(x => x.Ciudad == nombreCiudad).ToListAsync();


                        if (infoValidacion.Count() != 0)
                        {
                            System.Console.WriteLine("Exitoso");
                        }
                        else
                        {
                            System.Console.WriteLine("No se encontro relacion");
                        }

                    }

                    var infoCiudades = await (from e in _context.Estados
                                              join c in _context.Ciudades on e.Id equals c.IdEstado
                                              join p in _context.Paises on e.IdPais equals p.Id
                                              select new PaisesEstadosCiudades
                                              {
                                                  IdPais = p.Id,
                                                  Estado = e.Name,
                                                  Pais = p.Name,
                                                  IdEstado = e.Id,
                                                  Ciudad = c.Name,
                                                  IdCiudad = c.Id

                                              }).Where(x => x.Pais == nombrePais).Where(x => x.Estado == nombreEstado).ToListAsync();

                    return infoCiudades;
                }
                var infoEstados = await (from p in _context.Paises
                                         join e in _context.Estados on p.Id equals e.IdPais
                                         select new PaisesEstadosCiudades
                                         {
                                             IdPais = e.IdPais,
                                             Estado = e.Name,
                                             Pais = p.Name,
                                             IdEstado = e.Id

                                         }).Where(x => x.Pais == nombrePais).ToListAsync();

                return infoEstados;
            }


            var infoPaises = await _context.Paises.ToListAsync();
            return (IEnumerable<PaisesEstadosCiudades>)infoPaises;
        }
    }
}
