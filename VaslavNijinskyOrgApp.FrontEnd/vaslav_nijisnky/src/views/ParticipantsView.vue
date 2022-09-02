<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de las consultas a participantes</h3>
        <router-link :to="{ name: 'AddParticipant' }"><button class="route-button">Añadir</button></router-link>
        <ul>
            <li v-for="participant in participants" :key="participant.id">
                {{participant.name}}
            </li>
        </ul>
    </div>
</template>

<script>

import HeaderComponent from '../components/HeaderComponent.vue'

export default {
    components: {
        HeaderComponent
    },  
    created() {
        fetch("https://localhost:44334/api/Participants", {
            headers: {
                "Access-Control-Allow-Origin": "*"
            }
            })
        .then((result) => result.json())
        .then((data) => (this.participants = data))
    },
    data() {
        return {
            participants: []
        };
    }
}
</script>

<style>

</style>