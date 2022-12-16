using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetById(int ? Id);
        public Task<IEnumerable<T>> GetAll();
        public Task<int> Create(T obj);
        public Task<int> Update(T obj);
        public Task<int> Delete(T obj);
    }
}
