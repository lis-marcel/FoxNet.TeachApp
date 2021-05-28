import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import AllUsers from '../views/AllUsers.vue'
import EditUser from '../views/EditUser.vue'
import AddWord from '../views/AddWord.vue'
import AllWords from '../views/AllWords.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'
import Secure from '../components/Secure.vue'

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
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/register',
    name: 'register',
    component: Register
  },
  {
    path: '/secure',
    name: 'secure',
    component: Secure,
    meta: {
      requiresAuth: true
    }
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

router.beforeEach((to, from, next) => {
  if(to.matched.some(record => record.meta.requiresAuth)) {
    if (store.getters.isLoggedIn) {
      next()
      return
    }
    next('/login')
  } else {
    next()
  }
})

export default router