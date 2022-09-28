
import { createRouter, createWebHistory } from 'vue-router';
import MainView from "@/views/MainView.vue";

const routes = [
    {
      path: '/',
      name: 'Helmes Test Project',
      component: MainView
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
  });
  
export default router;
  