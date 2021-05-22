<template>
    <div>
        <input type="text">
    </div>
</template>

<script>
    export default {
        data() {
            return {
                user: []
            }
        },

        methods: {
            fetchUser: function() {
                fetch(`http://localhost:14512/webapi/administration/user/get/${id}`)
                    .then(response => response.json())
                    .then(data => this.user = data)
                    .then(error => console.error(error))
            }
        }    
    }
</script>