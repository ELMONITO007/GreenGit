using GreenElectric.EE.Servicios.Permisos;
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
    public class FamiliaDac : DataAccessComponent, IRepository<Familia>
    {
        public Familia LoadCategoria(IDataReader dr)
        {
            Familia familia = new Familia();
            familia.Id = GetDataValue<int>(dr, "ID_CompositeFamilia");
            familia.nombre = GetDataValue<string>(dr, "Nombre");
            familia.descripcion=GetDataValue<string>(dr, "descripcion");
            

            return familia;
        }
        public Familia Create(Familia entity)

        {
            
            const string SQL_STATEMENT = " insert into Composite (Nombre,Descripcion,Activo)values(@Nombre,@Descripcion,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.String, entity.nombre);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, entity.descripcion);
          
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));

            }

            CreateFamilia(entity);
            return entity;
        }
        public Familia CreateFamilia(Familia entity)

        {

            const string SQL_STATEMENT = " insert into CompositeFamilia(ID_CompositeFamilia)values(@Id_Composite)";
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

      

        public List<Familia> Read()
        {

            const string SQL_STATEMENT = "select distinct Nombre,ID_CompositeFamilia,Descripcion from Composite as c join CompositeFamilia as cf on c.ID_Composite =cf.ID_CompositeFamilia where Activo=1";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            List<Familia> result = new List<Familia>();

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Familia familia = LoadCategoria(dr);
                        result.Add(familia);
                    }
                }
            }
            return result;
        }

        public Familia ReadBy(int id)
        {
            const string SQL_STATEMENT = "select top 1 Nombre,ID_CompositeFamilia,Descripcion from Composite as c join CompositeFamilia as cf on c.ID_Composite = cf.ID_CompositeFamilia where Activo = 1 and ID_CompositeFamilia=@Id order by ID_CompositeFamilia desc";
            Familia familia = new Familia();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        familia = LoadCategoria(dr);
                    }
                }

            }
            return familia;
        }

        public void Update(Familia entity)
        {
            const string SQL_STATEMENT = "update Composite set Nombre=@Nombre,Descripcion=@Descripcion where ID_Composite=@Id)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@id", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@Nombre", DbType.String, entity.nombre);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, entity.descripcion);

                db.ExecuteNonQuery(cmd);

            }

            CreateFamilia(entity);
            
        }
        public List<Familia> ReadPatente(int id)
        {

             string SQL_STATEMENT = "select Nombre from Composite as c join CompositeFamilia as cf on c.ID_Composite=cf.ID_CompositePatente where ID_CompositeFamilia=(select distinct ID_Composite from Composite as c join CompositeFamilia as cf on c.ID_Composite=cf.ID_CompositeFamilia where ID_Composite="+ id + "and Activo=1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            List<Familia> result = new List<Familia>();

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Familia familia = LoadCategoria(dr);
                        result.Add(familia);
                    }
                }
            }
            return result;
        }


        #region Composite
        public Familia LoadCategoriaNombre(IDataReader dr)
        {
            Familia familia = new Familia();
            familia.Id = GetDataValue<int>(dr, "Id_Composite");
            familia.nombre = GetDataValue<string>(dr, "Nombre");

            return familia;
        }

        public List<Familia> ObtenerPermisosDeUnaFamilia(int id)
        {
            const string SQL_STATEMENT = "select Nombre,ID_Composite from Composite as c join CompositeFamilia as cf on c.ID_Composite=cf.ID_CompositePatente where ID_CompositeFamilia=(select distinct ID_Composite from Composite as c join CompositeFamilia as cf on c.ID_Composite=cf.ID_CompositeFamilia where ID_Composite=@id)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            List<Familia> result = new List<Familia>();

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Familia backup = LoadCategoriaNombre(dr);
                        result.Add(backup);
                    }
                }
            }

            return result;

        }

        #endregion
    }
}
