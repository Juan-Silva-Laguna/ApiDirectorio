using DirectorioLocal.Core.Entities;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Interfaces
{
    public interface ISecurityRepository : IUsuariosRepository
    {
        Task<Usuarios> GetLoginByCredentials(UserLogin login);
    }
}