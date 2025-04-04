import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ToDoList from './Components/To_Do_List/To_Do_List';
//import ToDoList from './Components/Add/Add';

 
function App() {
  return (
    <main>
      <Router>
        <Routes>
          {/*<Route exact path='/' element={<ToDoList />} />*/}
          <Route exact path='/' element={<ToDoList />} />
        </Routes>
      </Router>
    </main>
  );

}
export default App;