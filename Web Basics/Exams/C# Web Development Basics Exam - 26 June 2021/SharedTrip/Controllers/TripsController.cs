namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var allTrips = this.data.Trips.ToList();

            return View(allTrips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripFormModel input)
        {
            var inputErrors = this.validator.ValidateTrip(input);

            if (inputErrors.Any())
            {
                return Error(inputErrors);
            }

            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = DateTime.Parse(input.DepartureTime),
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description
            };

            data.Trips.Add(trip);
            data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var viewModel = this.data
                .Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    Id = tripId,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    ImagePath = t.ImagePath,
                    Seats = t.Seats - t.UserTrips.Count,
                    Description = t.Description,

                })
                .FirstOrDefault();

            return View(viewModel);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var userId = this.data
                .Users
                .Where(u => u.Id == this.User.Id)
                .Select(u => u.Id)
                .FirstOrDefault();

            var isUserInTrip = this.data
                .UserTrips
                .Any(ut => ut.UserId == userId && ut.TripId == tripId);

            if (isUserInTrip)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            data.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                UserId = userId
            });

            data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
