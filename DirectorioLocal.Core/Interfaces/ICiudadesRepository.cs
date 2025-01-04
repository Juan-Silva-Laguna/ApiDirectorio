using DirectorioLocal.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Interfaces
{
    public interface ICiudadesRepository
    {
        Task<IEnumerable<Ciudades>> GetCiudades();
    }
}