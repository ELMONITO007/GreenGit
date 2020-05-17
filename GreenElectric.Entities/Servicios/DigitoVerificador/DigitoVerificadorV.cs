using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.DigitoVerificador
{
  public  class DigitoVerificadorV
    {
        public string nombreTabla { get; set; }
        public string DVV { get; set; }
        public string DVH { get; set; }
   

        public DigitoVerificadorV(string _tabla, string _DVV, string _DVH)
        {
            nombreTabla = _tabla;
            DVV = _DVV;

            DVH = _DVH;
        }
        public DigitoVerificadorV()
        {

        }
    }
}
