import React, { useEffect, useState } from 'react';
import axios from 'axios';

// Components
import Header from './components/Header';
import Sidebar from './components/SideBar';
import Footer from './components/Footer';
import Transaction from './components/Transaction';
import Product from './components/Product';
import Customer from './components/Customer';

function App() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get('https://jsonplaceholder.typicode.com/posts')
      .then(response => {
        setData(response.data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
        setLoading(false);
      });
  }, []);

  if (loading) return <h2>Loading...</h2>;

  return (
    <div>
      <Header />
      <div style={{ display: 'flex' }}>
        <Sidebar />
        <main style={{ padding: '20px', flex: 1 }}>
          <Transaction />
        </main>
      </div>
      <Footer />
    </div>
  );
}

export default App;