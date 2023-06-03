using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.DataTransferObjects.Requests.Product
{
    public class CreateNewProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
