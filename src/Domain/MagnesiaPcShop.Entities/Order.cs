using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
        public Shipper Shipper { get; set; }
        public int ShipperId { get; set; }
        public List<OrderDetails> Products { get; set; }

    }
}
