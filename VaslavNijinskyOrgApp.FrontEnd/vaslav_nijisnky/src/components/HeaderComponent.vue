<template>
    <router-link :to="{ name: 'Home' }"><img id="logo" src="../assets/Logo.png"></router-link>
</template>

<script>

export default {
    name: "HeaderComponent"
}
</script>

<style>
#logo {
    width: 100px;
    height: 100px;
}
</style>