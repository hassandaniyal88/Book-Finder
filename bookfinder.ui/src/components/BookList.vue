<template>
  <div class="view-toggle">
     <button @click="toggleView">{{ isGridView ? "Switch to List View" : "Switch to Grid View" }}</button>
  </div>

  <div :class="isGridView ? 'book-container-grid' : 'book-container-list'">
    <div v-for="book in books" :key="book.id" class="book-item">
        <img :src="book.coverImageUrl" :alt="`Cover of ${book.title}`" class="book-cover" />
           <h3 class="book-title">{{ book.title }}</h3>
               <p class="book-author">{{ book.author }}</p>
       <button class="favorite-button" @click="toggleFavorite(book)">
          {{ isFavorite(book) ? "Remove from Favorites" : "Add to Favorites" }}
       </button>
    </div>
  </div>
</template>

<script>
  import { mapActions, mapGetters } from "vuex";

  export default {
    data() {
      return {
        isGridView: true, 
      };
    },
    computed: {
      ...mapGetters("books", ["allBooks", "favoriteBooks"]),
      books() {
        return this.allBooks || [];
      }
    },
    methods: {
      ...mapActions("books", ["addFavorite", "removeFavorite"]),
      toggleFavorite(book) {
        if (this.isFavorite(book)) {
          this.removeFavorite(book.id);
        } else {
          this.addFavorite(book);
        }
      },
      isFavorite(book) {
        return this.favoriteBooks.some(fav => fav.id === book.id);
      },
      toggleView() {
        this.isGridView = !this.isGridView; 
      }
    }
  };
</script>

<style scoped>
  
  .view-toggle {
    text-align: center;
    margin-bottom: 15px;
  }

    .view-toggle button {
      background: #2563eb;
      color: white;
      font-weight: 500;
      padding: 10px 15px;
      border-radius: 6px;
      border: none;
      cursor: pointer;
      transition: background 0.3s ease;
    }

      .view-toggle button:hover {
        background: #1e40af;
      }

  
  .book-container-grid {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    gap: 20px;
    padding: 20px;
    justify-content: center;
  }

 
  .book-container-list {
    display: flex;
    flex-direction: column;
    align-items: center; 
    padding: 20px;
    gap: 20px;
  }

  .book-item {
    background: #f9f9f9;
    border: 1px solid #ddd;
    border-radius: 8px;
    padding: 15px;
    text-align: center;
    transition: transform 0.2s ease-in-out;
    width: 250px; 
  }

    .book-item:hover {
      transform: scale(1.05);
    }

  .book-cover {
    width: 100%;
    aspect-ratio: 2/3;
    object-fit: cover;
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


  @media (max-width: 1024px) {
    .book-container-grid {
      grid-template-columns: repeat(3, 1fr);
    }

    @media (max-width: 768px) {
      .book-container-grid {
        grid-template-columns: repeat(2, 1fr);
      }
    }

    @media (max-width: 480px) {
      .book-container-grid {
        grid-template-columns: repeat(1, 1fr);
      }
    }
  }
</style>
