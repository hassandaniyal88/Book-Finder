<template>
  <div class="Login-container">
    <h2>Login/Resgister</h2>
    <form @submit.prevent="login">
      <input v-model.trim="credentials.email" type="email" placeholder="Email" required />
      <input v-model.trim="credentials.password" type="password" placeholder="Password" required />
      <button type="submit">
        {{ loading ? "Logining..." : "Login" }}
      </button>
      <p class="text-gray-600 text-sm text-center">
        Don't have an account?
        <router-link to="/register" class="text-blue-500 hover:underline">Register Now</router-link>
      </p>
    </form>
  </div>
</template>

<script>
  import { useStore } from "vuex";
  import { ref, computed } from "vue";
  import { useRouter } from "vue-router";
  import authService from "../services/authService";

  export default {
    setup() {
      const store = useStore();
      const router = useRouter();
      const credentials = ref({ email: "", password: "" });

      const login = async () => {
        try {
          const response = await authService.login(credentials.value);
          if (response.token, response.user) {
            localStorage.setItem("token", response.token);
            localStorage.setItem("user", JSON.stringify(response.user));
            //store.commit("auth/setUser", response.user);
            router.push("/").then(() => {
              window.location.reload(); // Reload only after navigation
            });         

          } else {
            alert("Login failed: Missing token or user data.");
          }
        } catch (error) {
          alert(error.response?.data?.message || "Invalid credentials!");
        }
      };

      return { credentials, login };
    },
  };
</script>
<style scoped>
  .Login-container {
    max-width: 400px;
    margin: auto;
    text-align: center;
    padding: 20px;
  }

  input {
    width: 100%;
    padding: 10px;
    margin: 5px 0;
    border: 1px solid #ccc;
    border-radius: 5px;
  }

  button {
    width: auto; 
    padding: 10px 20px; 
    background: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    display: block;
    margin: 10px auto; 
  }

    button:disabled {
      background: #ccc;
    }

  .error {
    color: red;
    margin-top: 10px;
  }
</style>
