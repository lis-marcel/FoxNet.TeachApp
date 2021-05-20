<template>
    <div>
    <modal v-if="showModal" @close="showModal = false" name="Umesh">
			<p>dsfkdskf</p>
	 </modal>


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
                <tr v-for="user in users" :key="user">
                    <td>{{user.userId}}</td>
                    <td>{{user.surname}}</td>
                    <td>{{user.forename}}</td>
                    
                    <td>
                        <button type="button" class="btn btn-danger btn-sm" @click="showModal = true">Delete</button>
                        <button type="button" class="btn btn-primary btn-sm">Edit</button>
                    </td>
                </tr>
            </tbody>
        </table>

        
    </div>
</template>

<script>
    import modal from './ModalQuestion.vue'

    export default {
        components: {
            modal
        },

        data() {
            return {
                users: [],
                showModal: false
            }
        },

        methods: {
            fetchAllUsers: function() {
                fetch(`http://localhost:14512/webapi/administration/user/all`)
                    .then(stream => stream.json())
                    .then(data => this.users = data)
                    .catch(error => console.error(error))
            },
        },

        mounted() {
            this.fetchAllUsers()
            //this.deleteUser()
        }
    }
</script>