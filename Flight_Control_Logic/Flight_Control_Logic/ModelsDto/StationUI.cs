namespace Flight_Control_Logic.ModelsDto
{
	public class StationUI
	{
		public int stationId { get; set; }
		public FlightUI airplane { get; set; }

		public StationUI(int stationId, FlightUI flightUI)
		{
			this.stationId = stationId;
			airplane = flightUI;
        }
	}
}