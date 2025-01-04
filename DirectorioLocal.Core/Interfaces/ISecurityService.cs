using DirectorioLocal.Core.Entities;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Usuarios> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Usuarios security);
    }
}