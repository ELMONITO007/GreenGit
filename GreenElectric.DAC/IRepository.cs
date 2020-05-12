using GreenElectric.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenElectric.DAC
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
