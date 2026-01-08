  const API_BASE_URL = "";

  document.addEventListener("DOMContentLoaded", () => {
    loadCustomers();
  });

  // LOAD
  async function loadCustomers() {
    const response = await fetch(`${API_BASE_URL}/Customer`);
    const customers = await response.json();

    const list = document.getElementById("customerList");
    list.innerHTML = "";

    customers.forEach(c => {
      const li = document.createElement("li");
      li.textContent = `${c.firstName} - ${c.email}`;
      list.appendChild(li);
    });
  }
