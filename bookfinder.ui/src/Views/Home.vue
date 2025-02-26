<template>
  <div class="container mx-auto px-6 py-12 max-w-screen-lg">
    <!-- Hero Section -->
    <section class="text-center max-w-3xl mx-auto">
      <h1 class="text-5xl font-extrabold text-gray-900 leading-tight">
        Explore. Discover. Elevate Your Reading Experience.
      </h1>
      <p class="text-lg text-gray-600 mt-4">
        Find insightful books, build your personalized collection, and stay ahead with your reading goals.
      </p>
    </section>

    <!-- Search Bar -->
    <div class="mt-8 flex justify-center">
      <SearchBar />
    </div>

    <!-- Featured Books Section -->
    <section class="mt-14">
      <div class="flex items-center justify-between">
        <h2 class="text-3xl font-semibold text-gray-800">Featured Books</h2>
        <router-link to="/BookList" class="text-blue-600 hover:underline">View All</router-link>
      </div>
      <!-- Book List should be visible even without searching -->
      <BookList class="mt-6" />
    </section>

    <!-- Call-to-Action Section -->
    <section class="mt-16 bg-gray-50 p-8 rounded-lg shadow-sm text-center max-w-2xl mx-auto">
      <h3 class="text-2xl font-semibold text-gray-900">Unlock a World of Knowledge</h3>
      <p class="text-gray-600 mt-2">
        Create an account to save your favorite books, manage your reading list, and explore personalized recommendations.
      </p>
      <div class="mt-5">
        <router-link to="/register" class="cta-btn">Get Started</router-link>
      </div>
    </section>
  </div>
</template>

<script>
  import SearchBar from "../components/SearchBar.vue";
 // import BookList from "../components/BookList.vue"; 

  export default {
    components: { SearchBar }, 
  };
</script>

<style scoped>
  /* Make sure the hero section looks similar to the reference */
  h1 {
    line-height: 1.3;
  }

  .cta-btn {
    background-color: #6a0dad;
    color: white;
    padding: 12px 24px;
    font-size: 1rem;
    font-weight: 600;
    border-radius: 8px;
    display: inline-block;
    transition: background 0.3s ease;
  }

    .cta-btn:hover {
      background-color: #5b0cad;
    }
</style>
