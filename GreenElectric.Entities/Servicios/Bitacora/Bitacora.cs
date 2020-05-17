using GreenElectric.Entities.Servicios.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Entities.Servicios.Bitacora
{
   public class Bitacora
    {
        public Bitacora(DateTime _fecha, EventoBitacora _evento, Usuario _usuario, string _descripcion, string DVH)
        {
            fecha = _fecha;
            evento = _evento;
            usuario = _usuario;
            descripcion = _descripcion;
            digitoVerificadorHorizontal = DVH;
        }
      public  DateTime fecha
        {
            get;
            set;
        }
        public EventoBitacora evento
        {
            get;
            set;
        }
        public Usuario usuario
        {
            get;
            set;
        }

        public string descripcion
        {
            get;
            set;
        }
        public string digitoVerificadorHorizontal
        {
            get;
            set;
        }

       
    }
}

