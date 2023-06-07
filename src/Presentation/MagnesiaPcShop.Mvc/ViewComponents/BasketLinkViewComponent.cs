using MagnesiaPcShop.Mvc.Extensions;
using MagnesiaPcShop.Mvc.Models;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagnesiaPcShop.Mvc.ViewComponents
{
    public class BasketLinkViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var productCollection = HttpContext.Session.GetJson<ProductCollection>("basket");
            return View(productCollection);
        }
    }
}
