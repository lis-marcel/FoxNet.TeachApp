<template>
    <div>
        <div id="menu">
            <MenuComponent />
        </div>
        <div class="content">
            <WordComponent :userId="userId"/>
            <TestComponent />
            <ResultComponent />

        </div>
    </div>
</template>

<script>
    import Word from '../components/Words.vue'
    import Menu from '../components/Menu.vue'
    import Test from '../components/Test.vue'
    import Result from '../components/ShowResults.vue'

    export default {
        props: ['userId'],

        components: {
            WordComponent: Word,
            MenuComponent: Menu,
            TestComponent: Test,
            ResultComponent: Result
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
</style>