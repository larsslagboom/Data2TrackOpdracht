<template>
    <div>
        <div ref="mapContainer" class="google-maps-container"></div>
    </div>
</template>

<script>

    import { ref, onMounted } from 'vue';
    import { Loader } from '@googlemaps/js-api-loader';

    export default {
        name: 'GoogleMaps',
        setup() {
            const mapContainer = ref(null);
            let infoWindow = null;

            onMounted(() => {
                const loader = new Loader({
                    apiKey: 'insert api key here',
                    version: 'weekly',
                });

                loader.load().then(() => {
                    const google = window.google;
                    const mapElement = mapContainer.value;

                    if (mapElement) {
                        const map = new google.maps.Map(mapElement, {
                            center: { lat: 52.1, lng: 5 },
                            zoom: 12,
                        });

                        fetch('ip here')
                            .then(response => response.json())
                            .then(data => {
                                data.forEach(poi => {
                                    // Define marker color based on PoiType
                                    let markerColor = 'red';
                                    if (poi.poiType === 2) {
                                        markerColor = 'blue';
                                    } else if (poi.poiType === 3) {
                                        markerColor = 'green';
                                    }

                                    const marker = new google.maps.Marker({
                                        position: { lat: poi.poiLat, lng: poi.poiLon },
                                        map,
                                        title: poi.poiTitle,
                                        icon: {
                                            path: google.maps.SymbolPath.CIRCLE,
                                            fillColor: markerColor,
                                            fillOpacity: 1,
                                            strokeColor: 'black',
                                            strokeWeight: 1,
                                            scale: 6,
                                        },
                                    });

                                    const infoWindowContent = `
                                        <div class="info-window">
                                            <h3>${poi.poiTitle}</h3>
                                            <p class="radius">Radius: ${poi.poiRadius}</p>
                                        </div>
                                    `;

                                    marker.addListener('click', () => {
                                        if (infoWindow) {
                                            infoWindow.close();
                                        }

                                        infoWindow = new google.maps.InfoWindow({
                                            content: infoWindowContent,
                                        });

                                        infoWindow.open(map, marker);
                                    });

                                    const circle = new google.maps.Circle({
                                        strokeColor: markerColor,
                                        strokeOpacity: 0.8,
                                        strokeWeight: 1,
                                        fillColor: markerColor,
                                        fillOpacity: 0.2,
                                        map,
                                        center: { lat: poi.poiLat, lng: poi.poiLon },
                                        radius: poi.poiRadius,
                                    });
                                });
                            })
                            .catch(error => {
                                console.error('Error fetching POI data:', error);
                            });
                    }

                }).catch((error) => {
                    console.error('Error loading Google Maps:', error);
                });
            });

            return { mapContainer };
        },
    };
</script>

<style scoped>
    .google-maps-container {
        height: 600px;
    }

    .info-window {
        background-color: #ffffff;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
    }

    .radius {
        margin-top: 5px;
        font-style: italic;
    }
</style>
