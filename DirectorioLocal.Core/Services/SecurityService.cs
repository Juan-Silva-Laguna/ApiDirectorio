using DirectorioLocal.Core.Entities;
using DirectorioLocal.Core.Interfaces;
using System.Threading.Tasks;

namespace DirectorioLocal.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUsuariosRepository _usuarioRepository;

        public SecurityService(IUsuariosRepository usuarioRepository)
        {
            _usuarioRepository=usuarioRepository;
        }

        public async Task<Usuarios> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _usuarioRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Usuarios usuario)
        {
            await _usuarioRepository.InsertUsuario(usuario);
            //await _usuarioRepository.SaveChangesAsync();
        }

    }
}