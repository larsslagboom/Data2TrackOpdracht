<template>
    <div id="app">
        <GoogleMaps />
    </div>
</template>

<script>
    import GoogleMaps from './components/GoogleMaps.vue';

    export default {
        name: 'App',
        components: {
            GoogleMaps,
        },
    };
</script>
