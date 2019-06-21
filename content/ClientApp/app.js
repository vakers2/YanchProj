import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import BootstrapVue from 'bootstrap-vue'
import Vuetify from 'vuetify'

import './css/site.css'
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'vuetify/dist/vuetify.min.css'

var signalR = require('./signalr.min.js')

// Registration of global components
Vue.component('icon', FontAwesomeIcon)
Vue.use(Vuetify)
Vue.use(BootstrapVue)
Vue.use(VueMaterial)

Vue.prototype.$http = axios
Vue.prototype.$signalR = signalR

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
