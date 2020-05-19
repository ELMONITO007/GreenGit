using GreenElectric.Data.Servicios.Bitacora;
using GreenElectric.EE.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Negocio.Bitacoras
{
    public class BitacoraBE : IRepository<Bitacora>
    {
        public Bitacora Create(Bitacora entity)
        {
            BitacoraDAC bitacoraDAC = new BitacoraDAC();
        
            return bitacoraDAC.Create(entity);
        }

        public void Delete(int id)
        {
            BitacoraDAC bitacoraDAC = new BitacoraDAC();

            bitacoraDAC.Delete(id);
        }

        public List<Bitacora> Read()
        {
            BitacoraDAC bitacoraDAC = new BitacoraDAC();

            return bitacoraDAC.Read();
        }

        public Bitacora ReadBy(int id)
        {
            BitacoraDAC bitacoraDAC = new BitacoraDAC();

            return bitacoraDAC.ReadBy(id);
        }

        public void Update(Bitacora entity)
        {
            BitacoraDAC bitacoraDAC = new BitacoraDAC();

            bitacoraDAC.Update(entity);
        }
    }
}
