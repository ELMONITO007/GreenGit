using GreenElectric.Data.Servicios.Bitacora;
using GreenElectric.EE.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Negocio.Bitacoras
{
    public class EventoBitacoraBE : IRepository<EventoBitacora>
    {
        public EventoBitacora Create(EventoBitacora entity)
        {
            EventoBitacoraDAC eventoBitacoraDAC = new EventoBitacoraDAC();
            return eventoBitacoraDAC.Create(entity);
        }

        public void Delete(int id)
        {
            EventoBitacoraDAC eventoBitacoraDAC = new EventoBitacoraDAC();
            eventoBitacoraDAC.Delete(id);
        }

        public List<EventoBitacora> Read()
        {
            EventoBitacoraDAC eventoBitacoraDAC = new EventoBitacoraDAC();
            return eventoBitacoraDAC.Read();
        }

        public EventoBitacora ReadBy(int id)
        {
            EventoBitacoraDAC eventoBitacoraDAC = new EventoBitacoraDAC();
            return eventoBitacoraDAC.ReadBy(id);
        }

        public void Update(EventoBitacora entity)
        {
            EventoBitacoraDAC eventoBitacoraDAC = new EventoBitacoraDAC();
            eventoBitacoraDAC.Update(entity);
        }
    }
}
