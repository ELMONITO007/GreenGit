using GreenElectric.EE.Servicios.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GreenElectric.EE.Servicios.Bitacora
{
   public class Bitacora : Entity
    {
        public Bitacora(DateTime _fecha, EventoBitacora _evento, Usuario _usuario, string _descripcion, string DVH)
        {
            fecha = _fecha;
            evento = _evento;
            usuario = _usuario;
            descripcion = _descripcion;
            digitoVerificadorHorizontal = DVH;
            evento=new EventoBitacora();
            usuario = new Usuario();
        }
        public Bitacora()
        {
            evento = new EventoBitacora();
            usuario = new Usuario();
        }
        [DisplayName("Fecha")]
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
        [DisplayName("Descripción")]
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

        public List<Usuario> usuarios = new List<Usuario>();
        public List<EventoBitacora> eventoBitacoras = new List<EventoBitacora>();
        public List<Bitacora> bitacoras = new List<Bitacora>();
    }
}

