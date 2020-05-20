using GreenElectric.EE.Servicios.Encriptado;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.EE.Servicios.DigitoVerificador
{
   public class DigitoVerificadorH : Entity
    {
        public DigitoVerificadorH()

        {

        }



        public  string getDigitoEncriptado(object unObjeto)
        {
            string digitoAEncriptar = DVGReflection.GetDVH(unObjeto);
           EncriptarSHA5 e = new Encriptado.EncriptarSHA5(digitoAEncriptar);
            string digitoEncriptado = e.Hashear();
            return digitoEncriptado;
        }
    }
}
