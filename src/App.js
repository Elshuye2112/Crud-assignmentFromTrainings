import logo from './logo.svg';
import './App.css';
import GetTrainee from './assignment/GetTrainee';
import AddTrainee from './assignment/AddTrainee';
import GetTrainer from './assignment/GetTrainer';
import AddTraineer from './assignment/AddTraineer';

function App() {
  return (
    <div className="App">
      <GetTrainee />
      <AddTrainee />
      <GetTrainer />
      <AddTraineer/>
    </div>
  );
}

export default App;
