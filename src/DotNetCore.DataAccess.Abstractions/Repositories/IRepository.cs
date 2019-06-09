using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.DataAccess.Abstractions.Repositories
{
    public interface IRepository<TEntity, TKey> : IEntityRepository<TEntity> where TEntity : class, IEntity<TKey>, new()
    {
        void Delete(params TKey[] ids);
        TEntity Get(TKey id);
    }

    public interface IRepository<TEntity>: IRepository<TEntity, int> where TEntity : class, IEntity<int>, new()
    {
    }
}
