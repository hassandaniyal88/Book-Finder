import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
  plugins: [vue()],
  server: {
    port: 60879, // Vue app ka port
    proxy: {
      '/api': {
        target: 'http://localhost:44316', // Backend API ka address
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
