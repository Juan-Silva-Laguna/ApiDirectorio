using DirectorioLocal.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Interfaces
{
    public interface IInfoRepository
    {
        Task<IEnumerable<PaisesEstadosCiudades>> GetInformacion(string nombrePais, string nombreEstado, string nombreCiudad);
    }
}