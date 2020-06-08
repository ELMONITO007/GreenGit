using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GreenElectric.Data.Servicios.Bitacora;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GreenElectric.Data.Servicios.Bitacora
{
    public class BitacoraDAC : DataAccessComponent, IRepository<EE.Servicios.Bitacora.Bitacora>
    {
        public EE.Servicios.Bitacora.Bitacora LoadCategoria(IDataReader dr)
        {
            EE.Servicios.Bitacora.Bitacora bitacora = new EE.Servicios.Bitacora.Bitacora();
            bitacora.Id = GetDataValue<int>(dr, "ID_Bitacora");
            bitacora.descripcion = GetDataValue<string>(dr, "Descripcion");
            bitacora.evento.Id = GetDataValue<int>(dr, "ID_Evento");
            bitacora.evento.eventoBitacora = GetDataValue<string>(dr, "Evento");
            bitacora.digitoVerificadorHorizontal = GetDataValue<string>(dr, "DigitoVerificadorH");
            bitacora.fecha = GetDataValue<DateTime>(dr, "fecha");
            bitacora.usuario.Id= GetDataValue<int>(dr, "ID_Usuario");
            bitacora.usuario.nombreUsuario = GetDataValue<string>(dr, "NombreUsuario");
            

            return bitacora;
        }



        public EE.Servicios.Bitacora.Bitacora Create(EE.Servicios.Bitacora.Bitacora entity)
        {
            const string SQL_STATEMENT = " insert into Bitacora(ID_Evento, ID_Usuario, Fecha, Descripcion, DigitoVerificadorH,activo)values(@ID_Evento, @ID_Usuario, @Fecha, @Descripcion, @DigitoVerificadorH,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.DateTime, entity.fecha);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, entity.descripcion);
                db.AddInParameter(cmd, "@ID_Evento", DbType.Int16, entity.evento.Id);
                db.AddInParameter(cmd, "@ID_Usuario", DbType.Int16, entity.usuario.Id);
                db.AddInParameter(cmd, "@DigitoVerificadorH", DbType.String, entity.digitoVerificadorHorizontal);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
      

            return entity;
           
            
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Bitacora set activo=0 where ID_Bitacora=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

       

        public List<EE.Servicios.Bitacora.Bitacora> Read()
        {
            const string SQL_STATEMENT = "select b.ID_Bitacora, b.Descripcion,b.Fecha,b.DigitoVerificadorH,u.ID_Usuario,u.NombreUsuario,eb.ID_Evento,eb.Evento from Bitacora as b inner join Usuario as u on b.ID_Usuario=u.ID_Usuario inner join EventoBitacora as eb on eb.ID_Evento=b.ID_Evento where b.activo=1";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            List<EE.Servicios.Bitacora.Bitacora> result = new List<EE.Servicios.Bitacora.Bitacora>();

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        EE.Servicios.Bitacora.Bitacora bitacora = LoadCategoria(dr);
                        result.Add(bitacora);
                    }
                }
            }
            return result;
        }

        public EE.Servicios.Bitacora.Bitacora ReadBy(int id)
        {
            const string SQL_STATEMENT = "select b.ID_Bitacora, b.Descripcion,b.Fecha,b.DigitoVerificadorH,u.ID_Usuario,u.NombreUsuario,eb.ID_Evento,eb.Evento from Bitacora as b inner join Usuario as u on b.ID_Usuario=u.ID_Usuario inner join EventoBitacora as eb on eb.ID_Evento=b.ID_Evento where b.activo=1 and ID_Bitacora=@Id";
            EE.Servicios.Bitacora.Bitacora objeto = new EE.Servicios.Bitacora.Bitacora();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        objeto = LoadCategoria(dr);
                    }
                }

            }
            return objeto;
        }

        public void Update(EE.Servicios.Bitacora.Bitacora entity)
        {
            throw new NotImplementedException();
        }
    }
}
