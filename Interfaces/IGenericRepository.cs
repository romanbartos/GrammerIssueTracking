using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammerIssueTracking.Interfaces
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
