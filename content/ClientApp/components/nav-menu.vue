<template>
  <b-navbar toggleable="lg" variant="faded" type="dark">
    <b-navbar-brand href="#">
      <router-link to="/">Lorem</router-link>
    </b-navbar-brand>
    <router-link to="/create-post" v-if="name"><p class="nav-button">Create post</p></router-link>
    <router-link to="/user-management" v-if="admin"><p class="nav-button">User management</p></router-link>
    <b-navbar-nav class="ml-auto dropdown">
      <b-nav-item-dropdown class="text-white" v-if="name" right>
        <!-- Using button-content slot -->
        <template slot="button-content">
          <em>{{name}}</em>
        </template>
        <b-dropdown-item class="text-black" @click="signOut()" href="#"><em>Sign out</em></b-dropdown-item>
      </b-nav-item-dropdown>
      <router-link to="/login" v-if="!name">Log in</router-link>
    </b-navbar-nav>
    <router-link to="/signup" v-if="!name">Sign up</router-link>
  </b-navbar>
</template>

<script>
import { routes } from '../router/routes';
import { mapState } from 'vuex';

const actions = {
  CLEAR_USER_INFO: 'CLEAR_USER_INFO'
}

export default {
  data() {
    return {
      routes,
      collapsed: true
    };
  },
  methods: {
    toggleCollapsed: function(event) {
      this.collapsed = !this.collapsed;
    },
    signOut: function() {
      this.$store.commit(actions.CLEAR_USER_INFO);
      this.$router.push('/');
    }
  },
  computed: mapState(['name', 'admin'])
};
</script>

<style scoped>
.navbar {
  color: #ffffff;
  background: #7f7fd5; /* fallback for old browsers */
  background: -webkit-linear-gradient(
    to left,
    #91eae4,
    #86a8e7,
    #7f7fd5
  ); /* Chrome 10-25, Safari 5.1-6 */
  background: linear-gradient(
    to left,
    #91eae4,
    #86a8e7,
    #7f7fd5
  ); /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
  font-size: 1.5vw;
  z-index: 1;
}

@media (max-width: 800px) {
  .navbar {
    font-size: 1em;
  }
}

.navbar-brand {
  width: initial;
}

.navbar a {
  text-decoration: none;
  color: #ffffff;
}

.nav-button {
  font-size: 0.9em;
  margin: 0 0 0 1em;
}

.ml-auto {
  margin-right: 1em;
}

.text-white em {
  color: #ffffff;
}

.text-black em {
  color: #000000;
}
</style>
