<template>
    <div>
        Forename <input type="text" placeholder="Forename">
        Surname <input type="text" placeholder="Surname">
        Email <input type="text" placeholder="Email">
        Forename <input type="text" placeholder="Forename">
        Forename <input type="text" placeholder="Forename">
    </div>
</template>

<script>
    import './DataTable.vue'

    export default {
        props: ['userId'],

        data() {
            return {
                user: [],
            }
        },

        methods: {
            fetchUser: function(userId) {
                fetch(`http://localhost:14512/webapi/administration/user/get/${userId}`)
                    .then(response => response.json())
                    .then(data => this.user = data)
                    .then(error => console.error(error))
            }
        },

        mounted() {
            this.fetchUser(this.userId)
        }
    }
</script>