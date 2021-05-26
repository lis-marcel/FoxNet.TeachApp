<template>
    <div class="words">
        <div class="categories">
            <select v-model="categories.categoryId">
                <option disabled value="">Please select one</option>
                <option v-for="category in categories" :key="category.categoryId">{{category.categoryName}}</option>
            </select>
        </div>
        <br>
        Phrase: <input type="text" placeholder="Enter word" v-model="word.phrase"><br><br>
        Translation: <input type="text" placeholder="Enter translation" v-model="word.translation"><br><br>
        Note: <input type="text" placeholder="Enter hint/description" v-model="word.note">
        <br>
        <br>
        <div id="buttons">
            <button class="btn btn-danger btn-sm">Cancel</button>
            <button class="btn btn-primary btn-sm" @click="addWord">Add</button>
        </div>
        <br>
    </div>
</template>

<script>
    export default {
        props: ['userId'],

        data() {
            return {
                categories: [],

                word: {
                    userId: this.userId,
                    categoryId: null,
                    phrase: null,
                    translation: null,
                    note: null
                }
            }
        },

        methods: {
            fetchCategories: function() {
                fetch(`http://localhost:14512/webapi/category/all`)
                    .then((response) => response.json())
                    .then((data) => (this.categories = data))
                    .catch((error) => console.error(error))
            },

            addWord: function() {
                var url = `http://localhost:14512/webapi/word/add`
                var options = { 
                    method: 'POST',  
                    headers: { 
                        'Content-type': 'application/json', 
                        'Access-Control-Allow-Origin': '*',
                        'Access-Control-Allow-Methods': 'POST'
                        }, 
                    body: JSON.stringify(this.word), 
                }

                fetch(url, options)
                    .catch(error => console.error(error))
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
    
    .words {
        border: 1px solid #cdcdcd;
        width: 27%;
        float: left;
        margin-left: 10px;
        display:inline;
    }
</style>