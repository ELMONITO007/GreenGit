using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenElectric.Entities.Servicios.Permisos
{
    public class Familia : Composite

    {
        public List<Composite> compuesto = new List<Composite>();

        public void agregarFamilia(Composite compuest)
        {
            compuesto.Add(compuest);

        }

        public override string Mostrar(int depth)
        {
            try
            {


                foreach (Composite item in compuesto)
                {



                    resultado = resultado + string.Concat(Enumerable.Repeat("-", depth)) + item.Mostrar(depth + 1) + Environment.NewLine;


                }
            }
            catch (Exception e)
            {
                
            }


            return resultado;
        }
        public List<string> lista = new List<string>();
        String resultado;
        public override string Display(int depth)

        {
            resultado = "+" + Environment.NewLine;

            foreach (Composite item in compuesto)
            {


                resultado = resultado + string.Concat(Enumerable.Repeat("-", depth)) + item.Mostrar(depth + 1) + Environment.NewLine;
            }

            return resultado;
        }
    }
}
