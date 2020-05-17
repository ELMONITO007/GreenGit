using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.Login
{
public   class Usuario : Entity
    {

        public string nombreUsuario { get; set; }
        public string contraseña { get; set; }
        public string digitoVerificadorH { get; set; }
        public bool hablitado { get; set; }
        public Usuario(string _nombreUsuario, string _contraseña, string _digitoVerificadorH, bool _hablitado)
        {
            nombreUsuario = _nombreUsuario;
            contraseña = _contraseña;
            digitoVerificadorH = _digitoVerificadorH;
            hablitado = _hablitado;
        }
        public Usuario()
        {


        }
    }
}
