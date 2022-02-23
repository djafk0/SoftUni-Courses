using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidationService validator;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(
            FootballManagerDbContext data,
            IValidationService validator,
            IPasswordHasher passwordHasher)
        {
            this.data = data;
            this.validator = validator;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register()
        {
            if (this.User.IsAuthenticated)
            {
                return Error("You are already registered in.");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormModel model)
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

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                return Error("You are already logged in.");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Incorect username and password.");
            }

            SignIn(userId);

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            ////This looks better than error 401(authorize attribute)
            //if (!this.User.IsAuthenticated)
            //{
            //    return Redirect("/Users/Login");
            //}

            SignOut();

            return Redirect("/");
        }
    }
}
