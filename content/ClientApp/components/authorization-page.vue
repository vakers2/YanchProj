<template>
  <v-container>
    <v-layout row class="text-xs-center">
      <v-container style="position: relative;top: 13%;" class="text-xs-center">
        <v-card class="login-card" flat>
          <v-card-title primary-title>
            <h4 v-if="isLogin">Login</h4>
            <h4 v-if="!isLogin">Register</h4>
          </v-card-title>
          <v-form>
            <v-text-field v-model="login" prepend-icon="person" name="Login" label="Login"></v-text-field>
            <v-text-field v-if="!isLogin" v-model="name" prepend-icon="person" name="Name" label="Name"></v-text-field>
            <v-text-field
              v-model="password"
              prepend-icon="lock"
              name="Password"
              label="Password"
              type="password"
            ></v-text-field>
            <v-card-actions>
              <v-btn @click="signup()" class="btn btn-primary text-white" large block>{{LoginLabel}}</v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-container>
    </v-layout>
  </v-container>
</template>

<script>
import api from '../api'

const labels = {
  login: 'Log in',
  signup: 'Sign up'
}

export default {
  name: 'login',
  computed: {
    LoginLabel: function() {
      return this.isLogin ? labels.login : labels.signup
    }
  },
  methods: {
    signup() {
      if (!this.isLogin) {
        var user = {
          Login: this.login,
          Name: this.name,
          Password: this.password
        }
        api.authorization.post.registerUser(user)
      } else {
        var user = {
          Login: this.login,
          Password: this.password
        }
        api.authorization.post.logInUser(user)
      }
    }
  },
  data() {
    return {
      isLogin: true,
      login: '',
      name: '',
      password: ''
    };
  }
};
</script>

<style scoped>
.container {
  width: 500px;
}

.login-card {
  border: solid 1px black;
  padding: 10px;
}

.text-white {
  color: #ffffff;
}
</style>