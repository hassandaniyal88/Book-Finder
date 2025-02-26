<template>
  <div class="book-container">
    <BookItem v-for="book in favoriteBooks"
              :key="book.id"
              :book="book">
      <button class="remove-btn" @click="removeFavorite(book.id)">
        ❌ Remove from Favorites
      </button>
    </BookItem>
  </div>
</template>

<script>
  import { mapGetters, mapActions } from "vuex";
  import BookItem from "./BookItem.vue";

  export default {
    components: { BookItem },
    computed: {
      ...mapGetters("books", ["favoriteBooks"]), // onlny favorite books
    },
    methods: {
      ...mapActions("books", ["removeFavorite"]) 
    }
  };
</script>

<style scoped>
  .book-container {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: 20px;
    padding: 20px;
    justify-content: center;
  }

  .remove-btn {
    margin-top: 10px;
    padding: 8px 12px;
    background-color: red;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background 0.3s;
  }

    .remove-btn:hover {
      background-color: darkred;
    }
</style>
