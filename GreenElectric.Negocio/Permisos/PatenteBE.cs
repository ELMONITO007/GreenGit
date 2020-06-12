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
            PatenteDAC patenteDAC = new PatenteDAC();
            Patente patente = new Patente();
            if (!VerificarSiExistePatente(entity))
            {
                patente = patenteDAC.Create(entity);
                patenteDAC.CreatePatente(entity);
                return patente;
            }
            else
            {
                return entity;
            }
           
            
            
           
        }

        public bool VerificarSiExistePatente(Patente entity)
        {
            PatenteDAC patenteDAC = new PatenteDAC();
            Patente patente = new Patente();
            patente = patenteDAC.ReadBy(entity);
            if (patente is null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
        public bool VerificarPatente(int id)
        {
            Patente patente = new Patente();
            patente = ReadBy(id);
            if (patente is null)
            {
                return false;
            }
            else
            {
                return true;
            }    
        }
    }
}
