using AutoMapper;
using MagnesiaPcShop.DataTransferObjects.Requests.Order;
using MagnesiaPcShop.Entities;
using MagnesiaPcShop.Infrastructure.Repositories;
using MagnesiaPcShop.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(Order order) //test
        {
           await _orderRepository.CreateOrderAsync(order);
        }

    }
}
