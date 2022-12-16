using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Entities
{
    public class Order
    {
        public Order()
        {
            this.OrderTime= DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
    }
}
