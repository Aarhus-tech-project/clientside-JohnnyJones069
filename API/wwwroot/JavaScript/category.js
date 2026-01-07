const API_BASE_URL = "https://localhost:5137";

document.addEventListener("DOMContentLoaded", () => {
  loadCategories();

  document
    .getElementById("categoryForm")
    .addEventListener("submit", createCategory);
});

// LOAD
async function loadCategories() {
  const response = await fetch(`${API_BASE_URL}/Category`);
  const categories = await response.json();

  const list = document.getElementById("categoryList");
  list.innerHTML = "";

  categories.forEach(c => {
    const li = document.createElement("li");
    li.textContent = c.categoryName;

    const btn = document.createElement("button");
    btn.textContent = "Delete";
    btn.onclick = () => deleteCategory(c.categoryID);

    li.appendChild(btn);
    list.appendChild(li);
  });
}

// CREATE
async function createCategory(e) {
  e.preventDefault();

  const nameInput = document.getElementById("categoryName");

  await fetch(`${API_BASE_URL}/Category`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ categoryName: nameInput.value })
  });

  nameInput.value = "";
  loadCategories();
}

// DELETE
async function deleteCategory(id) {
  await fetch(`${API_BASE_URL}/Category/${id}`, {
    method: "DELETE"
  });

  loadCategories();
}
