import './App.css'
import { Airport } from './Component/Airport/Airport';
import { useSignalR } from './Hooks/useSignalR'
import { MainView } from './Views/MainView/MainView';

function App() {

  const { start } = useSignalR();

  return (
    <>
      {/* <h1>nisan</h1>
      <button onClick={start}> start </button> */}

      <MainView/>
    </>
  )
}

export default App
