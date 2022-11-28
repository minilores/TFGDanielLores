<template>
    <div>
        <header>
            <HeaderComponent />
            <h3>Esta es la página de añadir escuelas</h3>
        </header>
        <router-link :to="{ name: 'Schools'}"><button class="route-button">Volver</button></router-link>
        <div class="alert-success" v-if="isSuccess">Ha sido añadido correctamente</div>
        <div>
            <h4>Inserte los siguentes datos requeridos</h4>
            <div>
                <label>Nombre de la escuela</label>
                <br>
                <input id="addNameSchool" type="text">
            </div>
            <button id="addButton" @click="addSchool" type="submit">Añadir</button>
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
        addSchool(){
            fetch("https://localhost:5001/api/Schools/", {
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