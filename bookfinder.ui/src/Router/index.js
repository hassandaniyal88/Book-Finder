import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";
import Favorites from "../views/Favorites.vue";
import Login from "../components/Login.vue";
import Register from "../components/Register.vue";
import store from "../store/index.js"; // Import Vuex store to check authentication
import Book from "../components/BookList.vue";

const routes = [
  { path: "/", component: Home },
  {
    path: "/favorites",
    component: Favorites,
    meta: { requiresAuth: true } // ✅ Add authentication requirement
  },
  { path: "/login", component: Login },
  { path: "/register", component: Register },
  { path: "/books", component: Book },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

// ✅ Route Guard: Redirect unauthenticated users to login page
router.beforeEach((to, from, next) => {
  const isAuthenticated = store.getters["auth/isAuthenticated"]; // Check user authentication status

  if (to.meta.requiresAuth && !isAuthenticated) {
    console.warn("⚠️ Access denied! Redirecting to login...");
    next("/login");
  } else {
    next();
  }
});

export default router;
