using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GreenElectric.EE.Servicios.Bitacora
{
   public class EventoBitacora : Entity
    {
        public EventoBitacora(string _evento)
        {
            eventoBitacora = _evento;
        }
        public EventoBitacora()
        {
           
        }

        [Required]
        [DisplayName("Nombre del Tipo de Evento de la Bitacora")]
        [DataType(DataType.Text,ErrorMessage ="Debe ser solo texto")]
        public string eventoBitacora
        {
            get;
            set;
        }

    }
}
