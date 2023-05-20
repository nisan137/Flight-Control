using System;
using System.Linq;

namespace Flight_Control_Logic.BLogic
{
    public class Flight
    {
        public int Id { get; set; }
        public Station? CurrentStation { get; set; }
    
        public Flight(int id)
        {
            Id = id;
        }

        public async Task Run(Route route) // מקבל מסלול התחלתי
        {
            CurrentStation = route.FirstOrDefault(); // משים את התחנה הנוכחית במסלול  
            await Task.Run(async () =>
            {
                List<Station> nextStations;
                Station nextStaion;

                do
                {
                    nextStations = route.GetNext(CurrentStation!);// משים את התחנה הנוכחית בתחנה הבאה כדי לקדם את המטוס
                    if (nextStations.Count == 0 ) // מוודא שהתחנות הבאות פנויות אם לא אז
                    {
                        CurrentStation!.Exit(); // מרוקן את התחנה ממטוסים
                        CurrentStation = null; // מרוקן את המטוס מהתחנה
                        return;
                    }

                    nextStaion = await GetFirstAvilable(nextStations); // 
                    await MoveToNextStation(nextStaion);

                } while (nextStations.Count > 0 && nextStaion != null);
            });
        }

        private async Task MoveToNextStation(Station nextStaion)
        {
            if (CurrentStation != null)
            {
                CurrentStation.Exit();
            }
            CurrentStation = nextStaion;
            await Task.Delay(3000);
        }

        private async Task<Station> GetFirstAvilable(List<Station> nextStatioins)
        {
            var cts = new CancellationTokenSource();
            var enterStationTasks = nextStatioins.Select(async s => await s.Enter(this, cts));
            var theFreeStation = await Task.WhenAny(enterStationTasks);

            return await theFreeStation;
        }
	}
}