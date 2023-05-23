import "./Airplane.css";

export const Airplane = ({flightId}:IProps) => {
  return (
    <div className="Airplane">
      <div>{flightId}</div>
    </div>
  );
};

interface IProps {
    flightId:number;
}