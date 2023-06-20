import { useState } from "react";
import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Navbar from "./components/Navbar";
import Shelflife from "./pages/Shelflife";
import Root from "./Routes/root";
import Inventory from "./pages/Inventory";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/inventory" element={<Inventory />} />
          <Route path="/shelflife" element={<Shelflife />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
