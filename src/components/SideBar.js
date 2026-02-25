import React from 'react';

const SideBar = () => {
  return (
    <aside style={{ width: '200px', background: '#f0f0f0', padding: '20px', height: '100vh', boxSizing: 'border-box' }}>
      <ul style={{ listStyle: 'none', padding: 0 }}>
        <li>Home</li>
        <li>About</li>
        <li>Contact</li>
      </ul>
    </aside>
  );
};

export default SideBar;