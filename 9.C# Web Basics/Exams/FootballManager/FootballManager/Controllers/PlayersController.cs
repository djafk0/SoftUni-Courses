using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Players;
using Microsoft.EntityFrameworkCore;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidationService validator;

        public PlayersController(
            FootballManagerDbContext data,
            IValidationService validator)
        {
            this.data = data;
            this.validator = validator;
        }

        ////This looks better than error 401(authorize attribute) and can be used inside all of these Get Methods
        //if (!this.User.IsAuthenticated)
        //{
        //    return Redirect("/Users/Login");
        //}

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        public HttpResponse Add(PlayerFormModel model)
        {
            var modelErrors = this.validator.ValidatePlayer(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = byte.Parse(model.Speed),
                Endurance = byte.Parse(model.Endurance),
                Description = model.Description,
            };

            data.Players.Add(player);

            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var players = this.data
                .Players
                .Select(p => new PlayerListingViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Endurance = p.Endurance,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed
                })
                .ToList();

            return View(players);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var collection = this.data
                .UserPlayers
                .Where(u => u.UserId == this.User.Id)
                .Select(p => new PlayerListingViewModel
                {
                    Id = p.Player.Id,
                    Description = p.Player.Description,
                    Endurance = p.Player.Endurance,
                    FullName = p.Player.FullName,
                    Position = p.Player.Position,
                    ImageUrl = p.Player.ImageUrl,
                    Speed = p.Player.Speed
                })
                .ToList();


            return View(collection);
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var player = this.data
                .Players
                .FirstOrDefault(p => p.Id == playerId);

            var user = GetUser();

            var userPlayer = new UserPlayer
            {
                Player = player,
                User = user,
                PlayerId = playerId,
                UserId = this.User.Id
            };

            if (this.data.UserPlayers.Contains(userPlayer))
            {
                return Redirect("/Players/All");
            }

            user.UserPlayers.Add(userPlayer);

            data.SaveChanges();

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            var userPlayerToRemove = this.data
                .UserPlayers
                .FirstOrDefault(up => up.UserId == this.User.Id && up.PlayerId == playerId);

            var user = GetUser();

            user.UserPlayers.Remove(userPlayerToRemove);

            data.SaveChanges();

            return Redirect("/Players/Collection");
        }

        private User GetUser()
        {
            return this.data
                    .Users
                    .FirstOrDefault(u => u.Id == this.User.Id);
        }
    }
}
