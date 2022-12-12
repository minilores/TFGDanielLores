<template>
    <div>
        <HeaderComponent />
        <p>Esta es la página de editar coreografias</p>
        <router-link :to="{ name: 'Choreographies'}"><button class="route-button">Volver</button></router-link>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div>
                <label>Nombre de la coreografía</label>
                <br>
                <input id="editNameChoreography" class="inputs-data" type="text" v-bind:value="choreography.name">
            </div>
            <div>
                <label>Categoría de la coreografía</label>
                <br>
                <input id="editCategoryChoreography" class="inputs-data" type="text" v-bind:value="choreography.category">
            </div>
            <div>
                <label>Manager de la coreografía</label>
                <br>
                <input id="editManagerChoreography" class="inputs-data" type="text" v-bind:value="choreography.manager">
            </div>
            <div>
                <label>Nota de la semifinal</label>
                <br>
                <input id="editSemifinalMark" class="inputs-data" type="number" v-bind:value="choreography.semifinalMark">
            </div>
            <div>
                <label>¿Es finalista?</label>
                <br>
                <input id="editIsFinalist" class="inputs-data" type="text" v-bind:value="choreography.isFinalist">
            </div>
            <div>
                <label>Nota de la final</label>
                <br>
                <input id="editFinalMark" class="inputs-data" type="number" v-bind:value="choreography.finalMark">
            </div>
            <div>
                <label>Nombre de la escuela a la que pertenece la coreografía</label>
                <br>
                <input id="editNameSchool" class="inputs-data" type="text" v-bind:value="choreography.schoolName">
            </div>
            <button id="editButton" @click="editChoreography(choreography.id)" type="submit">Editar</button>
            <button id="resetButton" type="reset">Reestablecer</button>
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
            choreography: {},
        };
    },
    created() {
        this.getChoreographyDetails(this.$route.params.id);
    },
    beforeRouteUpdate(to, from) {
        this.getChoreographyDetails(to.params.id);
    },
    methods: {
        editChoreography(id){
            fetch("https://localhost:5001/api/Choreographies/" + id, {
                method: "PUT",
                body: JSON.stringify({
                    name: document.getElementById("editNameChoreography").value,
                    category: document.getElementById("editCategoryChoreography").value,
                    manager: document.getElementById("editManagerChoreography").value,
                    schoolName: document.getElementById("editNameSchool").value,
                    semifinalMark: document.getElementById("editSemifinalMark").value,
                    isFinalist: document.getElementById("editIsFinalist").value,
                    finalMark: document.getElementById("editFinalMark").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*",
                    "Content-type": "application/json"  
                },
            });
        },
        getChoreographyDetails(id) {
            fetch("https://localhost:5001/api/Choreographies/" + id,{
                headers:{
                    "Access-Control-Allow-Origin": "*"
                }
            })
                .then((result) => result.json())
                .then((data) => (this.choreography = data));
        }
    }
}
</script>

<style>

</style>