<template>
  <div class="Login-container">
    <h2>Register</h2>
    <form @submit.prevent="register">
      <input v-model.trim="user.username" type="text" placeholder="Username" required />
      <input v-model.trim="user.email" type="email" placeholder="Email" required />
      <input v-model="user.password" type="password" placeholder="Password" required />
      <button type="submit" :disabled="loading">
        {{ loading ? "Registering..." : "Register" }}
      </button>
      <p class="text-gray-600 text-sm text-center">
        Already have an account?
        <router-link to="/login" class="text-blue-500 hover:underline">Login Now</router-link>
      </p>
    </form>
  </div>
</template>

<script>
  import { useStore } from "vuex";
  import { ref } from "vue";
  import { useRouter } from "vue-router";
  import authService from "../services/authService";

  export default {
    setup() {
      const store = useStore();
      const router = useRouter();
      const user = ref({ name: "", email: "", password: "" });
      const loading = ref(false);

      const register = async () => {
        loading.value = true;
        try {
          
          await authService.register(user.value);
          alert("Registration successful! Please log in.");
          router.push("/login");
        } catch (error) {
          alert(error.response?.data?.message || "Registration failed!");
        } finally {
          loading.value = false;
        }
      };

      return { user, register, loading };
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
    width: auto; /* Makes button fit content */
    padding: 10px 20px; /* Adjust padding for better size */
    background: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    display: block;
    margin: 10px auto; /* Centers button below inputs */
  }

    button:disabled {
      background: #ccc;
    }

  .error {
    color: red;
    margin-top: 10px;
  }
</style>
