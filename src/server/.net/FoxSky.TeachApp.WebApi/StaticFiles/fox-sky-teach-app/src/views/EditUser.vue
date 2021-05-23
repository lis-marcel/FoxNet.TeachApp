<template>
    <div>
        <h3>ID: {{user.userId}}</h3>
        Forename <input id="Forename" type="text" placeholder="Forename" :value="user.forename"><br><br>
        Surname <input id="Surname" type="text" placeholder="Surname" :value="user.surname"><br><br>
        Email <input id="Email" type="email" placeholder="Email" :value="user.email"><br><br>
        Password <input id="Password" type="text" placeholder="Password" :value="user.password"><br><br>

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

            updateOrInsertUser: function(userId) {
                fetch(`http://localhost:14512/webapi/administration/user/update/${userId}`, { method: 'POST',  headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(this.user), })
                    .then(data => { console.log('Success:', data); })                        
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