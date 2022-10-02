import type { FormData } from "@/modules/form";

import { useApi } from '@/modules/api';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useFormsStore = defineStore('formsStore', () => {
  let allForms: FormData[] = [];
  let forms = ref<FormData[]>([]);

  const addForm = async (form: FormData) => {
    const apiAddForm = useApi<FormData>('forms', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(form),
    });

    await apiAddForm.request();
    if (apiAddForm.response.value) {
      allForms.push(apiAddForm.response.value!);
      forms.value = allForms;
    }
    
    return apiAddForm.response.value;
  };

  return {
    forms,
    addForm,
  };
});
