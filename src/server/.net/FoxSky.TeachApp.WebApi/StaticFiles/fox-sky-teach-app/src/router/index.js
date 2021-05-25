import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import DataTable from '../views/DataTable.vue'
import EditUser from '../views/EditUser.vue'
import UserHome from '../views/UserHome.vue'
import AddWord from '../views/AddWord.vue'

const routes = [
  {
    path: '/',
    name: 'main',
    component: Home
  },
  {
    path: '/user',
    name: 'user',
    component: DataTable
  },
  {
    props: true,
    path: `/user/edit/:userId`,
    name: 'edit',
    component: EditUser
  },
  {
    props: true,
    path: `/user/home/:userId`,
    name: 'home',
    component: UserHome
  },
  {
    path: '/word',
    name: 'word',
    component: AddWord
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
