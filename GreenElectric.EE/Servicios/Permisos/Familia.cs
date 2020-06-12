using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenElectric.EE.Servicios.Permisos
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


                foreach (Familia item in compuesto)
                {



                    resultado = resultado + string.Concat(Enumerable.Repeat("-", depth)) + item.Mostrar(depth + 1) + item.nombre+Environment.NewLine;


                }
            }
            catch (Exception e)
            {
                
            }


            return resultado;
        }
        public string lista;
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
