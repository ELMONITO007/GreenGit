using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GreenElectric.EE.Servicios.Encriptado
{
 public   class EncriptarSHA5 : Enciptador
    {
        public EncriptarSHA5(string _valorInicial)
        {
            valorEncriptado = "";
            valorInicial = _valorInicial;
        }
        public override string Hashear()
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(valorInicial);

            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
    }
}
