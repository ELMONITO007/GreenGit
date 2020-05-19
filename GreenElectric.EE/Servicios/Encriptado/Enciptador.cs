using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.EE.Servicios.Encriptado
{

  public abstract class Enciptador : Entity
    {
        public string valorInicial;

        public string valorEncriptado;

        public abstract string Hashear();
    }
}

