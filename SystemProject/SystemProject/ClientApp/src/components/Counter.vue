<template>
    <h1 class="">Counter</h1>

    <p class="text-slate-5000">This is a simple example of an Vue component.</p>

    <p aria-live="polite" class="text-blue-400">Current count: <strong>{{ currentCount }}</strong></p>
    <span class="icon text-pink-400"><i class="mdi mdi-desktop-mac"></i></span>
    <h1 class="text-3xl font-bold underline text-blue-400">
        Hello world!
    </h1>
    <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" @click="incrementCounter">Increment</button>
</template>


<script>
    export default {
        name: "Counter",
        data() {
            return {
                currentCount: 0
            }
        },
        methods: {
            incrementCounter() {
                this.currentCount++;
            }
        }
    }
</script>