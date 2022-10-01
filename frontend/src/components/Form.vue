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
                <input type="text" class="input-box">
                <!-- <select id="multiple-select" class="select-box">
                    <option class="option-text">Construction materials</option>
                    <option class="option-text">Construction materials</option>
                    <option class="option-text">Construction materials</option>
                    <option class="option-text">Construction materials</option>
                </select> --> 
                <multiselect v-model="value" :options="options" :multiple="true" :close-on-select="false" :clear-on-select="false" :preserve-search="false" placeholder="Pick some" label="name" track-by="name" max="4" :preselect-first="false">
                    <template slot="selection" slot-scope="{ values, search, isOpen }"><span class="multiselect__single" v-if="values.length &amp;&amp; !isOpen">{{ values.length }} options selected</span></template>
                </multiselect>
            </div>
        </div>
        
        <div class="check-box">
            <input type="checkbox">
            <div class="agree-to-terms-text">
                Agree to terms
            </div>
        </div>

        <div class="button-container">
            <button>
                <div class="button-text">
                    Save
                </div>
            </button>
        </div>
    </div>
</template>

<script lang="ts">
    // import { SectorData } from "@/modules/sector";
    // import { useSectorsStore } from "@/stores/sectorsStore";
    import Multiselect from 'vue-multiselect';
    import { storeToRefs } from "pinia";
    // import { onMounted, ref, Ref, watch } from "vue";
    import { useRouter } from "vue-router";

    // const sectorsStore = useSectorsStore();
    // const options = storeToRefs(sectorsStore);

    export default {
        components: { Multiselect },
        data () {
            return {
                value: [],
                options: [
                    { name: 'Vue.js', language: 'JavaScript' },
                    { name: 'Adonis', language: 'JavaScript' },
                    { name: 'Rails', language: 'Ruby' },
                    { name: 'Sinatra', language: 'Ruby' },
                    { name: 'Laravel', language: 'PHP' },
                    { name: 'Phoenix', language: 'Elixir' }
                ],
            }
        }
    }

</script>

<style>
    @import url('https://unpkg.com/vue-multiselect@2.1.0/dist/vue-multiselect.min.css');
    @import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@200&family=Roboto&display=swap');
</style>
