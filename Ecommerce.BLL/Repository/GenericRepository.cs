using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcommerceDbContext context;

        public GenericRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(T obj)
        {
            context.Set<T>().Add(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int ? Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }

        public async Task<int> Update(T obj)
        {
            context.Set<T>().Update(obj);
            return await context.SaveChangesAsync();
        }
    }
}
