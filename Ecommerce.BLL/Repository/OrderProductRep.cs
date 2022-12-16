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
    public class OrderProductRep : IOrderProduct
    {
        private readonly EcommerceDbContext context;

        public OrderProductRep(EcommerceDbContext context)
        {
            this.context = context;
        }
        public void Create(int OrderId, int ProductId)
        {
            var data = new OrderProduct()
            {
                ProductId = ProductId, 
                OrderId = OrderId,
            };
            context.OrderProducts.Add(data);
            context.SaveChanges();
        }
    }
}
