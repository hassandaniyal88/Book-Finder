<template>
  <div v-if="book" class="book-item">
    <img :src="book.coverImageUrl" :alt="`Cover of ${book.title}`" class="book-cover" />
    <h3 class="book-title">{{ book.title }}</h3>
    <p class="book-author">{{ book.author }}</p>

    <!-- Add to Favorites Button -->
    <button v-if="isAuthenticated" class="favorite-button" @click="toggleFavorite">
      {{ isFavorite ? "Remove from Favorites" : "Add to Favorites" }}
    </button>
    </div>
</template>

<script>
  import { mapActions, mapGetters } from "vuex";

  export default {
    props: {
      book: {
        type: Object,
        required: true
      }
    },
    computed: {
      ...mapGetters(["isAuthenticated"]),
      ...mapGetters("books", ["favoriteBooks"]),
      isFavorite() {
        return this.favoriteBooks.some(fav => fav.id === this.book.id);
      }
    },
    methods: {
      ...mapActions("books", ["addFavorite", "removeFavorite"]),

      toggleFavorite() {
        if (this.isFavorite) {
          this.removeFavorite(this.book.id);
        } else {
          this.addFavorite(this.book);
        }
      }
    }
  };
</script>

<style scoped>
  .book-item {
    width: 100%;
    max-width: 250px;
    background: #f9f9f9;
    border: 1px solid #ddd;
    border-radius: 8px;
    padding: 15px;
    text-align: center;
    transition: transform 0.2s ease-in-out;
    margin: auto;
  }

    .book-item:hover {
      transform: scale(1.05);
    }

  .book-cover {
    width: 100%;
    height: 300px; /* ✅ Fixed height */
    object-fit: cover; /* ✅ Prevents stretching */
    border-radius: 5px;
  }

  .book-title {
    font-size: 1.1em;
    margin: 10px 0 5px;
    font-weight: bold;
  }

  .book-author {
    color: #555;
    font-size: 0.9em;
  }

  .favorite-button {
    background: #007bff;
    color: white;
    border: none;
    padding: 8px 12px;
    border-radius: 5px;
    cursor: pointer;
    margin-top: 10px;
    transition: background 0.3s ease;
  }

    .favorite-button:hover {
      background: #0056b3;
    }

  /* Responsive Design */
  @media (max-width: 1024px) {
    .book-container {
      grid-template-columns: repeat(2, 1fr);
    }
  }

  @media (max-width: 640px) {
    .book-container {
      grid-template-columns: repeat(1, 1fr);
    }
  }
</style>
