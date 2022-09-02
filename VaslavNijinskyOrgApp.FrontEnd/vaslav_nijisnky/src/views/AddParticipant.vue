<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de añadir participantes</h3>
        <router-link :to="{ name: 'Participants'}"><button class="route-button">Volver</button></router-link>
        <div class="alert-success" v-if="isSuccess">Ha sido añadido correctamente</div>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div>
                <label>Nombre del participante</label>
                <br>
                <input id="addNameParticipant" type="text">
            </div>
            <div>
                <label>Apellido del participante</label>
                <br>
                <input id="addSurenameParticipant" type="text">
            </div>
            <div>
                <label>Fecha de nacimiento del participante</label>
                <br>
                <input id="addBirthDateParticipant" type="date">
            </div>
            <div>
                <label>Nombre de la escuela a la que pertenece el participante</label>
                <br>
                <input id="addNameSchool" type="text">
            </div>
            <button id="addButton" @click="addParticipant" type="submit">Añadir</button>
        </div>
    </div>
</template>

<script>

import HeaderComponent from '../components/HeaderComponent.vue'

export default {
    components: {
        HeaderComponent
    },
    methods: {
        addParticipant: function(){
            fetch("https://localhost:44334/api/Participants/", {
                method: "POST",
                body: JSON.stringify({
                    name: document.getElementById("editNameParticipant").value,
                    lastName: document.getElementById("editSurenameParticipant").value,
                    birthDate: document.getElementById("editBirthDateParticipant").value,
                    age: this.calculateAgeInEventDate(),
                    schoolName: document.getElementById("editNameSchool").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*"
                },
            });
        },
        calculateAgeInEventDate(){
            let birthDate = document.getElementById("addBirthDateParticipant").value
            let eventDate = new Date("2023/03/03")
            let age = eventDate.getFullYear() - birthDate.getFullYear()
            let monthdiference = eventDate.getMonth() - birthDate.getMonth()
            if ( monthdiference < 0 || (monthdiference === 0 && eventDate.getDate() < birthDate.getDate())) 
            {
                age--
            }
            return age
            
        }
    }
}   
</script>

<style>

</style>