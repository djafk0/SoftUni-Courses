using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Data;
using SMS.Models;
using SMS.Services;
using SMS.ViewModels;
using SMS.ViewModels.Users;
using System.Linq;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly SMSDbContext data;
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            SMSDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Redirect("/");
            }
        
            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormViewModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' email already exists");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var cart = new Cart();

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
                Cart = cart,
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(UserLoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Incorect username and password...");
            }

            SignIn(userId);

            return Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                return Redirect("/");
            }

            SignOut();

            return Redirect("/");
        }
    }
}
