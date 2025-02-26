<!--<script setup>
  import { RouterLink, RouterView, useRouter } from "vue-router";
  import { computed } from "vue";
  import { useStore } from "vuex";

  const router = useRouter();
  const store = useStore();


  const isAuthenticated = computed(() => store.state.isAuthenticated);

  // ✅ Logout function
  const logout = () => {
    store.dispatch("logout"); 
    router.push("/login"); // Redirect to login
  };
</script>-->
<script>
  import { mapGetters, mapActions } from "vuex";

  export default {
    computed: {
      ...mapGetters("auth", ["isAuthenticated"]), //  Access Vuex auth module
    },
    methods: {
      ...mapActions("auth", ["logout"]), // Call logout action
    },
  };
</script>

<template>
  <div class="min-h-screen bg-gray-100 flex flex-col">
    <!-- Header Section -->
    <header class="w-full bg-blue-500 text-white py-4 shadow-md">
      <div class="container mx-auto flex justify-between items-center px-6">
        <h1 class="text-2xl font-bold">📚 Book Finder</h1>
        <nav class="space-x-4 flex">
          <RouterLink to="/" class="nav-btn">Home</RouterLink>
          <template v-if="isAuthenticated">
            <RouterLink to="/favorites" class="nav-btn">Favorites</RouterLink>
            <button @click="logout" class="nav-btn logout-btn">Logout</button>
          </template>
          <template v-else>
            <RouterLink to="/login" class="nav-btn">Login</RouterLink>
            <RouterLink to="/register" class="nav-btn">Register</RouterLink>
          </template>
        </nav>
      </div>
    </header>

    <!-- Main Content -->
    <main class="container mx-auto py-8 px-6 flex-grow w-full">
      <div class="max-w-4xl mx-auto">
        <RouterView />
      </div>
    </main>

    <!-- Footer -->
    <footer class="w-full bg-gray-800 text-white text-center py-4 mt-auto">
      <p>© 2024 Book Finder. All rights reserved.</p>
    </footer>
  </div>
</template>




<style scoped>
  .nav-btn {
    background: #4a90e2;
    color: white;
    font-weight: 500;
    padding: 10px 18px;
    border-radius: 5px;
    transition: background 0.3s ease, transform 0.1s ease;
    text-decoration: none;
    display: inline-block;
    margin-right: 10px;
  }

    .nav-btn:hover {
      background: #357ab7;
      transform: scale(1.05);
    }

  .logout-btn {
    background: #d9534f;
  }

    .logout-btn:hover {
      background: #c9302c;
    }
</style>
