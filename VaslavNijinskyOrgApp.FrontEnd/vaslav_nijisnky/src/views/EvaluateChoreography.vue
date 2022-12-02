<template>
  <div>
        <header>
            <HeaderComponent />
            <h3>Esta es la página de evaluar coreografias</h3>
        </header>
        <router-link :to="{ name: 'Choreographies'}"><button class="route-button">Volver</button></router-link>
        <div>
            <h4 class="label-style">Nombre de la coreografía: {{choreography.name}}</h4>
            <div>
                <label>Nota del primer juez</label>
                <br>
                <input id="firstJudgeValoration" type="number">
                <br>
                <label>Nota del segundo juez</label>
                <br>
                <input id="secondJudgeValoration" type="number">
                <br>
                <label>Nota del tercer juez</label>
                <br>
                <input id="thirdJudgeValoration" type="number">
            </div>
            <button id="evaluateButton" @click="evaluateChoreography()" type="submit">Evaluar</button>
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
        evaluateChoreography(){
            let firstValoration = document.getElementById("firstJudgeValoration").value
            let secondValoration = document.getElementById("secondJudgeValoration").value
            let thirdValoration = document.getElementById("thirdJudgeValoration").value

            let semifinalValoration = (firstValoration + secondValoration + thirdValoration)/3
        },
        getChoreographyDetails(id) {
            fetch("https://localhost:5001/api/Choreographies/" + id,{
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