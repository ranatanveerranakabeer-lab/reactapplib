import React, { useEffect, useState } from "react";
import axios from "axios";

function Product() {
  const [products, setProducts] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [isEdit, setIsEdit] = useState(false);

  const [formData, setFormData] = useState({
    id: "",
    name: "",
    sku: "",
    price: "",
    stockQuantity: ""
  });

  const API_URL = "https://localhost:7200/api/Product";

  // Load products automatically 
  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    try {
      const res = await axios.get(`${API_URL}/getall`);
      console.log("API Response:", res.data);


      const productList = Array.isArray(res.data.data) ? res.data.data : [];
      console.info("Parsed Product List:", productList);
      setProducts(productList);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  //  Handle input change 
  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  //  Open Add Modal
  const handleAdd = () => {
    setIsEdit(false);
    setFormData({
      id: "",
      name: "",
      sku: "",
      price: "",
      stockQuantity: ""
    });
    setShowModal(true);
  };

  // Open Edit Modal 
  const handleEdit = (product) => {
    setIsEdit(true);
    setFormData(product);
    setShowModal(true);
  };

  //  Save Product (Create / Update) 
 const handleSave = async () => {
  try {
    // Convert numbers properly
    const payload = {
      name: formData.name,
      sku: formData.sku,
      price: parseFloat(formData.price) || 0,
      stockQuantity: parseInt(formData.stockQuantity) || 0
    };

    if (isEdit) {
      await axios.put(`${API_URL}/${formData.id}`, payload);
    } else {
      await axios.post(`${API_URL}/create`, payload);
    }

    setShowModal(false);
    fetchProducts();
  } catch (error) {
    console.error("Error saving product:", error);
    alert("Error saving product. Check console for details.");
  }
};

  // Delete Product 
  const handleDelete = async (id) => {
    if (!window.confirm("Are you sure you want to delete this product?")) return;
    try {
      await axios.delete(`${API_URL}/${id}`);
      fetchProducts();
    } catch (error) {
      console.error("Error deleting product:", error);
    }
  };

  return (
    <div className="container mt-4">
      <h2>Product List</h2>

      <button className="btn btn-primary mb-3" onClick={handleAdd}>
        Add Product
      </button>

      {/* Table  */}
      <table className="table table-striped table-hover table-bordered shadow-sm rounded">
  <thead className="table-dark">
    <tr>
      <th>Name</th>
      <th>SKU</th>
      <th>Price</th>
      <th>Stock Quantity</th>
      <th>Actions</th>
    </tr>
  </thead>
  <tbody>
    {products.length > 0 ? (
      products.map((p) => (
        <tr key={p.id}>
          <td>{p.name}</td>
          <td>{p.sku}</td>
          <td>${p.price.toFixed(2)}</td>
          <td>{p.stockQuantity}</td>
          <td>
            <button
              className="btn btn-warning btn-sm me-2"
              onClick={() => handleEdit(p)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger btn-sm"
              onClick={() => handleDelete(p.id)}
            >
              Delete
            </button>
          </td>
        </tr>
      ))
    ) : (
      <tr>
        <td colSpan="5" className="text-center">
          No products found
        </td>
      </tr>
    )}
  </tbody>
</table>

      {/*  Modal  */}
      {showModal && (
        <div className="modal d-block" tabIndex="-1">
          <div className="modal-dialog">
            <div className="modal-content p-3">
              <h4>{isEdit ? "Update Product" : "Add Product"}</h4>

              <input
                type="text"
                name="name"
                placeholder="Name"
                className="form-control mb-2"
                value={formData.name || ""}
                onChange={handleChange}
              />

              <input
                type="text"
                name="sku"
                placeholder="SKU"
                className="form-control mb-2"
                value={formData.sku || ""}
                onChange={handleChange}
              />

              <input
                type="number"
                name="price"
                placeholder="Price"
                className="form-control mb-2"
                value={formData.price || ""}
                onChange={handleChange}
              />

              <input
                type="number"
                name="stockQuantity"
                placeholder="Stock Quantity"
                className="form-control mb-2"
                value={formData.stockQuantity || ""}
                onChange={handleChange}
              />

              <div className="d-flex justify-content-end">
                <button
                  className="btn btn-secondary me-2"
                  onClick={() => setShowModal(false)}
                >
                  Cancel
                </button>
                <button className="btn btn-success" onClick={handleSave}>
                  Save
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default Product;