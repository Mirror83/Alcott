import { useState } from "react";
import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import Login from "./pages/login";
import Navbar from "./components/Navbar";
import Sales from "./pages/sales";
import Orders from "./pages/orders";

function App() {
  const [count, setCount] = useState(0);

  return <Sales/>;
}

export default App;
