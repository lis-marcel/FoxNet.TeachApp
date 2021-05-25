<template>
  <div>
    <table class="table table-striped">
        <thead>
            <tr>
                <th></th>
                <th></th>
                <th></th>
                <th>
                    <button type="button" class="btn btn-primary btn-sm" @click="editOrAddUser(userId)">Add user</button>
                </th>
            </tr>

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
                <button type="button" class="btn btn-primary btn-sm" @click="editOrAddUser(user.userId)">Edit</button>
                <button type="button" class="btn btn-warning btn-sm" @click="loginAs(user.userId)">Login as</button>
            </td>
            </tr>
        </tbody>
        </table>
  </div>
</template>

<script>
    export default {
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
            
            editOrAddUser: function(id) {
                this.$router.push(`/user/edit/${id}`)
            },

            loginAs: function(id) {
                this.$router.push(`/user/home/${id}`)
            }
        },

        mounted() {
            this.fetchAllUsers();
        },
    }
</script>