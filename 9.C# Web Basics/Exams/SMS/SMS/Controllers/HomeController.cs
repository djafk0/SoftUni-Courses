using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.ViewModels.Users;
using System.Linq;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly SMSDbContext data;

        public HomeController(SMSDbContext data)
        {
            this.data = data;
        }

        public HttpResponse Index()
        {
            if (!this.User.IsAuthenticated)
            {
                return View();
            }

            var username = this.data
                .Users
                .FirstOrDefault(u => u.Id == this.User.Id)
                .Username;

            var products = this.data
                .Products
                .Select(p => new ProductListingViewModel
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.Price
                })
                .ToList();

            var model = new UserListingViewModel
            {
                Username = username,
                Products = products
            };

            return View(model, "/Home/IndexLoggedIn");
        }
    }
}