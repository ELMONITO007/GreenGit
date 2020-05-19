using GreenElectric.Data.Servicios.Permisos;
using GreenElectric.EE.Servicios.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Negocio.Permisos
{
    public class PatenteBE : IRepository<Patente>
    {
        public Patente Create(Patente entity)
        {
            PatenteDAC patente = new PatenteDAC();
            return patente.Create(entity);
        }

        public void Delete(int id)
        {
            PatenteDAC patente = new PatenteDAC();
            patente.Delete(id);
        }

        public List<Patente> Read()
        {
            PatenteDAC patente = new PatenteDAC();
            return patente.Read();
        }

        public Patente ReadBy(int id)
        {
            PatenteDAC patente = new PatenteDAC();
            return patente.ReadBy(id);
        }

        public void Update(Patente entity)
        {
            PatenteDAC patente = new PatenteDAC();
            patente.Update(entity);
        }
    }
}
