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
                        v-model="submitterName"
                        class="input-box"
                        minlength="2"
                        maxlength="50"
                        required
                    />
                    <div class="error-message" v-if="nameIsInvalid">
                        Invalid name!
                    </div>
                </div>

                <div class="input-sectors">
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

                    <div class="error-message" v-if="sectorsAreInvalid">
                        Choose sectors!
                    </div>
                </div>
            </div>
        </div>
        
        <div class="agree-to-terms-container">
            <div class="check-box">
                <input type="checkbox" v-model="agreedToTerms">
                <div class="agree-to-terms-text">
                    Agree to terms
                </div>
            </div>
            <div class="error-message agree-to-terms-error-message" v-if="agreedToTermsNotSelected">
                Must be selected!
            </div>
        </div>

        <button @click="add()" class="button-container">
            <div class="button-text">
                Save
            </div>
        </button>
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
        createdAt: new Date("2022-09-26T09:53:46.318Z"),
        SectorNames: [],
    });
    const submitterName = ref("");

    let isOpen = true;
    const nameIsInvalid = ref(false);

    const sectorsAreInvalid = ref(false);

    const agreedToTerms = ref(false);
    const agreedToTermsNotSelected = ref(false);

    onMounted(async () => {
        await sectorsStore.load();
        sectors.value.forEach(function (value){
            sectorNames.value.push(value.name);
        });
    });

    watch(choosenSectors, (count) => {
        sectorsChosenCount.value = choosenSectors.value.length;
        form.value.SectorNames = choosenSectors.value!;
        sectorsAreInvalid.value = false;
    });

    watch(submitterName, (newValue, oldValue) => {
        if (new RegExp("^[a-zA-Z ,.'-]+$").test(newValue) == false){
            nameIsInvalid.value = true;
            form.value.submitterName = "";
            
            return;
        }
        else {
            nameIsInvalid.value = false;
            form.value.submitterName = submitterName.value;
        }
    });

    watch(agreedToTerms, (newValue, oldValue) => {
        agreedToTermsNotSelected.value = !agreedToTerms.value;
        console.log(agreedToTermsNotSelected.value);
        
    });

    const add = async () => {
        if (!form.value.submitterName){
            nameIsInvalid.value = true;
            console.log("Submitter name is invalid");
            
            return;
        }

        if (form.value.SectorNames.length == 0){
            sectorsAreInvalid.value = true;

            return;
        }
        console.log(agreedToTerms.value);
        

        if (agreedToTerms.value == false){
            agreedToTermsNotSelected.value = true;
            console.log(agreedToTerms.value);
            
            return;
        }

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
