  const API_BASE_URL = "";

  document.addEventListener("DOMContentLoaded", () => {
    loadProducts();
  });

  // LOAD
  async function loadProducts() {
    try {
      const [productsResponse, categoriesResponse] = await Promise.all([
        fetch(`${API_BASE_URL}/Product`),
        fetch(`${API_BASE_URL}/Category`)
      ]);

      const products = await productsResponse.json();
      const categories = await categoriesResponse.json();

      const categoryMap = {};
      categories.forEach(c => categoryMap[c.categoryID] = c.categoryName);

      const list = document.getElementById("productList");
      list.innerHTML = "";

      products.forEach(p => {
        const categoryName = categoryMap[p.categoryID] || `ID: ${p.categoryID}`;
        const li = document.createElement("li");
        li.textContent = `${p.productName} - $${p.price} (Category: ${categoryName})`;
        list.appendChild(li);
      });
    } catch (error) {
      console.error('Error loading products:', error);
    }
  }
