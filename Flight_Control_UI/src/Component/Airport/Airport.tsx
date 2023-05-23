import { IStation } from "../../Models/IStation";
import { Station } from "../Station/Station";
import "./Airport.css";

export const Airport = () => {
  const stationList: IStation[] = [
    { stationId: 1, airplane: { airplaneId: 10 } },
    { stationId: 2, airplane: { airplaneId: 0 } },
    { stationId: 3, airplane: { airplaneId: 0 } },
    { stationId: 4, airplane: { airplaneId: 0 } },
    { stationId: 5, airplane: { airplaneId: 0 } },
    { stationId: 6, airplane: { airplaneId: 0 } },
    { stationId: 7, airplane: { airplaneId: 0 } },
    { stationId: 8, airplane: { airplaneId: 0 } },
    { stationId: 9, airplane: { airplaneId: 0 } },
  ];

  return (
    <>
      <div className="stations">
        {stationList.map((station) => (
          <Station
            flightId={station.airplane.airplaneId}
            stationId={station.stationId}
          />
        ))}
      </div>
    </>
  );
};
