import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Product from "./components/Product";
import Transaction from "./components/Transaction";

function App() {
  return (
    <Router>
      <Layout>
        <Routes>
          <Route path="/products" element={<Product />} />
          <Route path="/transactions" element={<Transaction />} />
          <Route path="/" element={<h2>Welcome Home</h2>} />
        </Routes>
      </Layout>
    </Router>
  );
}

export default App;