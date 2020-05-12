
using Microsoft.Practices.EnterpriseLibrary.Data;
using GreenElectric.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreenElectric.DAC
{
  public  class TipoDomicilioDAC :  DataAccessComponent, IRepository<TipoDomicilio>
    {
        private TipoDomicilio LoadTipoDomicilio(IDataReader dr)
        {
            TipoDomicilio    tipoDomicilio = new TipoDomicilio();
            tipoDomicilio.Id = GetDataValue<int>(dr, "Id");
            tipoDomicilio.Tipo = GetDataValue<string>(dr, "Tipo");
            tipoDomicilio.Descripcion = GetDataValue<string>(dr, "Descripcion");
            return tipoDomicilio;
        }
        public TipoDomicilio Create(TipoDomicilio entity)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoDomicilio (Tipo,Descripcion,Activo) VALUES(@Tipo,@Descripcion,1)";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Tipo", DbType.AnsiString, entity.Tipo);
                db.AddInParameter(cmd, "@Tipo", DbType.AnsiString, entity.Tipo);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update TipoDomicilio set Activo=0 where ID_TipoDomicilio=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);

            }
        }

        public List<TipoDomicilio> Read()
        {
            const string SQL_STATEMENT = "select Id_TipoDomicilio, Tipo,Descripcion from TipoDomicilio where activo=1";

            List<TipoDomicilio> result = new List<TipoDomicilio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoDomicilio tipoDomicilio = LoadTipoDomicilio(dr);
                        result.Add(tipoDomicilio);
                    }
                }
            }
            return result;
        }

        public TipoDomicilio ReadBy(int id)
        {
            const string SQL_STATEMENT = "select Id_TipoDomicilio, Tipo,Descripcion from TipoDomicilio  where activo=1 and Id_TipoDomicilio=@Id";
            TipoDomicilio tipoDomicilio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        tipoDomicilio = LoadTipoDomicilio(dr);

                    }
                }
                return tipoDomicilio;
            }
        }

        public void Update(TipoDomicilio entity)
        {
            const string SQL_STATEMENT = "update TipoDomicilio set Tipo=@Tipo Descripcion=@Descripcion where ID_TipoPregunta=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@Tipo", DbType.String, entity.Tipo);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, entity.Descripcion);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
