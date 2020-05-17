using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.Encriptado
{
  public abstract class Enciptador
    {
        public  string valorInicial;

        public string valorEncriptado;
        
        public abstract string Hashear();
    }
}
