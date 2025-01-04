using DirectorioLocal.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Interfaces
{
    public interface IPaisesRepository
    {
        Task<IEnumerable<Paises>> GetPaises(string nombrePais);
        Task<IEnumerable<Estados>> GetEstados(int idPais);
    }
}