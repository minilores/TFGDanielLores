<template>
    <div>
        <header>
            <HeaderComponent />
            <h3>Esta es la página de editar escuelas</h3>
        </header>
        <router-link :to="{ name: 'Schools'}"><button class="route-button">Volver</button></router-link>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div>
                <label>Nombre de la escuela</label>
                <br>
                <input id="editNameSchool" type="text" v-bind:value="school.name">
            </div>
            <button id="editButton" @click="editSchool" type="submit">Editar</button>
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
        editSchool: function(e){
            var id = e.target.id
            fetch("https://localhost:44334/api/Schools/" + id, {
                method: "PUT",
                body: JSON.stringify({
                    name: document.getElementById("editNameSchool").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*"
                },
            });
        },
        getSchoolDetails(id) {
            fetch("https://localhost:44334/api/Schools/" + id,{
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

</style>