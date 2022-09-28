<template v-cloak>
  <component :is="layout">
    <router-view />
  </component>
</template>

<script lang="ts">
import MainLayout from "@/layouts/MainLayout.vue";
import MainView from "@/views/MainView.vue";
import "@/assets/style.css";
import "vue";
import { defineComponent } from 'vue';
import { useRoute } from "vue-router";

const route = useRoute();

export default defineComponent({
 computed: {
    layout() {
      return MainLayout;
    },
  },
  components: {
    MainLayout,
  },
});
</script>
