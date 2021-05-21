import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import DataTable from '../views/DataTable.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/data',
    name: 'Data',
    component: DataTable
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
