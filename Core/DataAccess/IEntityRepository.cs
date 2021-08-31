using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<Type> where Type:class,IEntity
    {
        List<Type> GetAll(Expression<Func<Type, bool>> filter = null);

        Type Get(Expression<Func<Type, bool>> filter);

        void Add(Type entity);

        void Update(Type entity);

        void Delete(Type entity);
    }
}
