using GreenElectric.EE.Servicios.Bitacora;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Data.Servicios.Bitacora
{
    public class EventoBitacoraDAC : DataAccessComponent, IRepository<EE.Servicios.Bitacora.EventoBitacora>
    {
        public EventoBitacora LoadCategoria(IDataReader dr)
        {
            EventoBitacora eventoBitacora = new EventoBitacora();
            eventoBitacora.eventoBitacora = GetDataValue<string>(dr, "Evento");
            eventoBitacora.Id = GetDataValue<int>(dr, "ID_Evento");
            return eventoBitacora;
        }
        public EventoBitacora Create(EventoBitacora entity)
        {
            const string SQL_STATEMENT = "insert into EventoBitacora(Evento,Activo)values(@Evento,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Evento", DbType.String, entity.eventoBitacora);
                
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }


          
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update EventoBitacora set activo=0 where ID_Evento=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        

        public List<EventoBitacora> Read()
        {
            const string SQL_STATEMENT = "select ID_Evento,Evento from EventoBitacora where activo=1";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            List<EventoBitacora> result = new List<EventoBitacora>();

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        EventoBitacora bitacora = LoadCategoria(dr);
                   
                        result.Add(bitacora);
                    }
                }
            }
            return result;
        }

        public EventoBitacora ReadBy(int id)
        {
            const string SQL_STATEMENT = "select ID_Evento,Evento from EventoBitacora where activo=1 and ID_Evento=@Id";
            EventoBitacora objeto= new EventoBitacora();
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

        public void Update(EventoBitacora entity)
        {
            try
            {
                const string SQL_STATEMENT = "update EventoBitacora set Evento=@Evento where Id_Evento=@Id";
                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Evento", DbType.String, entity.eventoBitacora);
                    db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                    db.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}
