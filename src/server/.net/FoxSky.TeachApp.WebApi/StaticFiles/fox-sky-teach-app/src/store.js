import Vue from 'vue/dist/vue.common.js'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    status: '',
    user: {},
    token: localStorage.getItem('token') || '',
    serverUrl: 'http://localhost:14512/webapi'
  },

  mutations: {
    auth_request(state){
      state.status = 'loading'
    },
    auth_success(state, { token, user }){
      state.status = 'success'
      state.token = token
      state.user = user
    },
    auth_error(state){
      state.status = 'error'
    },
    logout(state){
      state.status = ''
      state.token = ''
    },
  },

  actions: {
    login({commit}, loginPassword){
      return new Promise((resolve, reject) => {
        commit('auth_request')
        axios({url: `${this.state.serverUrl}/authorization/login`, data: loginPassword, method: 'POST' })
        .then(resp => {
          localStorage.setItem('token', resp.data.token)
          axios.defaults.headers.common['Authorization'] = resp.data.token
          commit('auth_success', { token: resp.data.token, user: resp.data.user })
          resolve(resp)
        })
        .catch(err => {
          commit('auth_error')
          localStorage.removeItem('token')
          reject(err)
        })
      })
    },

    logout({commit}){
      return new Promise((resolve, reject) => {
        commit('logout')
        localStorage.removeItem('token')
        delete axios.defaults.headers.common['Authorization']
        resolve()
      })
    }
  },

  getters : {
    isLoggedIn: state => !!state.token,
    authStatus: state => state.status,
    loggedUser: state => state.user,
  }
})