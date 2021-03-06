﻿using GreenElectric.Data.Servicios.Permisos;
using GreenElectric.EE.Servicios.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Negocio.Permisos
{
    public class FamiliaBE : IRepository<Familia>
    {
        public Familia Create(Familia entity)
        {
            FamiliaDac familiaDac = new FamiliaDac();
            return familiaDac.Create(entity);
        }

        public void Delete(int id)
        {
            FamiliaDac familiaDac = new FamiliaDac();
            familiaDac.Delete(id);
        }

        public List<Familia> Read()
        {
            FamiliaDac familiaDac = new FamiliaDac();
            return familiaDac.Read();
        }

        public Familia ReadBy(int id)
        {
            FamiliaDac familiaDac = new FamiliaDac();
            return familiaDac.ReadBy(id);
        }

        public void Update(Familia entity)
        {
            FamiliaDac familiaDac = new FamiliaDac();
            familiaDac.Update(entity);
        }
        public List<Familia> ReadPatente(int id)
        {

            FamiliaDac familiaDac = new FamiliaDac();
            return familiaDac.ReadPatente(id);
        }
        #region Composite
        //Obtener la lista de permisos y roles de una Familia

        public List<Familia> ObtenerPermisosDeUnaFamilia(int id)
        {
            FamiliaDac familiaDac = new FamiliaDac();
            return familiaDac.ObtenerPermisosDeUnaFamilia(id);
        }

        
        public void ObtenerTodosLosPermisos(Familia familia)
        {
         
            foreach (Familia item in ObtenerPermisosDeUnaFamilia(familia.Id))
            {
               
                
                
               
                familia.agregarFamilia(item);

                ObtenerTodosLosPermisos(item);
            }


          
        }




       
        #endregion
    }
}
