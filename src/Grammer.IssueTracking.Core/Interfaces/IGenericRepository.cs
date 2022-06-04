using System.Collections.Generic;

namespace Grammer.IssueTracking.Core.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Insert(T obj);
        public void Update(T obj);
        public void Delete(T obj);
    }
}
