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
                <input id="addNameChoreography" class="inputs-data" type="text" value="">
            </div>
            <div>
                <label>Categoría de la coreografía</label>
                <br>
                <input id="addCategoryChoreography" class="inputs-data" type="text">
            </div>
            <div>
                <label>Manager de la coreografía</label>
                <br>
                <input id="addManagerChoreography" class="inputs-data" type="text">
            </div>

            <!-- Esto hay que investigar como pasar la información para que la entienda como array en vez de como
            texto
            -->
            
            <div>
                <label>ID's de los miembros de la coreografía</label>
                <br>
                <!-- Esta parte falta de hacer. Por lo pronto es necesario una view para los detalles 
                de la escuela y pasarle por parametro el nombre de la misma para atacar al endpoint de 
                GetBySchoolName del controlador de coreografias
                
                <h5>Si no conoce los ID's de sus alumnos, consultelos aquí</h5>
                <label>Introduce el nombre de tu escuela</label>
                <input type="text">
                <br>
                <router-link :to="{ name: 'Home'}"><button class="route-button">Buscar</button></router-link> -->
                <input id="addMembersChoreography" class="inputs-data" type="text">
            </div>
            <div>
                <label>Nota en el clasificatorio de los jueces</label>
                <br>
                <input id="addSemifinalMarkJudge1" class="inputs-data" type="number">
                <input id="addSemifinalMarkJudge2" class="inputs-data" type="number">
                <input id="addSemifinalMarkJudge3" class="inputs-data" type="number">
            </div>
            <div>
                <label>Nota de corte para el pase a la final</label>
                <br>
                <input id="addManagerChoreography" class="inputs-data" type="number">
            </div>
            <div v-if="isFinalist">
                <label>Nota de la final</label>
                <br>
                <input id="addManagerChoreography" class="inputs-data" type="number">
            </div>
            <div>
                <label>Nombre de la escuela a la que pertenece la coreografía</label>
                <br>
                <input id="addNameSchool" class="inputs-data" type="text">
            </div>
            <button id="addButton" @click="addChoreography" type="submit">Editar</button>
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
        editChoreography: function(e){
            var id = e.target.id
            fetch("https://localhost:44334/api/Choreographies/" + id, {
                method: "PUT",
                body: JSON.stringify({
                    name: document.getElementById("editNameChoreography").value,
                    lastName: document.getElementById("editSurenameChoreography").value,
                    birthDate: document.getElementById("editBirthDateChoreography").value,
                    age: document.getElementById("editAgeChoreography").value,
                    schoolName: document.getElementById("editNameSchool").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*"
                },
            });
        },
        getChoreographyDetails(id) {
            fetch("https://localhost:44334/api/Choreographies/" + id,{
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