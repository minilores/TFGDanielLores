<template>
    <div>
        <header>
            <HeaderComponent />
            <h3>Esta es la página de editar escuelas</h3>
        </header>
        <router-link :to="{ name: 'Schools'}"><button class="route-button">Volver</button></router-link>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div class="attributeToEdit">
                <label>Nombre de la escuela</label>
                <br>
                <input class="inputToEdit" id="editNameSchool" type="text" v-bind:value="school.name">
            </div>
            <router-link :to="{ name: 'Schools'}"><button class="attributeToEdit" id="editButton" @click="editSchool(school.id)" type="submit">Editar</button></router-link>
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
            school: {},
        };
    },
    created() {
        this.getSchoolDetails(this.$route.params.id);
    },
    beforeRouteUpdate(to, from) {
        this.getSchoolDetails(to.params.id);
    },
    methods: {
        editSchool(id){
            fetch("https://localhost:5001/api/Schools/" + id, {
                method: "PUT",
                body: JSON.stringify({
                    name: document.getElementById("editNameSchool").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*",
                    "Content-type": "application/json" 
                },
            });
        },
        getSchoolDetails(id) {
            fetch("https://localhost:5001/api/Schools/" + id,{
                headers:{
                    "Access-Control-Allow-Origin": "*"
                }
                })
                .then((result) => result.json())
                .then((data) => (this.school = data));
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