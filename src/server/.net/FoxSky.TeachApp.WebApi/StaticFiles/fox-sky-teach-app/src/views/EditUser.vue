<template>
    <div>
        Forename <input id="Forename" type="text" placeholder="Forename" v-model="user.forename"><br><br>
        Surname <input id="Surname" type="text" placeholder="Surname" v-model="user.surname"><br><br>
        Email <input id="Email" type="email" placeholder="Email" v-model="user.email"><br><br>
        Password <input id="Password" type="text" placeholder="Password" v-model="user.password"><br><br>

        <button type="button" class="btn btn-danger btn-sm" @click="returnToAllUsers">Cancel</button>
        <button type="button" class="btn btn-primary btn-sm" @click="updateOrInsertUser(user.userId)">Update</button>
    </div>
</template>

<script>
    import './DataTable.vue'

    export default {
        props: ['userId'],

        data() {
            return {
                user: {
                    forename: null,
                    surname: null,
                    email: null,
                    password: null
                }
            }
        },

        methods: {
            fetchUser: function(userId) {
                fetch(`http://localhost:14512/webapi/administration/user/get/${userId}`)
                    .then(response => response.json())
                    .then(data => this.user = data)
                    .catch(error => console.error(error))
            },

            updateOrInsertUser: function() {
                var url = this.userId != null ? `http://localhost:14512/webapi/administration/user/add`: `http://localhost:14512/webapi/administration/user/edit`
                var options = { 
                    method: 'POST',  
                    headers: { 
                        'Content-type': 'application/json', 
                        'Access-Control-Allow-Origin': '*',
                        'Access-Control-Allow-Methods': 'POST'
                        }, 
                    body: JSON.stringify(this.user), 
                }



                fetch(url, options)
                   .then(data => this.$router.go(-1))
                   .catch(error => console.error(error))
            },

            returnToAllUsers: function() {
                this.$router.push('/user')
            }
        },

        mounted() {
            this.fetchUser(this.userId)
        }
    }
</script>