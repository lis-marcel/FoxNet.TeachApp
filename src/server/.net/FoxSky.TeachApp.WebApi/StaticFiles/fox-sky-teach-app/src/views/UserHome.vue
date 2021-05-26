<template>
    <div>
        <div id="menu">
            <MenuComponent />
        </div>
        <div class="content">
            <CategoriesComponent />
            <br>
            <WordComponent :selectedCategory="selectedCategory"/>
        </div>
    </div>
</template>

<script>
    import Categories from '../components/Categories.vue'
    import Word from '../components/Words.vue'
    import Menu from '../components/Menu.vue'

    export default {
        props: ['userId', 'selectedCategory'],

        components: {
            CategoriesComponent: Categories,
            WordComponent: Word,
            MenuComponent: Menu
        }
    }
</script>

<style>
    body, html {
        height: 100%;
    }

    #menu {
        border-right: 1px solid #cdcdcd;
        float: left;
        width: 15%;
        height: 100%;
    }

    .content {
    }
</style>