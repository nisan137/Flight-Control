namespace Flight_Control_Logic.BLogic
{
	public class FlightControl
	{
        public async Task AddFlight(int flightId, Route route)
        {
            var f = new Flight(flightId);
            await f.Run(route);
        }  
	}
}