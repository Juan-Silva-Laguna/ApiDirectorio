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
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly PaisesEstadosCiudadesContext _context;
        public UsuariosRepository(PaisesEstadosCiudadesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuarios> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        public async Task InsertUsuario(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            Console.WriteLine(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUsuario(Usuarios usuario)
        {
            var currentUsuario = await GetUsuario(usuario.Id);
            currentUsuario.IdCiudad = usuario.IdCiudad;
            currentUsuario.Usuario1 = usuario.Usuario1;
            currentUsuario.Password = usuario.Password;
            Console.WriteLine(currentUsuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var currentUsuario = await GetUsuario(id);
            _context.Usuarios.Remove(currentUsuario);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Usuarios> GetLoginByCredentials(UserLogin login)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Usuario1 == login.Usuario);
        }

    }
}
