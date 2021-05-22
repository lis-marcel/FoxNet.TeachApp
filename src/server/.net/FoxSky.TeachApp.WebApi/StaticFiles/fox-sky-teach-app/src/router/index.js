import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import DataTable from '../views/DataTable.vue'
import AddWord from '../views/AddWord.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/user',
    name: 'user',
    component: DataTable
  },
  {
    path: '/word',
    name: 'word',
    component: DataTable
  },
  {
    path: '/edit',
    name: 'edit',
    component: AddWord
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
