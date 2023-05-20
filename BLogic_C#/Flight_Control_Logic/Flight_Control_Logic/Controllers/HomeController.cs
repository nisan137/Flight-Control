using Flight_Control_Logic.BLogic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flight_Control_Logic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly FlightControl logic;
        private readonly RouteProvider routeProvider;

        public HomeController(FlightControl logic, RouteProvider routeProvider)
        {
            this.logic = logic;
            this.routeProvider = routeProvider;
        }

        [HttpGet("AddFlight/{flight}")]
        public string AddFlight(int flight)
        {
            var route = routeProvider.Leanding;
            logic.AddFlight(flight, route);
            return $"flight number {flight} added";
        }
    }
}