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
    public class EstadosRepository : IEstadosRepository
    {
        private readonly PaisesEstadosCiudadesContext _context;
        public EstadosRepository(PaisesEstadosCiudadesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Estados>> GetEstados(string nombreEstado)
        {
            if (nombreEstado != null)
            {
                var infoEstado = await _context.Estados.Where(x => x.Name == nombreEstado).ToListAsync();
                return infoEstado;
            }
            var infoEstados = await _context.Estados.ToListAsync();
            return infoEstados;
        }
        public async Task<IEnumerable<Ciudades>> GetCiudades(int idEstado)
        {
            var estados = await (from e in _context.Estados
                            join c in _context.Ciudades on e.Id equals c.IdEstado
                            select new Ciudades
                            {
                                IdEstado = c.IdEstado,
                                Name = c.Name,
                                Id = c.Id

                            }).Where(x => x.IdEstado == idEstado).ToListAsync();
            return estados;
        }
    }
}
