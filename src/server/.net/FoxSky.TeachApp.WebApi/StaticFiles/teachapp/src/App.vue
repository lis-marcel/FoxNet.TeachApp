<template>
  <div>
    <h1>Administration</h1>
    <div class="item">
      <UserViewComponent />     
    </div>

    <hr>

    <div>
      <DataTableComponent />
    </div>
  </div>
</template>

<script>
  import Vue from 'vue'
  import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

// Import Bootstrap an BootstrapVue CSS files (order is important)
  import 'bootstrap/dist/css/bootstrap.css'
  import 'bootstrap-vue/dist/bootstrap-vue.css'

// Make BootstrapVue available throughout your project
  Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
  Vue.use(IconsPlugin)
 import UserView from './components/UserView.vue'
 import DataTable from './components/DataTable.vue'

 export default {
   components: {
     UserViewComponent: UserView,
     DataTableComponent: DataTable
    }
  }
</script>

<style>
  h1 {
   text-align: center;
  }

  .item {
    border: 1px solid #cdcdcd;
    margin: 8px;
    padding: 10px;
    text-align: center;
  }
</style>
