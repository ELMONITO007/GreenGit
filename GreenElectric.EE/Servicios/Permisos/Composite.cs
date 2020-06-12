using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GreenElectric.EE.Servicios.Permisos
{
    public abstract class Composite : Entity
    {
        [DisplayName("Nombre")]
        [Required]
        public string nombre { get; set; }

        [DisplayName("Descripción")]
        [Required]
        public string descripcion { get; set; }
     
        public abstract string Display(int deph);

        public abstract string Mostrar(int deph);


    }
}


