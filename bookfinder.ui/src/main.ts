import { createApp } from "vue";
import App from "./App.vue";
import store from "./Store/index.js";
import router from "./Router/index.js";
import "./assets/styles.css";

const app = createApp(App);
app.use(store);
app.use(router);
app.mount("#app");
