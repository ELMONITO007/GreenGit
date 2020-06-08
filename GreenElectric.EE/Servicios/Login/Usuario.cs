using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GreenElectric.EE.Servicios.Login
{
public   class Usuario : Entity
    {
        [DisplayName("Usuario")]
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
