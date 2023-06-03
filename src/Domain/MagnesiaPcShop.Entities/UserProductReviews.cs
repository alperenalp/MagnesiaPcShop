using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Entities
{
    public class UserProductReviews
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public string Review { get; set; }
    }
}
