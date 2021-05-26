<template>
    <div class="words">
        <br>
        Phrase: <input type="text" name="" id=""><br><br>
        Translation: <input type="text" name="" id=""><br><br>
        Note: <input type="text" name="" id="">
        <br>
        <button class=""></button>
        <button class=""></button>
    </div>
</template>

<script>
    export default {
        props: ['selectedCategory'],

        data() {
            return {
                word: {
                    phrase: null,
                    translation: null,
                    note: null
                }
            }
        },

        methods: {
            addWord: function() {
                fetch(`http://localhost:14512/webapi/word/add`, {method: 'POST'})
                    
            }
        }        
    }

</script>

<style>
    .words {
        border: 1px solid #cdcdcd;
        width: 30%;
        float: left;
        margin-left: 10px;
    }
</style>