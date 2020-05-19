using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GreenElectric.EE.Servicios.Encriptado
{

 public   class EncriptarSHA256 : Enciptador 
    {
        public EncriptarSHA256(string _valorInicial)
        {
            valorInicial = _valorInicial;
        }

        public override string Hashear()
        {
            SHA256 SHA256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(this.valorInicial);
            byte[] hash = SHA256.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= hash.Length - 1; i++)
            {
                stringBuilder.Append(hash[i].ToString("X2"));
            }

            return stringBuilder.ToString();
        }
    }
}
