import { useState } from "react";
import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import Login from "./pages/login";
import Navbar from "./components/Navbar";

function App() {
  const [count, setCount] = useState(0);

  return <Home />;
}

export default App;
