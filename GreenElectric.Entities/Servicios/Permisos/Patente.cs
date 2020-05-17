using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.Permisos
{
    public class Patente : Composite
    {
        public override string Display(int depth)
        {
            return nombre;
        }
        public override string Mostrar(int depth)
        {
            return nombre;
        }
    }
}

