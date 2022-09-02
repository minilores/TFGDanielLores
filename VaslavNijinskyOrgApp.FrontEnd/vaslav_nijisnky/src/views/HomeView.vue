<template>
  <div>
    <HeaderComponent />
    <h1>Bienvenido a la página de la organización del concurso</h1>
    <h3>¿Qué quieres consultar?</h3>
    <div>
      <router-link :to="{ name: 'Choreographies' }"><button class="route-button">Coreografias</button></router-link> 
      <router-link :to="{ name: 'Participants' }"><button class="route-button">Participantes</button></router-link>
      <router-link :to="{ name: 'Schools' }"><button class="route-button">Escuelas</button></router-link>
    </div>
  </div>
</template>

<script>

import HeaderComponent from '../components/HeaderComponent.vue'

export default {
  components: {
    HeaderComponent
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.route-button{
  background-color: white;
  border-radius: 2px;
  margin: 0px 10px;
}

.inputs-data{
  margin: 10px 0px
}

#addButton{
  background-color: white;
  border-radius: 2px;
  margin-top: 10px;
}
</style>