using System;
using System.Collections.Generic;

namespace TaskDAL.Repositpry
{
    interface IRepository<T> : IDisposable
    {
        int Add(T entity);
        int Save(T entity);
        T GetOne(int? id);
        List<T> GetAll();
        int Delete(int id);
    }
}
