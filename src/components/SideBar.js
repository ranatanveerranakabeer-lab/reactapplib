import React from 'react';
import { Link } from 'react-router-dom';

const SideBar = () => {
  return (
    <aside
      style={{
        width: '200px',
        background: '#f0f0f0',
        padding: '20px',
        height: '100vh',
        boxSizing: 'border-box'
      }}
    >
      <ul style={{ listStyle: 'none', padding: 0 }}>
        <li style={{ marginBottom: "10px" }}>
          <Link to="/">Home</Link>
        </li>
        <li style={{ marginBottom: "10px" }}>
          <Link to="/products">Products</Link>
        </li>
        <li style={{ marginBottom: "10px" }}>
          <Link to="/transactions">Transactions</Link>
        </li>
        <li>
          <Link to="/about">About</Link>
        </li>
      </ul>
    </aside>
  );
};

export default SideBar;