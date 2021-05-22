<template>
  <div>
    <table class="table table-striped">
        <thead>
            <tr>
            <th>ID</th>
            <th>Surname</th>
            <th>Forename</th>
            <th>Manage</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="user in users" :key="user.userId">
            <td>{{ user.userId }}</td>
            <td>{{ user.surname }}</td>
            <td>{{ user.forename }}</td>

            <td>
                <button type="button" class="btn btn-danger btn-sm" @click="deleteUser(user.userId)">Delete</button>
                <button type="button" class="btn btn-primary btn-sm" @click="editUser(user.userId)">Edit</button>
            </td>
            </tr>
        </tbody>
        </table>
  </div>
</template>

<script>
    export default {
        components: {
        },

        data() {
            return {
                users: [],
            };
        },

        methods: {
            fetchAllUsers: function() {
                fetch(`http://localhost:14512/webapi/administration/user/all`)
                    .then((response) => response.json())
                    .then((data) => (this.users = data))
                    .catch((error) => console.error(error));
            },

            deleteUser: function(id) {
                fetch(`http://localhost:14512/webapi/administration/user/delete/${id}`, {method: 'POST'})
                    .then(response => { 
                        if (response.ok) {
                            this.fetchAllUsers()
                        } })
                    .catch((error) => console.error(error))
            },
            
            editUser: function(id) {
                this.$router.push('/edit')
            }
        },

        mounted() {
            this.fetchAllUsers();
        },
    }
</script>