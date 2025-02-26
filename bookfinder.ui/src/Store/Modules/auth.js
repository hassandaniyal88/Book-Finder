import axios from "axios";

const API_URL = "https://localhost:44316/api/auth";

export default {
  namespaced: true,
  state: {
    token: localStorage.getItem("token") || "",
  },
  getters: {
    isAuthenticated: (state) => !!state.token, // Fix: Ensures boolean check
    getUser: (state) => state.user,
  },

  mutations: {
    SET_TOKEN(state, token) {
      state.token = token;
      state.isAuthenticated = true;
      localStorage.setItem("token", token);
      axios.defaults.headers.common["Authorization"] = token ? `Bearer ${token}` : "";
    },
    LOGOUT(state) {
      state.token = "";
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      delete axios.defaults.headers.common["Authorization"];
    },
  },
  actions: {
    async login({ commit }, credentials) {
      try {
        
        const response = await axios.post(`${API_URL}/login`, credentials);

        

        if (!response.data?.token) {
          throw new Error("❌ Token is missing from API response");
        }

        commit("SET_TOKEN", response.data.token);
        localStorage.SetItem("user", response.data.user);
        return response.data;
      } catch (error) {
        console.error("❌ Login failed:", error.response?.data || error.message);
        throw error;
      }
    },
    async logout({ commit }) {
      commit("LOGOUT");
    },
  },
  getters: {
    isAuthenticated: (state) => !!state.token,
  },
};
