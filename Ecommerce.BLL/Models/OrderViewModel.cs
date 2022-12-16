using Ecommerce.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Models
{
    public class OrderViewModel
    {


        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public IEnumerable<int> ProductId { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}