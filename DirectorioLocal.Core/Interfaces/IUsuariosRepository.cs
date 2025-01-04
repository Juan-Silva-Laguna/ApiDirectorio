using DirectorioLocal.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuarios>> GetUsuarios();
        Task<Usuarios> GetUsuario(int id);
        Task InsertUsuario(Usuarios Usuario);
        Task<bool> UpdateUsuario(Usuarios usuario);
        Task<bool> DeleteUsuario(int id);
        Task<Usuarios> GetLoginByCredentials(UserLogin login);
    }
}