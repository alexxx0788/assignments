using System;
using System.Collections.Generic;

namespace ShepherdCoAPI.Repository.Db
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetList();
        T GetEntryById(int id);
        bool Insert(T item);
        bool Update(T item, int id);
        bool Delete(int id);
        bool DeleteAll();
    }
}
