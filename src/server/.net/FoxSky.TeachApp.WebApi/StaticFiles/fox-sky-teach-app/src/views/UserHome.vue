/<template>
    <div>
        <h1>{{category.categoryname}}</h1>
    </div>
</template>

<script>
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
                fetch(`http://localhost:14512/webapi/category/all/${userId}`)
                    .then(response => response.json())
                    .then(data => this.user = data)
                    .catch(error => console.error(error))
            },
        },

        mounted() {
            this.fetchUser(this.userId);
        }
    }
</script>