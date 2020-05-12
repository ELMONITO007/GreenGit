using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GreenElectric.Entities
{
 public   class TipoDomicilio :Entity
    {
        [Required]
        public string Tipo { get; set   ; }

        [DisplayName("Descripción")]
        public string Descripcion{ get; set; }


        public TipoDomicilio()
        {

        }

        public TipoDomicilio(int _id,string _tipo,string _descripcion)
        {
            Id = _id;
            Tipo = _tipo;
            Descripcion = _descripcion;
        }
    }
}
