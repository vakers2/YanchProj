import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const SET_USER_INFO = 'SET_USER_INFO'
const CLEAR_USER_INFO = 'CLEAR_USER_INFO'
const ADMIN_STATUS = 3

// STATE
const state = {
  id: '',
  name: '',
  admin: false
}

// MUTATIONS
const mutations = {
  [SET_USER_INFO] (state, obj) {
    state.id = obj.userId
    state.name = obj.name
    state.admin = (obj.status === ADMIN_STATUS)
  },
  [CLEAR_USER_INFO] (state) {
    state.id = ''
    state.name = ''
    state.admin = false
  }
}

// ACTIONS
const actions = ({
  setUserInfo ({ commit }, obj) {
    commit(SET_USER_INFO, obj)
  },
  clearUserInfo ({ commit }) {
    commit(CLEAR_USER_INFO)
  }
})

export default new Vuex.Store({
  state,
  mutations,
  actions
})
