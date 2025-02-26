<template>
  <div class="container mx-auto p-6">
    <!-- Search Bar -->
    <div class="flex items-center justify-center gap-4 mb-6">
      <input v-model="searchQuery"
             @keyup.enter="searchBooks"
             placeholder="Search for books..."
             class="border border-gray-300 p-2 rounded-lg w-1/2 focus:outline-none focus:ring-2 focus:ring-blue-400" />
      <button @click="searchBooks"
              class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition">
        Search
      </button>
    </div>

    <!-- Book List -->
    <div v-if="books.length > 0" class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
      <BookItem v-for="book in books"
                :key="book.id"
                :book="book"
                @add-favorite="addFavorite"
                class="transition-transform transform hover:scale-105" />
    </div>

    <p v-else class="text-gray-500 text-center mt-6">No books found 📖</p>
  </div>
</template>

<script>
  import { mapState, mapActions } from "vuex";
  import BookItem from "./BookList.vue";

  export default {
    components: { BookItem },
    data() {
      return { searchQuery: "" };
    },
    computed: {
      ...mapState("books", ["books"]),
    },
    methods: {
      ...mapActions("books", ["fetchBooks"]),
      searchBooks() {
        if (this.searchQuery.trim() !== "") {
          this.fetchBooks(this.searchQuery);
        } else {
          console.warn("⚠️ Search query is empty!");
        }
      },
    },
  };
</script>

