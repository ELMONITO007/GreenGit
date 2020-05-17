using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.Permisos
{
    public abstract class Composite : Entity
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
     
        public abstract string Display(int deph);

        public abstract string Mostrar(int deph);


    }
}


