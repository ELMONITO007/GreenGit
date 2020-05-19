using GreenElectric.EE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GreenElectric.Data
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity LoadCategoria(IDataReader dr);
        TEntity Create(TEntity entity);
        List<TEntity> Read();
        TEntity ReadBy(int id);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
