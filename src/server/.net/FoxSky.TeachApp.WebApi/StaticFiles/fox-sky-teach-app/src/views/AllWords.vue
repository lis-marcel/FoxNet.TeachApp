<template>
  <div>
    <table class="table table-striped">
        <thead>
            <tr>
                <th></th>
                <th></th>
                <th></th>
                <th>
                    <button type="button" class="btn btn-primary btn-sm">Add word</button>
                </th>
            </tr>

            <tr>
                <th>Phrase</th>
                <th>Translation</th>
                <th>Note</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="word in words" :key="word.worId">
                <td>{{ word.phrase }}</td>
                <td>{{ word.translation }}</td>
                <td>{{ word.note }}</td>

                <td>
                    <button type="button" class="btn btn-danger btn-sm" @click="deleteWord(word.wordId)">Delete</button>
                    <button type="button" class="btn btn-primary btn-sm">Edit</button>
                </td>
            </tr>
        </tbody>
    </table>
  </div>
</template>

<script>
    export default {
        props: ['$currentId'],

        data() {
            return {
                words: [],
            };
        },

        methods: {
            fetchAllWords: function($currentId) {
                fetch(`${this.$serverUrl}/word/all/${$currentId}`)
                    .then((response) => response.json())
                    .then((data) => (this.users = data))
                    .catch((error) => console.error(error));
            },

            deleteWord: function(id) {
                fetch(`${this.$serverUrl}/word/delete/${id}`, {method: 'POST'})
                    .then(response => { 
                        if (response.ok) {
                            this.fetchAllWords()
                        } })
                    .catch((error) => console.error(error))
            },
        },

        mounted() {
            this.fetchAllWords();
        },
    }
</script>