using Microsoft.EntityFrameworkCore;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.ViewModels.Carts;
using System.Linq;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly SMSDbContext data;

        public CartsController(SMSDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse Details()
        {
            var cartId = this.data
                .Users
                .Where(u => u.Id == this.User.Id)
                .Select(u => u.CartId)
                .FirstOrDefault();

            var products = this.data
                .Products
                .Where(p => p.CartId == cartId)
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

            return View(products);
        }

        [Authorize]
        public HttpResponse AddProduct(string productId)
        {
            var product = this.data
                .Products
                .FirstOrDefault(p => p.Id == productId);

            this.data
                .Users
                .Where(c => c.Id == this.User.Id)
                .Select(u => u.Cart)
                .FirstOrDefault()
                .Products
                .Add(product);

            this.data.SaveChanges();

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Buy()
        {
            this.data
                .Users
                .Where(u => u.Id == this.User.Id)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault()
                .Cart
                .Products
                .Clear();

            this.data.SaveChanges();

            return Redirect("/");
        }
    }
}
