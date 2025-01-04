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
    public class PaisesRepository : IPaisesRepository
    {
        private readonly PaisesEstadosCiudadesContext _context;
        public PaisesRepository(PaisesEstadosCiudadesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Paises>> GetPaises(string nombrePais)
        {
            if(nombrePais != null)
            {
                var infoPais = await _context.Paises.Where(x => x.Name == nombrePais).ToListAsync();
                return infoPais;
            }
            var infoPaises = await _context.Paises.ToListAsync();
            return infoPaises;
        }
        public async Task<IEnumerable<Estados>> GetEstados(int idPais)
        {
            var estados = await (from p in _context.Paises
                            join e in _context.Estados on p.Id equals e.IdPais
                            select new Estados
                            {
                                IdPais = e.IdPais,
                                Name = e.Name,
                                Id = e.Id

                            }).Where(x => x.IdPais == idPais).ToListAsync();
            return estados;
        }
    }
}
