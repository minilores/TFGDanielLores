<template>
    <div>
        <header>
            <HeaderComponent />
            <h3>Esta es la página de editar participantes</h3>
        </header>
        <router-link :to="{ name: 'Participants'}"><button class="route-button">Volver</button></router-link>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div class="attributeToEdit">
                <label>Nombre del participante</label>
                <br>
                <input class="inputToEdit" id="editNameParticipant" type="text" v-bind:value="participant.name">
            </div>
            <div class="attributeToEdit">
                <label>Apellido del participante</label>
                <br>
                <input class="inputToEdit" id="editSurenameParticipant" type="text" v-bind:value="participant.lastName">
            </div>
            <div class="attributeToEdit">
                <label>Fecha de nacimiento del participante</label>
                <br>
                <input class="inputToEdit" id="editBirthDateParticipant" type="date" v-bind:value="participant.birthDate">
            </div>
            <div class="attributeToEdit">
                <label>Edad del participante</label>
                <br>
                <input class="inputToEdit" id="editAgeParticipant" type="number" v-bind:value="participant.age">
            </div>
            <div class="attributeToEdit">
                <label>Nombre de la escuela a la que pertenece el participante</label>
                <br>
                <input class="inputToEdit" id="editNameSchool" type="text" v-bind:value="participant.schoolName ">
            </div>
            <router-link :to="{ name: 'Participants'}"><button class="attributeToEdit" id="editButton" @click="editParticipant(participant.id)" type="submit">Editar</button></router-link>
            
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
        editParticipant(id){
            fetch("https://localhost:5001/api/Participants/" + id, {
                method: "PUT",
                body: JSON.stringify({
                    name: document.getElementById("editNameParticipant").value,
                    lastName: document.getElementById("editSurenameParticipant").value,
                    birthDate: document.getElementById("editBirthDateParticipant").value,
                    age: document.getElementById("editAgeParticipant").value,
                    schoolName: document.getElementById("editNameSchool").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*",
                    "Content-type": "application/json"  
                },
            });
        },
        getParticipantDetails(id) {
            fetch("https://localhost:5001/api/Participants/" + id,{
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
.attributeToEdit{
    margin-top: 10px;
}

.inputToEdit{
    margin-top: 5px;
}
</style>