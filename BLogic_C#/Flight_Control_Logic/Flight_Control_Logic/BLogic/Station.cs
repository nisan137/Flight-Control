using System;
namespace Flight_Control_Logic.BLogic
{
	public class Station
	{
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        SemaphoreSlim sem = new(1);        //lock (locker) אובייקט סינכרון כמו 

        public Station(int id)
        {
            Id = id;
        }

        public async Task<Station> Enter(Flight flight, CancellationTokenSource cts)// מטוס אחד מתפצל לכמה מטוסים ,וברגע שהוא מצליח להיכנס לתחנה אחת כל שאר הפיצולים של אותו מטוס מתבטלים
        {
            await sem.WaitAsync(cts.Token); //מטוס נכנס וסגר אחריו את הדלת
            cts.Cancel();
            this.Flight = flight;
            Console.WriteLine($"Flight: {Flight.Id} - Enter station: {Id}");
            return this;
        }

        public void Exit()
        {
            Console.WriteLine($"Flight: {Flight?.Id} - Exit station: {Id}");
            this.Flight = null; // רוקנו את התחנה 
            sem.Release(); //המטוס יצא מהתחנה 
        }
    }
}

