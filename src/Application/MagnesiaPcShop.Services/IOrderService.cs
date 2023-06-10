using MagnesiaPcShop.DataTransferObjects.Requests.Order;
using MagnesiaPcShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order); //test
    }
}
