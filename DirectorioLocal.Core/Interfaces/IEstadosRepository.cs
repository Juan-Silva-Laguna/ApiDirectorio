using DirectorioLocal.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Interfaces
{
    public interface IEstadosRepository
    {
        Task<IEnumerable<Estados>> GetEstados(string nombreEstado);
        Task<IEnumerable<Ciudades>> GetCiudades(int idEstado);
    }
}