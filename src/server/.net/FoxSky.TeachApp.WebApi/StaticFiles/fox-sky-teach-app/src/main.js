import Vue from 'vue/dist/vue.common.js'
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import Vuex from 'vuex'
import Store from './store.js'

Vue.use(Vuex)

var app = createApp(App)
app.config.globalProperties.$store = Store

// const token = localStorage.getItem('token')
// if (token) {
//   app.config.globalProperties.$http.defaults.headers.common['Authorization'] = token
// }

app.use(router).mount('#app')