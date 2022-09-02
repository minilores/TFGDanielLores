<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de las consultas a escuelas</h3>
        <router-link :to="{ name: 'AddSchool' }"><button class="route-button">Añadir</button></router-link>
        <ul>
            <li v-for="school in schools" :key="school.id">
                <h4 class="label-style">Escuela: {{school.name}}</h4>
                <router-link :to="{ name: 'Schools_id', params: { id: school.id }  }"><button class="route-button">Editar</button></router-link>
                <button class="route-button" @click="deleteSchool(school.id)" type="submit">Borrar</button>
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
    },
    methods: {
        deleteSchool(id) {
            fetch("https://localhost:44334/api/Schools/" + id), {
                method: "DELETE",
                body: JSON.stringify({
                    schoolId: id,
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*"
                },
            };
            fetch("https://localhost:44334/api/Schools", {
                headers: {
                    "Access-Control-Allow-Origin": "*"
                }
                })
                .then((result) => result.json())
                .then((data) => (this.schools = data))
        }
    }
}
</script>

<style>
.label-style{
    border-radius: 2px;
    border-width: 5px
}
</style>

