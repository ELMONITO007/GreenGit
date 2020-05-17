using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.Login
{
  public  class SessionManager
    {
        private SessionManager() { }
        private static SessionManager _intance = null;
        public static SessionManager instance
        {
            get
            {
                if (_intance == null)
                {
                    _intance = new SessionManager();
                }

                return _intance;
            }

        }

        private Usuario usuario;
        public void login(Usuario user)
        {
            usuario = user;

        }
        public Usuario GetUSuario()
        {
            return usuario;
        }
        public void LogOut()
        {
            usuario = null;
        }
    }
}
