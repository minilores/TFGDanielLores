<template>
    <div>
        <HeaderComponent />
        <h3>Esta es la página de las consultas a coreografias</h3>
        <router-link :to="{ name: 'AddChoreography' }"><button class="route-button">Añadir</button></router-link>
        <ul>
            <li v-for="choreography in choreographies" :key="choreography.id">
                {{choreography.name}}
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
    fetch("https://localhost:44334/api/Choreographies", {
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
  }
}
</script>

<style>

</style>