<template>
    <Form v-if="isFormOpened"
      :errorOccured = "errorOccured"
      @close="(errOccurred) => {
        isFormOpened = false;
        errorOccured = errOccurred;
      }"/>

    <FormResult v-if="!isFormOpened"
      :errorOccured = "errorOccured"
      @close="isFormOpened = true"/>
</template>

<script setup lang="ts">
  import Form from "@/components/Form.vue";
  import FormResult from "@/components/FormResult.vue";
  import { ref, watch } from "vue";

  const errorOccured = ref(false);
  const isFormOpened = ref(true);

  watch(errorOccured, (newValue, oldValue) => {
    console.log(oldValue, newValue);
  });
</script>
