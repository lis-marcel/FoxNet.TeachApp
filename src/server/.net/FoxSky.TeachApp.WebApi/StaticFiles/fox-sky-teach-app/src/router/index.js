import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import AllUsers from '../views/AllUsers.vue'
import EditUser from '../views/EditUser.vue'
import AddWord from '../views/AddWord.vue'
import AllWords from '../views/AllWords.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/users',
    name: 'users',
    component: AllUsers
  },
  {
    props: true,
    path: `/edituser/:userId`,
    name: 'edituser',
    component: EditUser
  },
  {
    path: '/addword',
    name: 'addword',
    component: AddWord
  },
  {
    props: true,
    path: '/allwords/:userId',
    name: 'allwords',
    component: AllWords
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
