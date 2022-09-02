<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de las consultas a participantes</h3>
        <router-link :to="{ name: 'AddParticipant' }"><button class="route-button">Añadir</button></router-link>
        <ul>
            <li v-for="participant in participants" :key="participant.id">
                <h4 class="label-style">Nombre: {{participant.name}}</h4>
                <h4 class="label-style">Apellido: {{participant.lastName}}</h4>
                <h4 class="label-style">Fecha de Nacimiento: {{participant.birthDate}}</h4>
                <h4 class="label-style">Edad: {{participant.age}}</h4>
                <h4 class="label-style">Nombre de la escuela: {{participant.schoolName}}</h4>

                <router-link :to="{ name: 'Participants_id', params: { id: participant.id } }"><button class="route-button">Editar</button></router-link>

                <button class="route-button" @click="deleteParticipant(participant.id)" type="submit">Borrar</button>
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
    },
    methods: {
        deleteParticipant(id) {
            fetch("https://localhost:44334/api/Participants/" + id), {
                method: "DELETE",
                body: JSON.stringify({
                    Id: id,
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*"
                },
            };
            fetch("https://localhost:44334/api/Participants", {
                headers: {
                    "Access-Control-Allow-Origin": "*"
                }
                })
                .then((result) => result.json())
                .then((data) => (this.participants = data))
        }
    }
}
</script>

<style>

</style>