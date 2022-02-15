using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly SharedTripDbContext data;
        private readonly IValidator validator;

        public TripsController(
            SharedTripDbContext data, 
            IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.data
                .Trips
                .Select(t => new AllTripsViewModel
                {
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    TripId = t.Id
                });

            return View(trips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [HttpPost]
        public HttpResponse Add(TripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm", 
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var departureTime);

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Description = model.Description,
                DepartureTime = departureTime,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
            };

            data.Trips.Add(trip);

            data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.data
                .Trips
                .FirstOrDefault(t => t.Id == tripId);

            var model = new TripFormModel
            {
                Id = tripId,
                ImagePath = trip.ImagePath,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString("MM/dd/yyyy HH:mm"),
                Seats = trip.Seats,
                Description = trip.Description
            };

            return View(model);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
           var exists = this.data
                .UserTrips
                .FirstOrDefault(x => x.UserId == this.User.Id && x.TripId == tripId);
            
            if (exists != null)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }
            
            var user = this.data
                 .Users
                 .FirstOrDefault(u => u.Id == this.User.Id);

            var trip = this.data
                .Trips
                .FirstOrDefault(t => t.Id == tripId);

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                Trip = trip,
                User = user,
                UserId = this.User.Id
            });

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
