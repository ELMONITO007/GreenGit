using GreenElectric.EE;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.Negocio
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Create(TEntity entity);
        List<TEntity> Read();
        TEntity ReadBy(int id);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
