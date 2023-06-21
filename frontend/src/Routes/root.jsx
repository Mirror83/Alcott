import React from "react";

import { Outlet, Link } from "react-router-dom";

const Root = () => {
  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/login">Login</Link>
          </li>
          <li>
            <Link to="/shelflife">Shelflife</Link>
          </li>
          <li>
            <Link to="/inventory">Inventory</Link>
          </li>
        </ul>
      </nav>

      <Outlet />
    </>
  );
};

export default Root;
