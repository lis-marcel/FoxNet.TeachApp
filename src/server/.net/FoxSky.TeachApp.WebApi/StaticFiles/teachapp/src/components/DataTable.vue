<template>
    <div>
        <div id="myTable"></div>

        <table id="dataTable" v-for="user in users" :key="user">
            <tr>
                <td>{{user.userId}}</td>
                <td>{{user.surname}}</td>
                <td>{{user.forename}}</td>
            </tr>
        </table>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                users: [],
            }
        },

        mounted() {
            fetch(`http://localhost:14512/webapi/administration/user/all`)
                .then(stream => stream.json())
                .then(data => this.users = data)
                .catch(error => console.error(error))
        }
    }
</script>

<style>
    #table {
        
    }
</style>