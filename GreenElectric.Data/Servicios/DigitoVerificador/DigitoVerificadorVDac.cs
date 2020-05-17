using GreenElectric.Entities.Servicios.DigitoVerificador;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Data.Servicios.DigitoVerificador
{
    public class DigitoVerificadorVDac : DataAccessComponent, IRepository<DigitoVerificadorV>
    {
        public DigitoVerificadorV LoadCategoria(IDataReader dr)
        {
            DigitoVerificadorV digitoVerificadorV = new DigitoVerificadorV();
            digitoVerificadorV.Id = GetDataValue<int>(dr, "ID_DigitoVerificadorVertical");
            digitoVerificadorV.nombreTabla = GetDataValue<string>(dr, "nombreTabla");
            digitoVerificadorV.DVH = GetDataValue<string>(dr, "DigitoVerificadorH");
            digitoVerificadorV.DVV = GetDataValue<string>(dr, "DigitoVerificadorV");

            return digitoVerificadorV;
        }
        public DigitoVerificadorV Create(DigitoVerificadorV entity)
        {
            const string SQL_STATEMENT = "insert into DigitoVerificadorVertical(nombreTabla, DigitoVerificadorV, DigitoVerificadorH)values(@nombreTabla,@DigitoVerificadorV,@DigitoVerificadorH) ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@nombreTabla", DbType.DateTime, entity.nombreTabla);
                db.AddInParameter(cmd, "@DigitoVerificadorV", DbType.String, entity.DVV);
                db.AddInParameter(cmd, "@DigitoVerificadorH", DbType.String, entity.DVH);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
          

            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

      

        public List<DigitoVerificadorV> Read()
        {
            throw new NotImplementedException();
        }

        public DigitoVerificadorV ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DigitoVerificadorV entity)
        {
            throw new NotImplementedException();
        }
        public DigitoVerificadorV ReadBy(string Tabla)
        {

            const string SQL_STATEMENT = "select top 1 ID_DigitoVerificadorVertical,NombreTabla,DigitoVerificadorV,DigitoVerificadorH from DigitoVerificadorVertical where NombreTabla=@tabla order by  ID_DigitoVerificadorVertical Desc";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            DigitoVerificadorV result = new DigitoVerificadorV();
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@tabla", DbType.String, Tabla);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        result = LoadCategoria(dr);
                    }
                }

            }
            return result;
        }

    }
}
