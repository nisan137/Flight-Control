using System.Text.Json;
using Flight_Control_Logic.ModelsDto;
using Flight_Control_Logic.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Flight_Control_Logic.BLogic
{
	public class Station
	{
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        SemaphoreSlim sem = new(1);        //lock (locker) אובייקט סינכרון כמו 
        private readonly IHubContext<AirportHub> hub;

        public Station(int id, IHubContext<AirportHub> hub)
        {
            Id = id;
            this.hub = hub;
        }

        public async Task<Station> Enter(Flight flight, CancellationTokenSource cts)// מטוס אחד מתפצל לכמה מטוסים ,וברגע שהוא מצליח להיכנס לתחנה אחת כל שאר הפיצולים של אותו מטוס מתבטלים
        {
            await sem.WaitAsync(cts.Token); //מטוס נכנס וסגר אחריו את הדלת
            cts.Cancel();
            this.Flight = flight;
            await SentToClient(flight.Id);
            Console.WriteLine($"Flight: {Flight.Id} - Enter station: {Id}");
            return this;
        }

        private async Task SentToClient(int flightID)
        {
            var sUi = new StationUI(Id, new FlightUI(flightID));//send to UI the station ID, and flight ID.
            var json = JsonSerializer.Serialize(sUi);//sending as json.
            await hub.Clients.All.SendAsync("ReceiveStation", json);
        }

        public async void Exit()
        {
            Console.WriteLine($"Flight: {Flight?.Id} - Exit station: {Id}");
            this.Flight = null; // רוקנו את התחנה
            await SentToClient(0);//מעביר 0 לתצוגה כי זה מייצג שם שהמטוס לא מוצג
            sem.Release(); //המטוס יצא מהתחנה 
        }
    }
}