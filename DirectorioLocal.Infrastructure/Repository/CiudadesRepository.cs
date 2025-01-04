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
    public class CiudadesRepository : ICiudadesRepository
    {
        private readonly PaisesEstadosCiudadesContext _context;
        public CiudadesRepository(PaisesEstadosCiudadesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Ciudades>> GetCiudades()
        {
            var infoCiudades = await _context.Ciudades.ToListAsync();
            return infoCiudades;
        }
    }
}
