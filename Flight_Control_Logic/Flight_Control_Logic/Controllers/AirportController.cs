using Flight_Control_Logic.BLogic;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Control_Logic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly FlightControl logic;
        private readonly RouteProvider routeProvider;

        public AirportController(FlightControl logic, RouteProvider routeProvider)
        {
            this.logic = logic;
            this.routeProvider = routeProvider;
        }

        [HttpGet("AddFlight/{flight}")]
        public string AddFlight(int flight)
        {
            var route = routeProvider.Leanding;
            _ = logic.AddFlight(flight, route);
            return $"flight number {flight} added";
        }
    }
}