import { createStore } from "vuex";
import auth from "./modules/auth";
import books from "./modules/books";

export default createStore({
  modules: {
    auth,
    books,
  },
});
