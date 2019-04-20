import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const SET_USER_INFO = 'SET_USER_INFO'
const CLEAR_USER_INFO = 'CLEAR_USER_INFO'

// STATE
const state = {
  id: '',
  name: ''
}

// MUTATIONS
const mutations = {
  [SET_USER_INFO] (state, obj) {
    state.id = obj.id
    state.name = obj.name
  },
  [CLEAR_USER_INFO] (state) {
    state.id = ''
    state.name = ''
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
