<template>
  <b-navbar toggleable="lg" variant="faded" type="dark">
    <b-navbar-brand href="#">
      <router-link to="/">Lorem</router-link>
    </b-navbar-brand>

    <b-navbar-nav class="ml-auto">
      <em>User</em>
    </b-navbar-nav>
  </b-navbar>
</template>

<script>
import { routes } from '../router/routes';

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
    }
  }
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
}

.navbar-brand {
  width: initial;
}

.navbar a {
  text-decoration: none;
  color: #ffffff;
}
</style>
