<template>
    <div class="categories">
        <select>
            <option disabled value="">Please select one</option>
            <option v-for="category in categories" :key="category.categoryId">{{category.categoryName}}</option>
        </select>
    </div>
</template>

<script>
    export default {
        props: ['selectedCategory'],

        data() {
            return {
                categories: []
            }
        },

        methods: {
            fetchCategories: function() {
                fetch(`http://localhost:14512/webapi/category/all`)
                    .then((response) => response.json())
                    .then((data) => (this.categories = data))
                    .catch((error) => console.error(error))
            },
        },

        mounted() {
            this.fetchCategories();
        }
    }
</script>

<style>
    .categories {
        float: left;
        margin-left: 10px;
    }
</style>