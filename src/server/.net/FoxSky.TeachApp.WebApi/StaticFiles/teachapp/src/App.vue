<template>
  <div>
    <h1>Administration module</h1>
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
