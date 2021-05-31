<template>
  <div class="home">
    <h1>Home page</h1>
    <p>
      Status: {{this.$store.getters.authStatus}}
    </p>
    <p>Forename: {{this.$store.getters.loggedUser.forename}} </p>
    <p>Surname: {{this.$store.getters.loggedUser.surname}} </p>
    <p>User ID: {{this.$store.getters.loggedUser.userId}} </p>

  </div>
</template>

<script>
  export default {
    props: ['userId'],
    
    components: {
    }
  }
</script>
