using System;
using System.Collections.Generic;
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
        public string eventoBitacora
        {
            get;
            set;
        }

    }
}
