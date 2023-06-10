using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.DataTransferObjects.Requests.Order
{
    public class CreateNewOrderRequest
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; } = 0;
        [Required(ErrorMessage ="Address giriniz.")]
        public string Address { get; set; }

        public int ShipperId { get; set; } = 1;
        public int UserId { get; set; }
    }
}
