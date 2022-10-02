import { useApi, useApiRawRequest } from '@/modules/api';
import type { SectorData } from '@/modules/sector';
import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useSectorsStore = defineStore('sectorsStore', () => {
  const apiGetSectors = useApi<SectorData[]>('sectors');
  let allSectors: SectorData[] = [];
  let sectors = ref<SectorData[]>([]);

  const loadSectors = async () => {
    await apiGetSectors.request();

    console.log(apiGetSectors);
    
    if (apiGetSectors.response.value) {
      return apiGetSectors.response.value!;
    }    

    return [];
  };

  const load = async () => {
    allSectors = await loadSectors();    
    sectors.value = allSectors;
  };

  return {
    sectors,
    load
  };
});
