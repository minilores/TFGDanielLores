<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de las consultas a coreografias</h3>
        <router-link :to="{ name: 'AddChoreography' }"><button class="route-button">Añadir</button></router-link>
        <ul>
            <li v-for="choreography in choreographies" :key="choreography.id">
                <h4 class="label-style">Nombre: {{choreography.name}}</h4>
                <h4 class="label-style">Categoría: {{choreography.category}}</h4>
                <h4 class="label-style">Manager: {{choreography.groupCoach}}</h4>
                <h4 class="label-style">Nombre de la escuela: {{choreography.schoolName}}</h4>
                <h4 class="label-style">Nota de la semifinal: {{choreography.semifinalMark}}</h4>
                <h4 v-if="choreography.isFinalist" class="label-style">Nota de la final: {{choreography.finalMark}}</h4>

                <router-link :to="{ name: 'Choreographies_id', params: { id: choreography.id } }"><button class="route-button">Editar</button></router-link>
                <button class="route-button" @click="deleteChoreography(choreography.id)" type="submit">Borrar</button>
            </li>
        </ul>
    </div>
</template>

<script>

import HeaderComponent from '../components/HeaderComponent.vue'

export default {
  components: {
    HeaderComponent
  },
  created() {
    fetch("https://localhost:5001/api/Choreographies", {
            headers: {
                "Access-Control-Allow-Origin": "*"
            }
        })
      .then((result) => result.json())
      .then((data) => (this.choreographies = data))
  },
  data() {
    return {
      choreographies: []
    };
  },
  methods: {
        deleteChoreography(id) {
            fetch("https://localhost:44334/api/Choreographies/" + id), {
                method: "DELETE",
                body: JSON.stringify({
                    Id: id,
                }),
                headers: {
                    "Access-Control-Allow-Origin": "*"
                },
            };
            fetch("https://localhost:44334/api/Choreographies", {
                headers: {
                    "Access-Control-Allow-Origin": "*"
                }
                })
                .then((result) => result.json())
                .then((data) => (this.choreographies = data))
        }
    }
}
</script>

<style>

</style>