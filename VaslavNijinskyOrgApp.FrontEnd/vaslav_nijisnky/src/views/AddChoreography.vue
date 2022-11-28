<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de añadir coreografias</h3>
        <router-link :to="{ name: 'Choreographies'}"><button class="route-button">Volver</button></router-link>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div>
                <label>Nombre de la coreografía</label>
                <br>
                <input id="addNameChoreography" class="inputs-data" type="text">
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
                <label>Nombre de la escuela a la que pertenece la coreografía</label>
                <br>
                <input id="addNameSchool" class="inputs-data" type="text">
            </div>
            <button id="addButton" @click="addChoreography" type="submit">Añadir</button>
        </div>
    </div>
</template>

<script>

import axios from 'axios'
import HeaderComponent from '../components/HeaderComponent.vue'

export default {
    components: {
        HeaderComponent
    },
    methods: {
        addChoreography: function(){
            fetch("https://localhost:5001/api/Choreographies/", {
                method: "POST",
                body: JSON.stringify({
                    name: document.getElementById("addNameSchool").value
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*",
                    "Content-type": "application/json"
                },
            });
        }  
    }
}
</script>

<style>

</style>