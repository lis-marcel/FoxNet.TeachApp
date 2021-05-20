<template>
  <div>
    <h1 class="d-flex justify-content-center">Administration</h1>
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
 import DataTable from './components/DataTable.vue'

 export default {
   components: {
     DataTableComponent: DataTable
    }
  }
</script>