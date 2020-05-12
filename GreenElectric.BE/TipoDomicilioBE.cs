using System;
using System.Collections.Generic;
using System.Text;
using GreenElectric.BE;
using GreenElectric.DAC;
using GreenElectric.Entities;

namespace GreenElectric.BE
{
    public class TipoDomicilioBE : IRepository<TipoDomicilio>
    {
        public TipoDomicilio Create(TipoDomicilio entity)
        {
            TipoDomicilio result = new TipoDomicilio();
            TipoDomicilioDAC tipoDomicilioDAC = new TipoDomicilioDAC();
            result = tipoDomicilioDAC.Create(entity);
            return result;
        }

        public void Delete(int id)
        {
            TipoDomicilioDAC tipoDomicilioDAC = new TipoDomicilioDAC();
            tipoDomicilioDAC.Delete(id);
        }

        public List<TipoDomicilio> Read()
        {
            List<TipoDomicilio> result = new List<TipoDomicilio>();
            TipoDomicilioDAC tipoDomicilioDAC = new TipoDomicilioDAC();
            result = tipoDomicilioDAC.Read();
            return result;
        }

        public TipoDomicilio ReadBy(int id)
        {
            TipoDomicilio result = new TipoDomicilio();
            TipoDomicilioDAC tipoDomicilioDAC = new TipoDomicilioDAC();
            result = tipoDomicilioDAC.ReadBy(id);
            return result;
        }

        public void Update(TipoDomicilio entity)
        {
            TipoDomicilioDAC tipoDomicilioDAC = new TipoDomicilioDAC();
            tipoDomicilioDAC.Update(entity);
        }
    }
}
