using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    public class OrderProduct
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product product { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order order { get; set; }
    }
}
