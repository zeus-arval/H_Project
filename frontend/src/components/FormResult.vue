<template>
    <div class="form-result-border">
        <div class="result-picture-container">
            <div :class="props.errorOccured ? 'failure-result-picture-box' : 'success-result-picture-box'"/>
        </div>
        <div class="message-box">
            <div class="message-box" v-if="props.errorOccured">
                Something went wrong
            </div>
            <div class="message-box" v-if="!props.errorOccured">
                Saved successfully
            </div>
        </div>

        <div class="form-result-button-container">
            <button @click="close()">
                <div class="button-text">
                    <div>
                        Go back
                    </div>
                </div>
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">

const props = defineProps(['errorOccured']);

const emit = defineEmits(['close']);
const close = () => {
    emit('close');
}

</script>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@200&family=Roboto&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@500&family=Roboto&display=swap');
</style>