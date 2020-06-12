using GreenElectric.EE.Servicios.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.EE.Servicios.Permisos
{
   public class UsuarioPermiso
    {
        public Usuario  usuario { get; set; }
        public Familia Familia { get; set; }

        public Patente Patente { get; set; }

        public UsuarioPermiso()
        {
            usuario = new Usuario();
            Patente = new Patente();
            Familia = new Familia();

        }
    }
}
