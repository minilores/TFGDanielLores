<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de las consultas a escuelas</h3>
        <router-link :to="{ name: 'AddSchool' }"><button class="route-button">Añadir</button></router-link>
        <ul>
            <li v-for="school in schools" :key="school.id">
                <p>{{school.name}}</p>
            </li>
        </ul>
    </div>
</template>

<script>

import api from '../utils/api'
import axios from 'axios'
import HeaderComponent from '../components/HeaderComponent.vue'

export default {
    components: {
        HeaderComponent
    },
    created() {
        fetch("https://localhost:44334/api/Schools", {
            headers: {
                "Access-Control-Allow-Origin": "*"
            }
            })
            .then((result) => result.json())
            .then((data) => (this.schools = data))
    },
    data() {
        return {
            schools: []
        };
    }
}
</script>

<style>

</style>

