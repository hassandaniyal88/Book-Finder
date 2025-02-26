import axios from "axios";

const API_URL = "https://localhost:44316/api/books";

export default {
  async searchBooks(query) {
    const response = await axios.get(`${API_URL}?search=${query}`);
    return response.data;
  },
};
