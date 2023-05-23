import { Airplane } from "../Airplane/Airplane";
import "./Station.css";

export function Station({ flightId, stationId }: IProps) {
    return (
        <div className="Station">
            <div className="station-number">{stationId}</div>
            {flightId != 0 &&
                <Airplane flightId={flightId} />
            }
        </div>
    );
}

interface IProps {
    stationId: number;
    flightId: number;
}
