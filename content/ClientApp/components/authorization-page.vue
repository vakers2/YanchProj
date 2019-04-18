<template>
  <v-container>
    <v-layout row class="text-xs-center">
      <v-container style="position: relative;top: 13%;" class="text-xs-center">
        <v-card class="login-card" flat>
          <v-card-title primary-title>
            <h4 v-if="login">Login</h4>
            <h4 v-if="!login">Register</h4>
          </v-card-title>
          <v-form>
            <v-text-field v-model="username" prepend-icon="person" name="Username" label="Username"></v-text-field>
            <v-text-field
              v-model="password"
              prepend-icon="lock"
              name="Password"
              label="Password"
              type="password"
            ></v-text-field>
            <v-card-actions>
              <v-btn
                @click="signup()"
                class="btn btn-primary text-white"
                large
                block
              >{{LoginLabel}}</v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-container>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  name: 'login',
  computed: {
    LoginLabel: function() {
      return 'Log in';
    }
  },
  data() {
    return {
      login: true,
      username: '',
      password: ''
    };
  }
};
</script>

<style>
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