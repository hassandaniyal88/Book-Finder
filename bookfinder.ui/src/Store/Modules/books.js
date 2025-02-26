import axios from "axios";

const API_URL = "https://localhost:44316/api";

const state = {
  books: [],
  favorites: JSON.parse(localStorage.getItem(`favorites_${getUserId()}`)) || [],
};

function getUserId() {
  const user = JSON.parse(localStorage.getItem("user") || "{}");
  return user.id || null;
}

const mutations = {
  SET_BOOKS(state, books) {
    state.books = Array.from(new Map(books.map(book => [book.id, book])).values());
  },
  ADD_FAVORITE(state, book) {
    state.favorites.push(book);
    localStorage.setItem(`favorites_${getUserId()}`, JSON.stringify(state.favorites)); // Store per user
  },
  REMOVE_FAVORITE(state, bookId) {
    state.favorites = state.favorites.filter(book => book.id !== bookId);
    localStorage.setItem(`favorites_${getUserId()}`, JSON.stringify(state.favorites)); // Update per user
  },
};

const actions = {
  async fetchBooks({ commit }, query) {
    try {
      const response = await axios.get(`${API_URL}/books?search=${query}`);
      commit("SET_BOOKS", response.data);
    } catch (error) {
      console.error("Error fetching books:", error.response?.data || error.message);
    }
  },

  async addFavorite({ commit }, book) {
    try {
      const userId = getUserId();
      if (!userId) throw new Error("User not logged in");

      await axios.post(
        `${API_URL}/Favorites?bookId=${book.id}&userId=${userId}`,
        null,
        { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } }
      );

      commit("ADD_FAVORITE", book);
    } catch (error) {
      console.error("Error adding to favorites:", error);
    }
  },

  async removeFavorite({ commit }, bookId) {
    try {
      const userId = getUserId();
      if (!userId) throw new Error("User not logged in");

      await axios.delete(`${API_URL}/Favorites/${bookId}/${userId}`, {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
      });

      commit("REMOVE_FAVORITE", bookId); // ✅ Corrected
    } catch (error) {
      console.error("Error removing from favorites:", error);
    }
  },
};

const getters = {
  allBooks: (state) => state.books,
  favoriteBooks: (state) => state.favorites, // Only user's favorites now
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters,
};
