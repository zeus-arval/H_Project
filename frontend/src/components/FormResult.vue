<template>
    <div class="form-result-border">
        <div class="result-picture-container">
            <div class="result-picture-box">
            </div>
        </div>
        <div class="message-box">
            <div class="message-box" v-if="true">
                Something went wrong
            </div>
            <div class="message-box" v-if="false">
                Saved successfully
            </div>
        </div>

        <div class="form-result-button-container">
            <button>
                <div class="button-text">
                    <div v-if="false">
                        Go back
                    </div>
                    <div v-if="true">
                        Ok
                    </div>
                </div>
            </button>
        </div>
    </div>
</template>


<style>
    @import url('https://fonts.googleapis.com/css2?family=Roboto&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@200&family=Roboto&display=swap');
    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@500&family=Roboto&display=swap');
</style>