using Ecommerce.BLL.Interfaces;
using Ecommerce.DAL.Contexts;
using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext context;

        public ProductRepository(EcommerceDbContext context)
        {
            this.context = context;
        }
        public int ProductsInStock(int? Id)
        {
            var Data = context.Products.Where(P => P.Id== Id).Select(P=> P.Quantity).FirstOrDefault();
            return Data;
        }
    }
}
