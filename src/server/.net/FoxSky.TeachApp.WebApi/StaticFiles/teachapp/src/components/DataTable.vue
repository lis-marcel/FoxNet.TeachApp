<template>
    <div>
        <div>
            <h2>{{user.userId}}</h2>
            <h2>{{user.surname}}</h2>
            <h2>{{user.forename}}</h2>
        </div>
    </div>
</template>

<script>
    export default {
        /*user: {
            UserId: null,
            Surname: null,
            Forename: null,
            Password: null
        },*/
        allUsers: [],

        data() {
            return {
                user: []
            }
        },

        mounted() {
            fetch(`http://localhost:14512/webapi/administration/user/get/${1}`)
                .then(stream => stream.json())
                .then(data => this.user = data)
                .catch(error => console.error(error))
        }
    }
</script>
