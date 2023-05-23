using Flight_Control_Logic.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Flight_Control_Logic.BLogic
{
	public class RouteProvider
	{
        public Route Leanding { get; private set; } = new();
        public Route Departure { get; private set; } = new();

        public RouteProvider(IHubContext<AirportHub> hub)
        { 
            Station s1 = new(1, hub);
            Station s2 = new(2, hub);
            Station s3 = new(3, hub);
            Station s4 = new(4, hub);
            Station s5 = new(5, hub);  
            Station s6 = new(6, hub);
            Station s7 = new(7, hub);
            Station s8 = new(8, hub);
            Station s9 = new(9, hub);
            

            Leanding.Add(s1);
            Leanding.Add(s2);
            Leanding.Add(s3);
            Leanding.Add(s4);
            Leanding.Add(s5);
            Leanding.Add(s6);
            Leanding.Add(s7);

            Leanding.ConnectToStation(s1, s2);
            Leanding.ConnectToStation(s2, s3);
            Leanding.ConnectToStation(s3, s4);
            Leanding.ConnectToStation(s4, s5);
            Leanding.ConnectToStation(s5, s6);
            Leanding.ConnectToStation(s5, s7);


            Departure.Add(s7);
            Departure.Add(s8);
            Departure.Add(s4);
            Departure.Add(s9);

            Departure.ConnectToStation(s7, s8);
            Departure.ConnectToStation(s8, s4);
            Departure.ConnectToStation(s4, s9);
        }
    }
}

