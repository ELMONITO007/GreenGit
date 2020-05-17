using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.DigitoVerificador
{
   public class DigitoVerificadorH
    {
        public DigitoVerificadorH()

        {

        }



        public static string getDigitoEncriptado(object unObjeto)
        {
            string digitoAEncriptar = DVGReflection.GetDVH(unObjeto);
            EEseguridad.Encriptado.EncriptarSHA5 e = new Encriptado.EncriptarSHA5(digitoAEncriptar);
            string digitoEncriptado = e.Hashear();
            return digitoEncriptado;
        }
    }
}
