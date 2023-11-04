
import './App.css';
import MainPage from './Pages/Main';
import {  BrowserRouter as Router,  Route, Routes} from 'react-router-dom';

import SignalrHub from './Components/SignalrHub';
function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
          <Route path='/' element={MainPage}></Route>
        </Routes>
        <SignalrHub>
          
        </SignalrHub>
      </Router>
    </div>
   
  );
}

export default App;
