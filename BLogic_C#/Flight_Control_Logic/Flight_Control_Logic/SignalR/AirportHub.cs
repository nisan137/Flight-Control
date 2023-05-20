using Microsoft.AspNetCore.SignalR;

namespace Flight_Control_Logic.SignalR
{
	public class AirportHub : Hub
	{
        private readonly Timer_1 timer_1;

        public AirportHub(Timer_1 timer_1)
		{
            this.timer_1 = timer_1;
			timer_1.Run();
        }
	}

	public class Timer_1
	{
        private readonly IHubContext<AirportHub> hubContext;

        public Timer_1(IHubContext<AirportHub> hubContext)
		{
            this.hubContext = hubContext;
        }

		int count = 0;

		public async Task Run()
		{
			Thread.Sleep(3000);

			await hubContext.Clients.All.SendAsync("Home", count);
			count++;

			await Run();
		}
	}
}

