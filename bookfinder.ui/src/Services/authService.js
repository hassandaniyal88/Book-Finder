import axios from "axios";

const API_URL = "https://localhost:44316/api/auth";

export default {
  async login(credentials) {
    const response = await axios.post(`${API_URL}/login`, credentials);
    return response.data;
  },
  async register(userData) {
    const response = await axios.post(`${API_URL}/register`, userData);
    return response.data;
  },
};
