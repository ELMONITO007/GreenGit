using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.Bitacora
{
   public class EventoBitacora
    {
        public EventoBitacora(string _evento)
        {
            eventoBitacora = _evento;
        }
        public EventoBitacora()
        {
           
        }
        public string eventoBitacora
        {
            get;
            set;
        }

    }
}
