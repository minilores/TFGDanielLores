<template>
    <div>
        <header>
            <HeaderComponent />
            <h3>Esta es la página de editar participantes</h3>
        </header>
        <router-link :to="{ name: 'Participants'}"><button class="route-button">Volver</button></router-link>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div>
                <label>Nombre del participante</label>
                <br>
                <input id="editNameParticipant" type="text" v-bind:value="participant.name">
            </div>
            <div>
                <label>Apellido del participante</label>
                <br>
                <input id="editSurenameParticipant" type="text" v-bind:value="participant.lastName">
            </div>
            <div>
                <label>Fecha de nacimiento del participante</label>
                <br>
                <input id="editBirthDateParticipant" type="date" v-bind:value="participant.birthDate">
            </div>
            <div>
                <label>Edad del participante</label>
                <br>
                <input id="editAgeParticipant" type="date" v-bind:value="participant.age">
            </div>
            <div>
                <label>Nombre de la escuela a la que pertenece el participante</label>
                <br>
                <input id="editNameSchool" type="text" v-bind:value="participant.schoolName ">
            </div>
            <button id="editButton" @click="editParticipant" type="submit">Editar</button>
        </div>
    </div>
</template>

<script>
import HeaderComponent from '../components/HeaderComponent.vue'

export default {
    components: {
        HeaderComponent
    },
    data() {
        return {
            participant: {},
        };
    },
    created() {
        this.getParticipantDetails(this.$route.params.id);
    },
    beforeRouteUpdate(to, from) {
        this.getParticipantDetails(to.params.id);
    },
    methods: {
        editParticipant: function(e){
            var id = e.target.id
            fetch("https://localhost:44334/api/Participants/" + id, {
                method: "PUT",
                body: JSON.stringify({
                    name: document.getElementById("editNameParticipant").value,
                    lastName: document.getElementById("editSurenameParticipant").value,
                    birthDate: document.getElementById("editBirthDateParticipant").value,
                    age: document.getElementById("editAgeParticipant").value,
                    schoolName: document.getElementById("editNameSchool").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*"
                },
            });
        },
        getParticipantDetails(id) {
            fetch("https://localhost:44334/api/Participants/" + id,{
                headers:{
                    "Access-Control-Allow-Origin": "*"
                }
            })
                .then((result) => result.json())
                .then((data) => (this.participant = data));
        }
    }
}
</script>

<style>

</style>