using GreenElectric.Data.Servicios.Login;
using GreenElectric.EE.Servicios.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Negocio.Login
{
    public class UsuarioBe : IRepository<Usuario>
    {
        public Usuario Create(Usuario entity)
        {
            UsuarioDAC usuarioDAC = new UsuarioDAC();
            return usuarioDAC.Create(entity);
        }

        public void Delete(int id)
        {
            UsuarioDAC usuarioDAC = new UsuarioDAC();
            usuarioDAC.Delete(id);
        }

        public List<Usuario> Read()
        {
            UsuarioDAC usuarioDAC = new UsuarioDAC();
            return usuarioDAC.Read();
        }

        public Usuario ReadBy(int id)
        {
            UsuarioDAC usuarioDAC = new UsuarioDAC();
            return usuarioDAC.ReadBy(id);
        }

        public void Update(Usuario entity)
        {
            UsuarioDAC usuarioDAC = new UsuarioDAC();
            usuarioDAC.Update(entity);
        }
    }
}
