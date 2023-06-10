using MagnesiaBilgisayar.Application.Services;
using MagnesiaPcShop.DataTransferObjects.Requests.Order;
using MagnesiaPcShop.Entities;
using MagnesiaPcShop.Infrastructure.Repositories;
using MagnesiaPcShop.Mvc.Extensions;
using MagnesiaPcShop.Mvc.Models;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MagnesiaPcShop.Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CreateOrder()
        {
            var productCollection = getProductCollectionFromSession();
            if (productCollection.TotalProductCount() > 0)
            {
                return View();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateNewOrderRequest request)
        {
            // Test amaclidir silinecek
            var productCollection = getProductCollectionFromSession();
            if (ModelState.IsValid)
            {
                var order = new Order();
                string userEmail = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                order.UserId = await _userService.GetUserIdByEmailAsync(userEmail);
                order.TotalPrice = productCollection.TotalProductPrice();
                order.Date = DateTime.Now;
                order.Address = request.Address;
                order.ShipperId = 1;
                order.Products = new List<OrderDetails>();
                foreach (var item in productCollection.ProductItems)
                {
                    var orderDetails = new OrderDetails();
                    orderDetails.OrderId = order.Id;
                    orderDetails.ProductId = item.Product.Id;
                    orderDetails.Quantity = item.Quantity;
                    orderDetails.UnitPrice = item.Product.Price;

                    order.Products.Add(orderDetails);
                }
                await _orderService.CreateOrderAsync(order);
                productCollection.ClearAll();
                saveToSession(productCollection);
                return View("Completed");
            }
            return View();
        }

        private ProductCollection getProductCollectionFromSession()
        {
            return HttpContext.Session.GetJson<ProductCollection>("basket") ?? new ProductCollection();
        }

        private void saveToSession(ProductCollection productCollection)
        {
            HttpContext.Session.SetJson("basket", productCollection);
        }
    }
}
