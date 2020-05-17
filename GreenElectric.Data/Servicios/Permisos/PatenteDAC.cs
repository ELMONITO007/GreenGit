using GreenElectric.Entities.Servicios.Permisos;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Data.Servicios.Permisos
{
    public class PatenteDAC : DataAccessComponent, IRepository<Patente>
    {
        public Patente LoadCategoria(IDataReader dr)
        {

            Patente patente = new Patente();
            patente.Id = GetDataValue<int>(dr, "ID_CompositeFamilia");
            patente.nombre = GetDataValue<string>(dr, "Nombre");
            patente.descripcion = GetDataValue<string>(dr, "descripcion");


            return patente;
        }
        public Patente Create(Patente entity)
        {
            const string SQL_STATEMENT = " insert into Composite (Nombre,Descripcion,Activo)values(@Nombre,@Descripcion,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.DateTime, entity.nombre);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, entity.descripcion);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));

            }
            CreatePatente(entity);
           
            return entity;
        }

        public Patente CreatePatente(Patente entity)

        {

            const string SQL_STATEMENT = " insert into CompositeFamilia(ID_CompositePatente)values(@Id_Composite)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id_Composite", DbType.Int32, entity.Id);


                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));

            }


            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Composite set Activo=1 where ID_Composite=Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        

        public List<Patente> Read()
        {
            const string SQL_STATEMENT = "select distinct Nombre from Composite as c join CompositeFamilia as cf on c.ID_Composite =cf.ID_CompositePatente  where cf.ID_CompositeFamilia is null and Activo=1";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            List<Patente> result = new List<Patente>();

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Patente patente = LoadCategoria(dr);
                        result.Add(patente);
                    }
                }
            }
            return result;
        }

        public Patente ReadBy(int id)
        {
            const string SQL_STATEMENT = "select top 1 distinct  Nombre from Composite as c join CompositeFamilia as cf on c.ID_Composite =cf.ID_CompositePatente  where cf.ID_CompositeFamilia is null and Activo= and ID_CompositeFamilia=@Id order by ID_CompositePatente desc";
            Patente patente = new Patente();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        patente = LoadCategoria(dr);
                    }
                }

            }
            return patente;
        }

        public void Update(Patente entity)
        {
            const string SQL_STATEMENT = "update Composite set Nombre=@Nombre,Descripcion=@Descripcion where ID_Composite=@Id)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@Nombre", DbType.String, entity.nombre);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, entity.descripcion);

                db.ExecuteNonQuery(cmd);

            }
        }
    }
}
