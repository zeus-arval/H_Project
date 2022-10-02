<template>
    <div class="form-container">
        <div class="text-description">
            Please <b>enter your name</b> and <br/><b>pick the Sectors</b> you are currently involved in:
        </div>
        <div class="input-container">
            <div class="text-column">
                <div class="text-label">
                    Name:*
                </div>
                <div class="text-label">
                    Sectors:*
                </div>
            </div>
            <div class="input-column">
                <div class="input-name">
                    <input
                        id="submitterName"
                        name="submitterName"
                        v-model="form.submitterName"
                        class="input-box"
                        minlength="2"
                        maxlength="30"
                        required
                    />
                </div>

                <Multiselect
                mode="multiple"
                v-model="choosenSectors"
                placeholder="Select sectors"
                :close-on-select="false"
                :options="sectorNames"
                >
                    <template v-slot:multiplelabel="{ sectorNames }" >
                        <div class="multiselect-multiple-label">
                        {{ sectorsChosenCount }} sectors selected
                        </div>
                    </template>
                </Multiselect>
            </div>
        </div>
        
        <div class="check-box">
            <input type="checkbox">
            <div class="agree-to-terms-text">
                Agree to terms
            </div>
        </div>

        <div class="button-container">
            <button @click="add()">
                <div class="button-text">
                    Save
                </div>
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
    import type { SectorData } from "@/modules/sector";
    import type { FormData } from "@/modules/form";
    import Multiselect from '@vueform/multiselect'
    import { storeToRefs } from "pinia";
    import { useSectorsStore } from "@/stores/sectorsStore";
    import { useFormsStore } from "@/stores/formsStore";
    import { onMounted, watch, ref } from "vue";
    import type { Ref } from "vue";
    import { useRouter } from "vue-router";

    const sectorsStore = useSectorsStore();
    const { sectors } = storeToRefs(sectorsStore);
    const sectorNames = ref<string[]>([]);
    const choosenSectors = ref<string[]>([]);
    const sectorsChosenCount = ref(0);

    const { addForm } = useFormsStore();
    const form: Ref<FormData> = ref({
        submitterName: "",
        createdAt: "2022-09-26T09:53:46.318Z",
        SectorNames: [],
    })
    let isOpen = true;

    onMounted(async () => {
        await sectorsStore.load();
        sectors.value.forEach(function (value){
            sectorNames.value.push(value.name);
        });

        console.log(sectorNames);
    });

    watch(choosenSectors, (count) => {
        sectorsChosenCount.value = choosenSectors.value.length;
        form.value.SectorNames = choosenSectors.value;
    });

    const add = async () => {
        console.log("Adding");
        let response = addForm({ ...form.value });
        let id = await response;
        console.log(id);

    };

</script>

<style src="@vueform/multiselect/themes/default.css"></style>
<style>
    @import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@200&family=Roboto&display=swap');
</style>
