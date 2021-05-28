<template>
 <div>
   <form class="login" @submit.prevent="tryLogin">
     <h1>Sign in</h1>
     <label>Email</label>
     <input required v-model="login" type="text" placeholder="Name"/>
     <label>Password</label>
     <input required v-model="password" type="password" placeholder="Password"/>
     <hr>
     <button type="submit">Login</button>
   </form>
 </div>
</template>

<script>
    export default {
        data() {
            return {
                login: '',
                password: ''
            }
        },

        methods: {
            tryLogin: function() {
                let login = this.login
                let password = this.password
                this.$store.dispatch('login', {login, password})
                .then(() => this.$router.push('/'))
                .catch(error => console.error(error))
            }
        }    
    }
</script>