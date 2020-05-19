using GreenElectric.EE.Servicios.Login;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenElectric.Data.Servicios.Login
{
    public class UsuarioDAC : DataAccessComponent, IRepository<Usuario>
    {
        public Usuario LoadCategoria(IDataReader dr)
        {

            Usuario usuario = new Usuario();
            usuario.Id = GetDataValue<int>(dr, "ID_Usuario");
            usuario.nombreUsuario = GetDataValue<string>(dr, "nombreUsuario");
            usuario.contraseña = GetDataValue<string>(dr, "contraseña");
            usuario.digitoVerificadorH = GetDataValue<string>(dr, "DigitoVerificadorH");

            return usuario;
        }
        public Usuario Create(Usuario entity)
        {

            const string SQL_STATEMENT = "insert into Usuario(nombreUsuario, contraseña, DigitoVerificadorH,)values(@nombreUsuario,@contraseña,@DigitoVerificadorH) ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@nombreUsuario", DbType.DateTime, entity.nombreUsuario);
                db.AddInParameter(cmd, "@contraseña", DbType.String, entity.contraseña);
                db.AddInParameter(cmd, "@DigitoVerificadorH", DbType.String, entity.digitoVerificadorH);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            

            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "update Usuario set Hablitado=0 where ID_Usuario=@Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

   

        public List<Usuario> Read()
        {
            const string SQL_STATEMENT = "select * from usuario where Habilitado=1";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);

            List<Usuario> result = new List<Usuario>();

            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Usuario  usuario = LoadCategoria(dr);
                        result.Add(usuario);
                    }
                }
            }
            return result;
        }

        public Usuario ReadBy(int id)
        {

            const string SQL_STATEMENT = "select * from usuario where Habilitado=1 and ID_Usuario=@Id";
            Usuario usuario = new Usuario();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        usuario = LoadCategoria(dr);
                    }
                }

            }
            return usuario;
        }

        public void Update(Usuario entity)
        {
            const string SQL_STATEMENT = "update Usuario set NombreUsuario=@NombreUsuario,Contraseña=@Contraseña,DigitoVerificadorH=@DigitoVerificadorH where Id_Usuario=@IdID_Usuario";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ID_Usuario", DbType.Int32, entity.Id);
                db.AddInParameter(cmd, "@nombreUsuario", DbType.DateTime, entity.nombreUsuario);
                db.AddInParameter(cmd, "@contraseña", DbType.String, entity.contraseña);
                db.AddInParameter(cmd, "@DigitoVerificadorH", DbType.String, entity.digitoVerificadorH);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

        }
        public Usuario ReadBy(string nombreUsuario)
        {

            const string SQL_STATEMENT = "select top 1 * from usuario where Habilitado=1 and NombreUsuario=@Id order by Id_Usuario desc";
            Usuario usuario = new Usuario();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, nombreUsuario);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        usuario = LoadCategoria(dr);
                    }
                }

            }
            return usuario;
        }

    }
}
